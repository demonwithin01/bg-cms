using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public class NavItem
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public NavItem()
        {
            SubItems = new List<NavItem>();
        }

        public NavItem( DomainNavigationItem navItem )
        {
            PageId = navItem.PageId;
            Title = navItem.Title;

            SubItems = navItem.SubNavigationItems.Select( s => new NavItem( s ) ).ToList();
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

        public int PageId { get; set; }

        public string Title { get; set; }

        public List<NavItem> SubItems { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
