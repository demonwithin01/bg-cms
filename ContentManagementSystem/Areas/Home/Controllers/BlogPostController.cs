using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystem.Models.Page;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Home.Controllers
{
    public class BlogPostController : BaseController
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ActionResult Index( int blogPostId )
        {
            BlogPostContent blogPost = base.Database.BlogPostContent.Include( s => s.Blog ).Include( s => s.PublishedByUser ).FirstOrDefault( s => s.BlogId == blogPostId );

            if ( blogPost == null || blogPost.Blog.IsDeleted || blogPost.Blog.DomainId != UserSession.Current.DomainId )
            {
                throw new HttpException( 404, "The page requested could not be found" );
            }

            if ( blogPost.PublishStatus != PublishStatus.Published && UserSession.Current.IsAdministrator )
            {
                throw new HttpException( 404, "The page requested could not be found" );
            }

            return View( new BlogPostModel( blogPost ) );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

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