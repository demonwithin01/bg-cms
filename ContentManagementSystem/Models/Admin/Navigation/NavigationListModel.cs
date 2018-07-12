using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class NavigationListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public NavigationListModel()
        {

        }

        public NavigationListModel( int domainId, ContentManagementDb db )
        {
            this.NavItems = db.DomainNavigationItems.Where( d => d.DomainId == domainId && d.ParentDomainNavigationItemId == null )
                                                    .OrderBy( s => s.Ordinal )
                                                    .ToList()
                                                    .Select( d => new NavigationListItemModel( d ) )
                                                    .ToList();
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

        public List<NavigationListItemModel> NavItems { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}