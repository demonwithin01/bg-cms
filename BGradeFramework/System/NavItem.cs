using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Navigation Item for use for storing in memory and using in views.
    /// </summary>
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

        /// <summary>
        /// Creates a new Nav Item.
        /// </summary>
        public NavItem()
        {
            SubItems = new List<NavItem>();
        }

        /// <summary>
        /// Creates a new Nav Item from a database instance.
        /// </summary>
        /// <param name="navItem">The database navigation item to copy the details from.</param>
        public NavItem( DomainNavigationItem navItem )
        {
            PageId = navItem.PageId;
            Title = navItem.Title;

            SubItems = navItem.SubNavigationItems.Where( s => s.IsDeleted == false ).Select( s => new NavItem( s ) ).ToList();
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

        /// <summary>
        /// Gets the Page Id to navigate to.
        /// </summary>
        public int PageId { get; private set; }

        /// <summary>
        /// Gets the display title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets any child navigation items.
        /// </summary>
        public List<NavItem> SubItems { get; private set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
