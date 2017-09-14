using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class UploadsListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public UploadsListModel( int domainId, ContentManagementDb db )
        {
            this.Uploads = db.Uploads.Where( s => s.DomainId == domainId ).ToList().Select( s => new UploadsListItemModel( s ) ).ToList();
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

        public List<UploadsListItemModel> Uploads { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}