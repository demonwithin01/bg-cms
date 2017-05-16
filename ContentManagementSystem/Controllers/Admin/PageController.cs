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

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        [Route( "page/list" )]
        public ActionResult PageList()
        {
            return View( new PageListModel( UserSession.Current.DomainId, base.Database ) );
        }
        
        [Route( "page/create" )]
        [Route( "page/edit/{id}" )]
        public ActionResult PageEdit( int? id = null )
        {
            PageManager manager = new PageManager();

            PageModel model = manager.GetPageModel( id );

            if( model.PageTemplateModel != null )
            {
                model.PageTemplateModel.InitialiseForEditor();
            }

            return View( model );
        }

        [HttpPost]
        [Route( "page/create" )]
        [Route( "page/edit/{id}" )]
        public ActionResult PageEdit( PageModel model )
        {
            CachedEditableModel cachedModel = CMSCache.Pages[ model.ModelType ];

            model.PageTemplateModel = cachedModel.GetPageModel( this );

            PageManager manager = new PageManager();

            SaveResult result = manager.SavePage( model );

            if( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "PageList" );
            }

            return View( model );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

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