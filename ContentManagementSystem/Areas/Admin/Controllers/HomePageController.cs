using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystemDatabase;
using ContentManagementSystem.Framework.Models.HomePage;

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role.Data[] { Role.Data.Administrator } )]
    public class HomePageController : AdminContentManagementController<HomePageManager>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions
            
        public ViewResult Edit()
        {
            return View( base.Manager.GetHomePageModel() );
        }

        [HttpPost]
        public ActionResult Edit( HomePageModel model )
        {
            CachedEditableModel cachedModel = CMSCache.HomePages[ model.HomePageTemplate ];
            
            model.HomePageTemplateModel = cachedModel.GetHomePageModel( this );
            
            if ( model.HomePageTemplateModel != null )
            {
                SaveResult result = base.Manager.SaveHomePageModel( model );

                if ( result.State == SaveResultState.Success )
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

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

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
