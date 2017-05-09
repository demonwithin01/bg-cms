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

        [Route( "home-page/edit" )]
        public ViewResult EditHomePage()
        {
            HomePageManager manager = new HomePageManager();
            return View( manager.GetHomePageModel() );
        }

        [HttpPost]
        [Route( "home-page/edit" )]
        public ActionResult EditHomePage( HomePageModel model )
        {
            CachedEditableModel cachedModel = CMSCache.HomePages[ model.HomePageTemplate ];

            model.HomePageTemplateModel = cachedModel.GetHomePageModel( this );

            if( model.HomePageTemplateModel != null )
            {
                HomePageManager manager = new HomePageManager();
                SaveResult result = manager.SaveHomePageModel( model );

                if( result.State == SaveResultState.Success )
                {
                    return RedirectToAction( "Index", "Home" );
                }
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