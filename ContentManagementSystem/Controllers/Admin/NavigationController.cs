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

        [Route( "navigation/list" )]
        public ViewResult NavigationList()
        {
            return View( new NavigationListModel( UserSession.Current.DomainId, base.Database ) );
        }
        
        [Route( "navigation/create" )]
        [Route( "navigation/edit/{navItemId}" )]
        public ViewResult NavigationEdit( int? navItemId = null )
        {
            NavigationManager manager = new NavigationManager();

            return View( manager.GetNavigationModel( navItemId ) );
        }

        [HttpPost]
        [Route( "navigation/create" )]
        [Route( "navigation/edit/{navItemId}" )]
        public ActionResult NavigationEdit( NavigationModel model )
        {
            NavigationManager manager = new NavigationManager();

            SaveResult result = manager.SaveNavigationItem( model );

            if( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "NavigationList" );
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