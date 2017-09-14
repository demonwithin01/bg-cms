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

        [Route( "users/list" )]
        public ActionResult UsersList()
        {
            return View( new UsersListModel( UserSession.Current.DomainId, base.Database ) );
        }

        [Route( "users/edit/{userId}" )]
        public ActionResult UsersEdit( int userId )
        {
            UserManager manager = new UserManager();
            UserModel model = manager.GetUserModel( userId );

            return View( model );
        }

        [HttpPost]
        [Route( "users/edit/{userId}" )]
        public ActionResult UsersEdit( UserModel model )
        {
            UserManager manager = new UserManager();
            SaveResult result = manager.UpdateUser( model );

            if( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "UsersList" );
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