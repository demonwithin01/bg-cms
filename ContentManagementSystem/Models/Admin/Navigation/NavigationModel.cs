using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class NavigationModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private int _domainId;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public NavigationModel()
        {
            _domainId = UserSession.Current.DomainId;
        }

        public NavigationModel( DomainNavigationItem navItem )
            : this()
        {
            AutoMap.Map( navItem, this );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public SelectList GetAvailablePages()
        {
            ContentManagementDb db = new ContentManagementDb();

            List<PageContent> pages = db.Pages.Include( s => s.PageContent )
                                              .Where( s => s.DomainId == _domainId && s.IsDeleted == false )
                                              .SelectMany( s => s.PageContent )
                                              .Where( s => s.PublishStatus != PublishStatus.Deleted && s.PublishStatus != PublishStatus.OutOfDate )
                                              .ToList();

            List<int> pageIds = pages.Select( s => s.PageId ).ToList();

            List<PageContent> displayPages = pages.Where( s => pageIds.Contains( s.PageId ) && s.PublishStatus == PublishStatus.Published ).ToList();

            List<int> usedPageIds = displayPages.Select( s => s.PageId ).ToList();
            pageIds.RemoveAll( s => usedPageIds.Contains( s ) );

            displayPages.AddRange( pages.Where( s => pageIds.Contains( s.PageId ) && s.PublishStatus == PublishStatus.Draft ) );

            return new SelectList( displayPages, "PageId", "Title", PageId );
        }

        public SelectList GetRootNavItems()
        {
            ContentManagementDb db = new ContentManagementDb();

            List<DomainNavigationItem> navItems = db.DomainNavigationItems.Where( s => s.DomainId == _domainId && s.IsDeleted == false && s.ParentDomainNavigationItemId == null ).ToList();

            return new SelectList( navItems, "DomainNavigationItemId", "Title", ParentDomainNavigationItemId );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public int? DomainNavigationItemId { get; set; }

        [Display( Name = "Page:" )]
        public int PageId { get; set; }

        [Display( Name = "Title:" )]
        public string Title { get; set; }

        [Display( Name = "Parent" )]
        public int? ParentDomainNavigationItemId { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}