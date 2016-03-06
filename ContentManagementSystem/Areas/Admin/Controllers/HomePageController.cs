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

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role.Data[] { Role.Data.Administrator } )]
    public class HomePageController : AdminContentManagementController<NavigationManager>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions
            
        public ViewResult Edit( int? navItemId )
        {
            return View( base.Manager.GetNavigationModel( navItemId ) );
        }

        [HttpPost]
        public ActionResult Edit( NavigationModel model )
        {
            SaveResult result = base.Manager.SaveNavigationItem( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "Index" );
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
