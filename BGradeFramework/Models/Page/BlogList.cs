using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.Page
{
    [EditorLocation( "~/Areas/Admin/Views/Page/Templates/BlogList.cshtml" )]
    [DisplayLocation( "~/Areas/Home/Views/Page/Templates/BlogList.cshtml" )]
    public class BlogList : PageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public BlogList()
        {
            base.HideBackgroundColor = true;

            this.MaxNumberOfPosts = 5;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void InitialiseForDisplay()
        {
            ContentManagementDb db = new ContentManagementDb();

            int pageNumber = 0;

            if ( base.Request.QueryString.AllKeys.Contains( "page" ) && int.TryParse( base.Request.QueryString[ "page" ], out pageNumber ) )
            {
                if ( pageNumber < 1 )
                {
                    pageNumber = 1;
                }

                --pageNumber;
            }

            var query = db.BlogPostContent.Include( s => s.Blog )
                                          .Include( s => s.PublishedByUser )
                                          .Where( s => s.PublishStatus == PublishStatus.Published && s.Blog.DomainId == UserSession.Current.DomainId && s.Blog.IsDeleted == false )
                                          .OrderByDescending( s => s.Blog.UTCDateCreated )
                                          .Skip( pageNumber * this.MaxNumberOfPosts );

            this.PageNumberIndex = pageNumber;
            this.HasPreviousPage = ( pageNumber > 0 );
            this.HasNextPage = query.Count() > this.MaxNumberOfPosts;

            this.BlogPosts = query.Take( this.MaxNumberOfPosts )
                                  .ToList();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public int MaxNumberOfPosts { get; set; }

        [JsonIgnore]
        public int PageNumberIndex { get; set; }
        
        [JsonIgnore]
        public bool HasNextPage { get; set; }

        [JsonIgnore]
        public bool HasPreviousPage { get; set; }

        [JsonIgnore]
        public List<BlogPostContent> BlogPosts { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
