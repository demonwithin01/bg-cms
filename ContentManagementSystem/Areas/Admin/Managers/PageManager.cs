using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class PageManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public PageModel GetPageModel( int? pageId )
        {
            ContentManagementDb db = new ContentManagementDb();

            Page page = db.Pages.Find( pageId );

            if ( page == null ) return new PageModel();

            return new PageModel( page );
        }
        
        public SaveResult SavePage( PageModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            Page page = db.Pages.Find( model.PageId );

            if ( page == null )
            {
                return CreatePage( model, db );
            }

            return UpdatePage( page, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private SaveResult CreatePage( PageModel model, ContentManagementDb db )
        {
            try
            {
                Page page = db.Pages.CreateAdd();
                page.Initialise();
                page.PageContent = new List<PageContent>();

                AutoMap.Map( model, page );

                page.CreatedByUserId = UserSession.Current.UserId;
                page.DomainId = UserSession.Current.DomainId;

                PageContent pageContent = new PageContent();

                AutoMap.Map( model, pageContent );
                page.PageContent.Add( pageContent );

                pageContent.Initialize();

                pageContent.LastEditedByUserId = page.CreatedByUserId;

                SetPublishStatus( page, pageContent, model.Publish );
                
                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        private SaveResult UpdatePage( Page page, PageModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false ) return SaveResult.AccessDenied;

            if ( UserSession.Current.CurrentDomain( db ).CanAccess( page ) == false ) return SaveResult.IncorrectDomain;

            try
            {
                PageContent pageContent = page.PageContent.FirstOrDefault( s => s.PublishStatus == PublishStatus.Draft );

                if ( pageContent == null )
                {
                    pageContent = new PageContent();
                    page.PageContent.Add( pageContent );
                }

                AutoMap.Map( model, pageContent );
                page.UpdateTimeStamp();
                pageContent.UpdateTimeStamp();
                pageContent.LastEditedByUserId = UserSession.Current.UserId;

                SetPublishStatus( page, pageContent, model.Publish );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        private void SetPublishStatus( Page page, PageContent pageContent, bool publish )
        {
            if ( publish )
            {
                page.PageContent.Where( s => s.PageContentId != pageContent.PageContentId && ( s.PublishStatus == PublishStatus.Draft || s.PublishStatus == PublishStatus.Published ) ).ToList().ForEach( s => s.PublishStatus = PublishStatus.OutOfDate );
                pageContent.PublishStatus = PublishStatus.Published;
            }
            else
            {
                page.PageContent.Where( s => s.PageContentId != pageContent.PageContentId && s.PublishStatus == PublishStatus.Draft ).ToList().ForEach( s => s.PublishStatus = PublishStatus.Deleted );
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