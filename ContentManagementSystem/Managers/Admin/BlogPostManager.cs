using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class BlogPostManager
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
        /// Gets the blog post from the database.
        /// </summary>
        public BlogPostModel GetBlogPostModel( int? blogPostId )
        {
            if ( blogPostId.HasValue == false ) return new BlogPostModel();

            ContentManagementDb db = new ContentManagementDb();

            BlogPost blogPost = db.Blogs.Find( blogPostId );

            if ( blogPost == null ) return new BlogPostModel();

            return new BlogPostModel( blogPost );
        }

        /// <summary>
        /// Saves the blog post into the database.
        /// </summary>
        public SaveResult SaveBlogPost( BlogPostModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            BlogPost blog = db.Blogs.Find( model.BlogId );

            if ( blog == null )
            {
                return CreateBlog( model, db );
            }

            return UpdateBlog( blog, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Creates a new row in the database.
        /// </summary>
        private SaveResult CreateBlog( BlogPostModel model, ContentManagementDb db )
        {
            try
            {
                BlogPost blog = db.Blogs.AddNew();
                blog.Initialise();

                blog.BlogPostContent = new List<BlogPostContent>();

                AutoMap.Map( model, blog );

                blog.CreatedByUserId = UserSession.Current.UserId;
                blog.DomainId = UserSession.Current.DomainId;

                BlogPostContent blogContent = new BlogPostContent();

                AutoMap.Map( model, blogContent );
                blog.BlogPostContent.Add( blogContent );

                blogContent.Initialize();

                blogContent.LastEditedByUserId = blog.CreatedByUserId;

                SetPublishStatus( blog, blogContent, model.Publish );
                
                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        /// <summary>
        /// Updates an existing row in the database.
        /// </summary>
        private SaveResult UpdateBlog( BlogPost blog, BlogPostModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false ) return SaveResult.AccessDenied;

            if ( UserSession.Current.CurrentDomain().CanAccess( blog ) == false ) return SaveResult.IncorrectDomain;

            try
            {
                BlogPostContent pageContent = blog.BlogPostContent.FirstOrDefault( s => s.PublishStatus == PublishStatus.Draft );

                if ( pageContent == null )
                {
                    pageContent = new BlogPostContent();
                    blog.BlogPostContent.Add( pageContent );
                }

                AutoMap.Map( model, pageContent );
                blog.UpdateTimeStamp();
                pageContent.UpdateTimeStamp();
                pageContent.LastEditedByUserId = UserSession.Current.UserId;

                SetPublishStatus( blog, pageContent, model.Publish );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        /// <summary>
        /// Sets the publish status for the entity.
        /// </summary>
        private void SetPublishStatus( BlogPost page, BlogPostContent pageContent, bool publish )
        {
            if ( publish )
            {
                page.BlogPostContent.Where( s => s.BlogContentId != pageContent.BlogContentId && ( s.PublishStatus == PublishStatus.Draft || s.PublishStatus == PublishStatus.Published ) ).ToList().ForEach( s => s.PublishStatus = PublishStatus.OutOfDate );
                pageContent.PublishStatus = PublishStatus.Published;

                pageContent.PublishedByUserId = pageContent.PublishedByUserId ?? UserSession.Current.UserId;
                pageContent.PublishedUTCDate = pageContent.PublishedUTCDate ?? DateTime.UtcNow;
            }
            else
            {
                page.BlogPostContent.Where( s => s.BlogContentId != pageContent.BlogContentId && s.PublishStatus == PublishStatus.Draft ).ToList().ForEach( s => s.PublishStatus = PublishStatus.Deleted );
                pageContent.PublishStatus = PublishStatus.Draft;
                pageContent.PublishedByUserId = null;
                pageContent.PublishedUTCDate = null;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}