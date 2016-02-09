using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class BlogPostListItemModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public BlogPostListItemModel( BlogPost blogPost )
        {
            BlogPostContent blogPostContent = blogPost.BlogPostContent.OrderByDescending( s => s.UTCDateUpdated ).First();

            BlogPostId = blogPost.BlogId;
            Title = blogPostContent.Title;

            LastEditedByName = blogPostContent.LastEditedByUser.UserName;
            DateUpdated = blogPostContent.UTCDateUpdated.ToLocalTime();

            bool isPublished = blogPost.BlogPostContent.Count( s => s.PublishStatus == PublishStatus.Published ) > 0;
            bool hasDraft = blogPost.BlogPostContent.Count( s => s.PublishStatus == PublishStatus.Draft ) > 0;

            if ( isPublished && hasDraft )
            {
                PageStatus = "Published / Draft Pending";
            }
            else if ( isPublished )
            {
                PageStatus = "Published";
            }
            else if ( hasDraft )
            {
                PageStatus = "Draft Pending";
            }
            else
            {
                PageStatus = "Not Published, No Draft";
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

        public int BlogPostId { get; set; }

        public string Title { get; set; }

        public DateTime DateUpdated { get; set; }

        public string PageStatus { get; set; }

        public string LastEditedByName { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}