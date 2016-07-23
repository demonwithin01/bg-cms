using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role.Data[] { Role.Data.Administrator } )]
    public class PageController : AdminContentManagementController<PageManager>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        public ActionResult List()
        {
            return View( new PageListModel( UserSession.Current.DomainId, base.Database ) );
        }

        public ActionResult Create()
        {
            return View( "Edit", base.Manager.GetPageModel( null ) );
        }

        [HttpPost]
        public ActionResult Create( PageModel model )
        {
            SaveResult result = UpdatePageModel( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "List" );
            }

            return View( "Edit", model );
        }

        public ActionResult Edit( int id )
        {
            return View( base.Manager.GetPageModel( id ) );
        }

        [HttpPost]
        public ActionResult Edit( PageModel model )
        {
            SaveResult result = UpdatePageModel( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "List" );
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

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private SaveResult UpdatePageModel( PageModel model )
        {
            CachedEditableModel cachedModel = CMSCache.Pages[ model.ModelType ];

            model.PageTemplateModel = cachedModel.GetPageModel( this );

            return base.Manager.SavePage( model );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
