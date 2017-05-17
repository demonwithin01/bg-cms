using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class UploadModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public UploadModel()
        {

        }

        public UploadModel( Upload upload )
        {
            this.UploadId = upload.UploadId;
            this.Title = upload.Title;
            this.Description = upload.Description;
            this.UploadLocation = upload.PhysicalLocation;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public int? UploadId { get; set; }

        [Display( Name = "Title" )]
        public string Title { get; set; }

        [Display( Name = "Description" )]
        public string Description { get; set; }

        public HttpPostedFileBase Upload { get; set; }

        [Display( Name = "Url" )]
        public string UploadLocation { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}