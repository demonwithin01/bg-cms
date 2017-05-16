using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.Framework;

namespace ContentManagementSystem.Controllers
{
    public partial class AdminController
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        [Route( "blog-post/list" )]
        public ActionResult BlogPostList()
        {
            return View( new BlogPostListModel( UserSession.Current.DomainId, base.Database ) );
        }

        [Route( "blog-post/create" )]
        [Route( "blog-post/edit/{blogPostId}" )]
        public ActionResult Edit( int? blogPostId = null )
        {
            BlogPostManager manager = new BlogPostManager();

            return View( manager.GetBlogPostModel( blogPostId ) );
        }

        [HttpPost]
        [Route( "blog-post/create" )]
        [Route( "blog-post/edit/{blogPostId}" )]
        public ActionResult Edit( BlogPostModel model )
        {
            BlogPostManager manager = new BlogPostManager();

            SaveResult result = manager.SaveBlogPost( model );

            if( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "BlogPostList" );
            }

            return View( model );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}