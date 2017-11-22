using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Admin.Managers
{
    public class PageManager : ContentManagementSystem.Managers.PageManager
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
        /// Gets the model to use for the admin page model.
        /// </summary>
        public PageModel GetPageModel( int? pageId )
        {
            ContentManagementDb db = new ContentManagementDb();

            Page page = db.Pages.Find( pageId );

            if ( page == null )
            {
                PageModel model = new PageModel();

                model.ModelType = "Default";
                model.PageTemplateModel = new Framework.Models.Page.Default();

                CachedEditableModel cachedModel = CMSCache.Pages[ model.ModelType ];

                model.PageTemplateModel.DisplayLocation = cachedModel.DisplayLocation;
                model.PageTemplateModel.EditorLocation = cachedModel.EditorLocation;

                return model;
            }

            return new PageModel( page, this );
        }
        
        /// <summary>
        /// Saves the page model into the database.
        /// </summary>
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

        /// <summary>
        /// Creates a new row in the database.
        /// </summary>
        private SaveResult CreatePage( PageModel model, ContentManagementDb db )
        {
            try
            {
                Page page = db.Pages.AddNew();
                page.Initialise();
                page.PageContent = new List<PageContent>();

                AutoMap.Map( model, page );

                page.CreatedByUserId = UserSession.Current.UserId;
                page.DomainId = UserSession.Current.DomainId;

                PageContent pageContent = new PageContent();

                AutoMap.Map( model, pageContent );

                UpdateWithPageModel( pageContent, model );

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

        /// <summary>
        /// Updates an existing row in the database.
        /// </summary>
        private SaveResult UpdatePage( Page page, PageModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false ) return SaveResult.AccessDenied;

            if ( UserSession.Current.CurrentDomain().CanAccess( page ) == false ) return SaveResult.IncorrectDomain;

            try
            {
                PageContent pageContent = page.PageContent.FirstOrDefault( s => s.PublishStatus == PublishStatus.Draft );

                if ( pageContent == null )
                {
                    pageContent = new PageContent();
                    page.PageContent.Add( pageContent );
                }

                AutoMap.Map( model, pageContent );

                UpdateWithPageModel( pageContent, model );

                page.UpdateTimeStamp();
                pageContent.UpdateTimeStamp();
                pageContent.LastEditedByUserId = UserSession.Current.UserId;

                SetPublishStatus( page, pageContent, model.Publish );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch( Exception ex )
            {
                ErrorLog.Error( "Could not update page", ex );
                return SaveResult.Fail;
            }
        }
    
        /// <summary>
        /// Updates the page content with the page model template.
        /// </summary>
        private void UpdateWithPageModel( PageContent pageContent, PageModel pageModel )
        {
            pageContent.ModelType = pageModel.ModelType;

            pageModel.PageTemplateModel.OnBeforeSave();

            pageContent.Content = JsonConvert.SerializeObject( pageModel.PageTemplateModel );
        }

        /// <summary>
        /// Sets the publish status for the entity.
        /// </summary>
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