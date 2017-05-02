using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Forces the controller action to require the current user to have one of the specified roles.
    /// </summary>
    public class AuthorizationAttribute : AuthorizeAttribute
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private Role[] _authorizedRoles;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates an authorization attribute where all roles are authorized, however a login is still required.
        /// </summary>
        public AuthorizationAttribute()
        {
            this._authorizedRoles = null;
        }

        /// <summary>
        /// Creates an authorization attribute where only specified roles have access to the action. Login is still required.
        /// </summary>
        /// <param name="authorizedRoles">The roles that allow access to this action.</param>
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

        /// <summary>
        /// Checks if there is a logged in user and if the user role is valid.
        /// </summary>
        /// <param name="httpContext">The current http context.</param>
        /// <returns>True if the user is logged in and has the role required, otherwise false.</returns>
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
