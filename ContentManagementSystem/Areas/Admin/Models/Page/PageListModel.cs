using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class PageListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public PageListModel( int domainId, ContentManagementDb db )
        {
            this.Pages = db.Pages.Where( p => p.DomainId == domainId ).ToList().Select( p => new PageListItemModel( p ) ).ToList();
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

        public List<PageListItemModel> Pages { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}