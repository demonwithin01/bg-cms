﻿using System;
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

        private Role[] _authorizedRoles;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public AuthorizationAttribute()
        {
            this._authorizedRoles = null;
        }

        public AuthorizationAttribute( Role[] authorizedRoles )
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
            if ( UserCookie.Current.IsLoggedIn == false ) return false;

            if ( this._authorizedRoles == null ) return true;

            bool authorized = this._authorizedRoles.Contains( UserCookie.Current.Role );

            if ( UserCookie.Current.Role == Role.Administrator && UserSession.Current.Role != Role.Administrator )
            {
                return false;
            }

            return authorized;
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
