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

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void Execute()
        {
               
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

                return "Need to add site name";
            }
            set
            {
                TempData[ "PageTitle" ] = value;
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
