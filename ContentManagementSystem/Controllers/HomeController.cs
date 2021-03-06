﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Managers;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Models.Home;
using ContentManagementSystemDatabase;
using WebMatrix.WebData;

namespace ContentManagementSystem.Controllers
{
    [RouteArea( "" )]
    public class HomeController : ContentManagementController
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        /// <summary>
        /// GET: /
        /// </summary>
        [Route( "" )]
        public ActionResult Index()
        {
            IndexModel model = new IndexModel();

            HomePageManager manager = new HomePageManager();
            model.HomePageTemplateModel = manager.RetrieveHomePage();
            model.Title = UserCookie.Current.SiteName;

            model.HomePageTemplateModel.PrepareForDisplay();

            return View( model );
        }

        [Route( "page/{pageId}" )]
        public ActionResult Page( int? pageId )
        {
            Page page = base.Database.Pages.Find( pageId );

            if( page == null )
            {
                throw new HttpException( 404, "The page requested could not be found" );
            }

            bool loadDefaultPage = true;

            PageContent pageContent = null;

            if( Request.QueryString.AllKeys.Contains( "draft" ) )
            {
                bool isDraft;

                if( bool.TryParse( Request.QueryString[ "draft" ], out isDraft ) && isDraft )
                {
                    if( UserSession.Current.IsAdministrator )
                    {
                        pageContent = page.PageContent.FirstOrDefault( (Func<PageContent, bool>)( s => s.PublishStatus == PublishStatus.Draft ) );

                        loadDefaultPage = ( pageContent == null );
                    }
                }
            }

            if( loadDefaultPage )
            {
                pageContent = page.PageContent.FirstOrDefault( (Func<PageContent, bool>)( s => s.PublishStatus == PublishStatus.Published ) );
            }

            if( pageContent == null || ( page.RequiresLogin && Request.IsAuthenticated == false ) )
            {
                throw new HttpException( 404, "The page requested could not be found" );
            }

            PageManager manager = new PageManager();
            PageTemplate pageTemplate = manager.RetrievePage( pageContent );
            pageTemplate.InitialiseForDisplay();

            return View( new PageModel( pageContent, pageTemplate ) );
        }

        [AllowAnonymous]
        [Route( "login" )]
        [Route( "home/account/login" )]
        public ActionResult Login( string returnUrl )
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route( "login" )]
        [Route( "home/account/login" )]
        [ValidateAntiForgeryToken]
        public ActionResult Login( LoginModel model, string returnUrl )
        {
            if( ModelState.IsValid && WebSecurity.Login( model.UserName, model.Password, persistCookie: model.RememberMe ) )
            {
                int userId = WebSecurity.GetUserId( model.UserName );
                ContentManagementDb db = new ContentManagementDb();

                UserProfile user = db.Users.FirstOrDefault( u => u.UserId == userId );
                user.LastLogin = DateTime.Now;
                db.SaveChangesAsync();
                UserCookie.CreateInstance( user, HttpContext );

                return RedirectToLocal( returnUrl );
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError( "", "The user name or password provided is incorrect." );
            return View( model );
        }

        [HttpPost]
        [Route( "logoff" )]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            UserCookie.CreateInstance( null, HttpContext );

            return Redirect( "/" );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private ActionResult RedirectToLocal( string returnUrl )
        {
            if( Url.IsLocalUrl( returnUrl ) )
            {
                return Redirect( returnUrl );
            }
            else
            {
                return RedirectToAction( "Index", "Home" );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}