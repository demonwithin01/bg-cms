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

        }

        public NavItem( DomainNavigationItem navItem )
        {
            PageId = navItem.PageId;
            Title = navItem.Title;
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
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
