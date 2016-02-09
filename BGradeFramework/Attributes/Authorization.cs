using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private Role.Data[] _authorizedRoles;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public AuthorizationAttribute()
        {
            this._authorizedRoles = null;
        }

        public AuthorizationAttribute( Role.Data[] authorizedRoles )
        {
            this._authorizedRoles = authorizedRoles;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        protected override bool AuthorizeCore( HttpContextBase httpContext )
        {
            if ( UserSession.Current.IsLoggedIn == false ) return false;

            if ( this._authorizedRoles == null ) return true;

            Role.Data userRole = (Role.Data)UserSession.Current.CurrentUser().RoleId;

            return ( this._authorizedRoles.Contains( userRole ) );
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
