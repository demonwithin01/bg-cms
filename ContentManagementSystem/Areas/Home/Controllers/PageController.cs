﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystemDatabase;
using ContentManagementSystem.Models.Page;
using ContentManagementSystem.Managers;

namespace ContentManagementSystem.Home.Controllers
{
    public class PageController : ContentManagementController
    {
        public ActionResult Index( int? pageId )
        {
            Page page = base.Database.Pages.Find( pageId );
            
            if ( page == null )
            {
                throw new HttpException( 404, "The page requested could not be found" );
            }

            bool loadDefaultPage = true;

            PageContent pageContent = null;

            if ( Request.QueryString.AllKeys.Contains( "draft" ) )
            {
                bool isDraft;

                if ( bool.TryParse( Request.QueryString[ "draft" ], out isDraft ) && isDraft )
                {
                    if ( UserSession.Current.IsAdministrator )
                    {
                        pageContent = page.PageContent.FirstOrDefault( (Func<PageContent, bool>)(s => s.PublishStatus == PublishStatus.Draft) );

                        loadDefaultPage = ( pageContent == null );
                    }
                }
            }

            if ( loadDefaultPage )
            {
                pageContent = page.PageContent.FirstOrDefault( (Func<PageContent, bool>)(s => s.PublishStatus == PublishStatus.Published) );
            }

            if ( pageContent == null || ( page.RequiresLogin && Request.IsAuthenticated == false ) )
            {
                throw new HttpException( 404, "The page requested could not be found" );
            }

            PageManager manager = new PageManager();
            //TODO: Refactor Manager instance.
            PageTemplate pageTemplate = manager.RetrievePage( pageContent );
            pageTemplate.InitialiseForDisplay();

            return View( new IndexModel( pageContent, pageTemplate ) );
        }

    }
}
