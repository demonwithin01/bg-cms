using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Admin.Models
{
    public class UploadsListItemModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public UploadsListItemModel()
        {

        }

        public UploadsListItemModel( Upload upload )
        {
            this.UploadId = upload.UploadId;
            this.Name = upload.Title;
            this.Location = upload.PhysicalLocation;
            this.DateUpdated = upload.DateUpdated;
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

        public int UploadId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime DateUpdated { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}