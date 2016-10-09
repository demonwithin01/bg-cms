using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework.BaseClasses
{
    
    public class PageModel<T> : WebViewPage<T>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private UserProfile _userProfile;

        private string hideSocialButtons = "HideSocialButtons";

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void Execute()
        {
               
        }

        /// <summary>
        /// Evalulates a condition and returns whether or not to render the specified html.
        /// </summary>
        /// <param name="condition">The condition to be evaluated</param>
        /// <param name="html">The html to be rendered</param>
        public IHtmlString If( bool condition, string html )
        {
            if ( condition )
            {
                return Html.Raw( html );
            }

            return Html.Raw( "" );
        }

        /// <summary>
        /// Evalulates a condition and returns whether or not to render the specified html or the alternate html.
        /// </summary>
        /// <param name="condition">The condition to be evaluated</param>
        /// <param name="html">The html to be rendered</param>
        /// <param name="alternateHtml">The alternate html to be rendered</param>
        public IHtmlString If( bool condition, string html, string alternateHtml )
        {
            if ( condition )
            {
                return Html.Raw( html );
            }

            return Html.Raw( alternateHtml );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public string PageTitle
        { 
            get
            {
                object pageTitle = TempData[ "PageTitle" ];
                if ( pageTitle != null ) return pageTitle.ToString();

                return UserCookie.Current.SiteName;
            }
            set
            {
                TempData[ "PageTitle" ] = value;
            }
        }

        public bool HideTitle
        {
            get
            {
                if ( TempData.ContainsKey( "HideTitle" ) ) return (bool)TempData[ "HideTitle" ];

                return false;
            }
            set
            {
                TempData[ "HideTitle" ] = value;
            }
        }

        public bool HideSocialButtons
        {
            get
            {
                if ( TempData.ContainsKey( hideSocialButtons ) ) return (bool)TempData[ hideSocialButtons ];

                return false;
            }
            set
            {
                TempData[ hideSocialButtons ] = value;
            }
        }

        public bool UseFullWidth
        {
            get
            {
                if ( TempData.ContainsKey( "UseFullWidth" ) ) return (bool)TempData[ "UseFullWidth" ];

                return false;
            }
            set
            {
                TempData[ "UseFullWidth" ] = value;
            }
        }

        public bool IsHomePage
        {
            get
            {
                if ( TempData.ContainsKey( "IsHomePage" ) ) return (bool)TempData[ "IsHomePage" ];

                return false;
            }
            set
            {
                TempData[ "IsHomePage" ] = value;
            }
        }

        public UserProfile UserProfile
        {
            get
            {
                if ( _userProfile == null )
                {
                    _userProfile = new ContentManagementDb().Users.FirstOrDefault( u => u.UserName == HttpContext.Current.User.Identity.Name );
                }

                return _userProfile;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }

}
