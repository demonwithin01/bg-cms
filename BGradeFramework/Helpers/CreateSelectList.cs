using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Provides functionality to generate common select lists.
    /// </summary>
    public static class CreateSelectList
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
        /// Creates a select list of the navigation pages.
        /// </summary>
        /// <param name="selected">The currently selected navigation page id.</param>
        public static List<SelectListItem> NavPages( int? selected )
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            
            foreach ( NavItem navItem in UserCookie.Current.NavItems )
            {
                selectList.Add( new SelectListItem()
                {
                    Text = navItem.Title,
                    Value = navItem.PageId.ToString(),
                    Selected = navItem.PageId == selected
                } );
            }

            foreach ( NavItem navItem in UserCookie.Current.NavItems )
            {
                if ( navItem.SubItems != null && navItem.SubItems.Count > 0 )
                {
                    SelectListGroup group = new SelectListGroup()
                    {
                        Name = navItem.Title
                    };

                    foreach ( NavItem subItem in navItem.SubItems )
                    {
                        selectList.Add( new SelectListItem()
                        {
                            Text = subItem.Title,
                            Value = subItem.PageId.ToString(),
                            Selected = subItem.PageId == selected,
                            Group = group
                        } );
                    }
                }
            }

            return selectList;
        }

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
