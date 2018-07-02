using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ContentManagementSystemDatabase;

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
        public static List<SelectListItem> NavPages( int? selected, string prepend = "" )
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            if ( string.IsNullOrEmpty( prepend ) == false )
            {
                prepend = prepend.Trim() + " ";
            }

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
                            Text = prepend + subItem.Title,
                            Value = subItem.PageId.ToString(),
                            Selected = subItem.PageId == selected,
                            Group = group
                        } );
                    }
                }
            }

            return selectList;
        }

        /// <summary>
        /// Creates a select list of the navigation pages.
        /// </summary>
        /// <param name="selected">The currently selected navigation page id.</param>
        public static List<SelectListItem> Pages( int? selected )
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            ContentManagementDb db = new ContentManagementDb();

            List<IGrouping<int, PageContent>> pages = db.PageContent.Where( s => s.Page.DomainId == UserCookie.Current.DomainId && ( s.PublishStatus == PublishStatus.Published || s.PublishStatus == PublishStatus.Draft ) )
                                        .GroupBy( s => s.PageId )
                                        .ToList();

            foreach ( IGrouping<int, PageContent> page in pages )
            {
                PageContent pageContent = page.FirstOrDefault( s => s.PublishStatus == PublishStatus.Published );
                if ( pageContent == null )
                {
                    pageContent = page.First();
                }

                selectList.Add( new SelectListItem()
                {
                    Text = pageContent.Title,
                    Value = pageContent.PageId.ToString(),
                    Selected = pageContent.PageId == selected
                } );
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
