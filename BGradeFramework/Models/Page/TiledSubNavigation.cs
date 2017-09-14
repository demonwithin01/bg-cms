using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.Page
{
    [EditorLocation( "~/Views/Admin/PageTemplates/TiledSubNavigation.cshtml" )]
    [DisplayLocation( "~/Views/Home/PageTemplates/TiledSubNavigation.cshtml" )]
    public class TiledSubNavigation : PageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private int _domainId;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public TiledSubNavigation()
        {
            base.HideBackgroundColor = true;

            this._domainId = UserSession.Current.DomainId;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void InitialiseForDisplay()
        {
            ContentManagementDb db = new ContentManagementDb();

            this.SubNavigationItems = db.DomainNavigationItems.WhereActive().Where( s => s.DomainId == _domainId && s.IsDeleted == false && s.ParentDomainNavigationItemId == NavigationItemId ).ToList();

            //this.BlogPosts = db.BlogPostContent.Include( s => s.Blog )
            //                                   .Where( s => s.PublishStatus == PublishStatus.Published && s.Blog.DomainId == UserSession.Current.DomainId && s.Blog.IsDeleted == false )
            //                                   .OrderByDescending( s => s.Blog.UTCDateCreated )
            //                                   .Take( this.MaxNumberOfPosts )
            //                                   .ToList();
        }

        public SelectList GetRootNavItems()
        {
            ContentManagementDb db = new ContentManagementDb();

            List<DomainNavigationItem> navItems = db.DomainNavigationItems.Where( s => s.DomainId == _domainId && s.IsDeleted == false && s.ParentDomainNavigationItemId == null ).ToList();

            return new SelectList( navItems, "DomainNavigationItemId", "Title", NavigationItemId );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [DisplayName( "Root Navigation Item" )]
        [Required( ErrorMessage = "Please select a root navigation item" )]
        public int NavigationItemId { get; set; }

        [JsonIgnore]
        public List<DomainNavigationItem> SubNavigationItems { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
