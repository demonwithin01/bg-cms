using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApollyonWebLibrary;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystem.Framework;
using System.IO;

namespace ContentManagementSystem.Admin.Managers
{
    public class UploadsManager : ManagerBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Gets the upload information from the database.
        /// </summary>
        public UploadModel GetUploadModel( int? uploadId )
        {
            Upload upload = base.Database.Uploads.Find( uploadId );

            if ( upload == null )
            {
                return new UploadModel();
            }
            
            return new UploadModel( upload );
        }

        /// <summary>
        /// Saves the uploaded image to the database.
        /// </summary>
        public SaveResult SaveImage( UploadModel model )
        {
            Upload upload = base.Database.Uploads.Find( model.UploadId );

            if ( upload == null )
            {
                return CreateImageUpload( model );
            }

            return UpdateImageUpload( upload, model );
        }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Creates a new row in the database.
        /// </summary>
        private SaveResult CreateImageUpload( UploadModel model )
        {
            string fileLocation;
            string uploadFolder = ContentLocation.UploadFolder;

            try
            {
                int domainId = UserSession.Current.DomainId;

                Domain domain = base.Database.Domains.Find( domainId );
                
                uploadFolder += domain.UploadFolder.ToString();

                string physicalLocation = StringHelpers.MapToServer( uploadFolder );

                if ( Directory.Exists( physicalLocation ) == false )
                {
                    Directory.CreateDirectory( physicalLocation );
                }

                string currentDate = DateTime.Today.ToString( "yyyy-MM-dd" );
                uploadFolder += "/" + currentDate;
                physicalLocation += "/" + currentDate;

                if ( Directory.Exists( physicalLocation ) == false )
                {
                    Directory.CreateDirectory( physicalLocation );
                }

                fileLocation = physicalLocation + "/" + model.Upload.FileName;

                if ( File.Exists( fileLocation ) )
                {
                    File.Delete( fileLocation );
                }

                model.Upload.SaveAs( fileLocation );
            }
            catch// ( IOException ioException )
            {
                // Log exception

                return SaveResult.WriteFailure;
            }

            Upload upload = new Upload();
            upload.Initialise();
            upload.DomainId = UserSession.Current.DomainId;
            upload.Filename = model.Upload.FileName;
            upload.PhysicalLocation = uploadFolder + "/" + model.Upload.FileName;
            upload.Title = model.Title;
            upload.Description = model.Description;
            base.Database.Uploads.Add( upload );
            base.Database.SaveChanges();

            return SaveResult.Success;
        }

        /// <summary>
        /// Updates an existing row in the database.
        /// </summary>
        private SaveResult UpdateImageUpload( Upload upload, UploadModel model )
        {
            if ( model.Upload != null )
            {
                try
                {
                    string physicalLocation = StringHelpers.MapToServer( upload.PhysicalLocation );

                    if ( File.Exists( physicalLocation ) )
                    {
                        File.Delete( physicalLocation );
                    }
                    
                    model.Upload.SaveAs( physicalLocation );
                }
                catch// ( IOException ioException )
                {
                    // Log exception

                    return SaveResult.WriteFailure;
                }
            }

            upload.UpdateTimeStamp();
            upload.Title = model.Title;
            upload.Description = model.Description;

            base.Database.SaveChanges();

            return SaveResult.Success;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}