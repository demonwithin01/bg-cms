using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Helpers
{
    public class SelectListGenerator
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members
            
        #endregion
        
        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public SelectList HomePageTemplates( string selected )
        {
            IEnumerable<CachedEditableModel> cachedModels = CMSCache.HomePages.Select( s => s.Value );

            return new SelectList( cachedModels, "ModelName", "FriendlyName", selected );
        }

        public SelectList PageTemplates( string selected )
        {
            IEnumerable<CachedEditableModel> cachedModels = CMSCache.Pages.Select( s => s.Value );

            return new SelectList( cachedModels, "ModelName", "FriendlyName", selected );
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