using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class NavigationListItemModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public NavigationListItemModel()
        {

        }

        public NavigationListItemModel( DomainNavigationItem navItem )
        {
            AutoMap.Map( navItem, this );

            IEnumerable<PageContent> pages = navItem.Page.PageContent;

            this.PageTitle = ( ( pages.FirstOrDefault( s => s.PublishStatus == PublishStatus.Published ) ??
                                 pages.FirstOrDefault( s => s.PublishStatus == PublishStatus.Draft ) )?.Title ) ?? "[Not set]";

            if ( navItem.SubNavigationItems != null && navItem.SubNavigationItems.Count > 0 )
            {
                this.Children = new List<NavigationListItemModel>();

                foreach ( DomainNavigationItem subItem in navItem.SubNavigationItems )
                {
                    this.Children.Add( new NavigationListItemModel( subItem ) );
                }

                this.Children = this.Children.OrderBy( s => s.Ordinal ).ToList();
            }
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

        public int DomainNavigationItemId { get; set; }

        public int Ordinal { get; set; }

        public string Title { get; set; }

        public string PageTitle { get; set; }

        public List<NavigationListItemModel> Children { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}