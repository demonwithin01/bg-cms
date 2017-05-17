using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystem.Framework;
using System.IO;

namespace ContentManagementSystem.Admin.Managers
{
    public class UserManager : ManagerBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public UserModel GetUserModel( int? userId )
        {
            UserProfile user = base.Database.Users.Find( userId );

            if ( user == null )
            {
                return new UserModel();
            }
            
            return new UserModel( user );
        }

        public SaveResult UpdateUser( UserModel model )
        {
            try
            {
                if ( UserCookie.Current.HasRole( Role.Administrator ) == false )
                {
                    return SaveResult.AccessDenied;
                }

                UserProfile user = base.Database.Users.Find( model.UserId );

                user.Role = model.Role;

                base.Database.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
            //Upload upload = base.Database.Uploads.Find( model.UploadId );

            //if ( upload == null )
            //{
            //    return CreateImageUpload( model );
            //}

            //return UpdateImageUpload( upload, model );
        }

        //public static SaveResult SavePage( PageModel model )
        //{
        //    ContentManagementDb db = new ContentManagementDb();

        //    Page page = db.Pages.Find( model.PageId );

        //    if ( page == null )
        //    {
        //        return CreatePage( model, db );
        //    }

        //    return UpdatePage( page, model, db );
        //}

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods
            
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}