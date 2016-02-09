using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class BlogManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public BlogPostModel GetBlogPostModel( int? pageId )
        {
            ContentManagementDb db = new ContentManagementDb();

            Page page = db.Pages.Find( pageId );

            if ( page == null ) return new BlogPostModel();

            return new BlogPostModel( page );
        }
        
        public SaveResult SaveBlogPost( BlogPostModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            Blog blog = db.Blogs.Find( model.PageId );

            if ( blog == null )
            {
                return CreateBlog( model, db );
            }

            return UpdateBlog( blog, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private SaveResult CreateBlog( BlogPostModel model, ContentManagementDb db )
        {
            try
            {
                Blog blog = new Blog();
                blog.Initialise();

                AutoMap.Map( model, blog );

                blog.CreatedByUserId = UserSession.Current.UserId;
                blog.DomainId = UserSession.Current.DomainId;

                BlogContent blogContent = new BlogContent();

                AutoMap.Map( model, blogContent );
                blog.BlogContent.Add( blogContent );

                blogContent.Initialize();

                blogContent.LastEditedByUserId = blog.CreatedByUserId;

                SetPublishStatus( blog, blogContent, model.Publish );

                db.Blogs.Add( blog );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        private SaveResult UpdateBlog( Blog blog, BlogPostModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false ) return SaveResult.AccessDenied;

            if ( UserSession.Current.CurrentDomain( db ).CanAccess( blog ) == false ) return SaveResult.IncorrectDomain;

            try
            {
                BlogContent pageContent = blog.BlogContent.FirstOrDefault( s => s.PublishStatus == PublishStatus.Draft );

                if ( pageContent == null )
                {
                    pageContent = new BlogContent();
                    blog.BlogContent.Add( pageContent );
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

        private void SetPublishStatus( Blog page, BlogContent pageContent, bool publish )
        {
            if ( publish )
            {
                page.BlogContent.Where( s => s.BlogContentId != pageContent.BlogContentId && ( s.PublishStatus == PublishStatus.Draft || s.PublishStatus == PublishStatus.Published ) ).ToList().ForEach( s => s.PublishStatus = PublishStatus.OutOfDate );
                pageContent.PublishStatus = PublishStatus.Published;
            }
            else
            {
                page.BlogContent.Where( s => s.BlogContentId != pageContent.BlogContentId && s.PublishStatus == PublishStatus.Draft ).ToList().ForEach( s => s.PublishStatus = PublishStatus.Deleted );
                pageContent.PublishStatus = PublishStatus.Draft;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}