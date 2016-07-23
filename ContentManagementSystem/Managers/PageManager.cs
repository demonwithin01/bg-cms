using ContentManagementSystem.Framework;
using ContentManagementSystem.Framework.Models.Page;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Managers
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

        public PageTemplate RetrievePage( int pageId, PublishStatus status )
        {
            string name;

            return RetrievePage( pageId, status, out name );
        }

        public PageTemplate RetrievePage( PageContent pageContent )
        {
            string name;

            return RetrievePage( pageContent, out name );
        }

        public PageTemplate RetrievePage( int pageId, PublishStatus status, out string name )
        {
            ContentManagementDb db = new ContentManagementDb();
            Page entity = db.Pages.Include( s => s.PageContent ).FirstOrDefault( s => s.PageId == pageId );
            
            return RetrievePage( entity, status, out name );
        }

        public PageTemplate RetrievePage( Page pageEntity, PublishStatus status, out string name )
        {
            name = "Not Found";

            if ( pageEntity == null )
            {
                return null;
            }

            PageContent pageContent = pageEntity.PageContent.FirstOrDefault( s => s.PublishStatus == status );

            if ( pageContent == null )
            {
                return null;
            }

            return RetrievePage( pageContent, out name );
        }

        public PageTemplate RetrievePage( PageContent pageContent, out string name )
        {
            name = "Not Found";
            
            if ( pageContent == null )
            {
                return null;
            }

            PageTemplate page;
            CachedEditableModel cachedModel;

            if ( pageContent.ModelType == "" )
            {
                page = new Default();
                ( page as Default ).PageContent = pageContent.Content;

                name = "Default";
                cachedModel = CMSCache.Pages[ name ];
            }
            else
            {
                name = pageContent.ModelType;

                cachedModel = CMSCache.Pages[ pageContent.ModelType ];

                page = JsonConvert.DeserializeObject( pageContent.Content, cachedModel.ModelType ) as PageTemplate;
            }
            
            page.DisplayLocation = cachedModel.DisplayLocation;
            page.EditorLocation = cachedModel.EditorLocation;

            return page;
        }

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