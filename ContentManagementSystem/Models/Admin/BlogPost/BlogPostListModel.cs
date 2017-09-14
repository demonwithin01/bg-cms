using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class BlogPostListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public BlogPostListModel( int domainId, ContentManagementDb db )
        {
            this.BlogPosts = db.Blogs.Where( p => p.DomainId == domainId ).ToList().Select( p => new BlogPostListItemModel( p ) ).ToList();
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

        public List<BlogPostListItemModel> BlogPosts { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}