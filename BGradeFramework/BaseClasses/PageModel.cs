using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using ContentManagementSystem.Framework.Helpers;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework.BaseClasses
{
    /// <summary>
    /// Provides common functionality to all razor page models.
    /// </summary>
    /// <typeparam name="T">The model type that the page model uses in the view.</typeparam>
    public class PageModel<T> : WebViewPage<T>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        internal class Keys
        {
            internal const string HideSocialButtons = "HideSocialButtons";
            internal const string HideTitle = "HideTitle";
            internal const string IsHomePage = "IsHomePage";
            internal const string PageTitle = "PageTitle";
            internal const string UseFullWidth = "UseFullWidth";
        }

        private UserProfile _userProfile;
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Required by the base type. Does nothing.
        /// </summary>
        public override void Execute()
        {
               
        }

        /// <summary>
        /// Gets the website url as it comes in through the request. If debug mode, the port is included, otherwise it is ignored.
        /// </summary>
        /// <returns>The current website url.</returns>
        public string SiteUrl()
        {
            string url = Request.Url.Scheme + "://" + Request.Url.Host;

#if DEBUG
            url += ":" + Request.Url.Port;
#endif

            return url;
        }

        /// <summary>
        /// Gets the current page url as it comes in through the request.
        /// </summary>
        /// <returns>The current page url.</returns>
        public string PageUrl()
        {
            return SiteUrl() + Request.Url.AbsolutePath;
        }

        /// <summary>
        /// Gets the current page url as it comes in through the request and appends a query string.
        /// </summary>
        /// <param name="queryString">Any query string parameters to be added to the page.</param>
        /// <returns>The current page url.</returns>
        public string PageUrl( string queryString )
        {
            queryString = queryString ?? "";
            
            if ( queryString.Length > 0 && queryString.StartsWith( "?" ) == false )
            {
                queryString = "?" + queryString;
            }

            return PageUrl() + queryString;
        }

        /// <summary>
        /// Gets the current page url as it comes in through the request and appends a query string.
        /// </summary>
        /// <param name="query">The object to create the query string from.</param>
        /// <returns>The current page url.</returns>
        public string PageUrl( object query )
        {
            RouteValueDictionary dict = HtmlHelper.AnonymousObjectToHtmlAttributes( query );
            
            List<string> builder = new List<string>();

            foreach ( var item in dict )
            {
                builder.Add( Url.Encode( item.Key ) + "=" + Url.Encode( item.Value.ToString() ) );
            }

            string queryString = queryString = "?" + string.Join( "&", builder );
            
            return PageUrl();
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

        /// <summary>
        /// Renders a Glyphicon to the screen.
        /// </summary>
        /// <param name="icon">The icon to render.</param>
        public IHtmlString Glyph( string icon )
        {
            return Html.Raw( "<i class=\"icon fa fa-" + icon + "\"></i>" );
        }

        /// <summary>
        /// Renders a Glyphicon to the screen.
        /// </summary>
        /// <param name="icon">The icon to render.</param>
        /// <param name="htmlAttributes">Any additional attributes to add to the icon.</param>
        public IHtmlString Glyph( string icon, object htmlAttributes )
        {
            TagBuilder tag = new TagBuilder( "i" );

            tag.AddCssClass( "icon" );
            tag.AddCssClass( "fa" );
            tag.AddCssClass( "fa-" + icon );

            RouteValueDictionary attributes = HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes );

            if ( attributes.ContainsKey( "class" ) )
            {
                tag.AddCssClass( attributes[ "class" ].ToString() );
            }

            tag.MergeAttributes( attributes );

            return Html.Raw( tag.ToString() );
        }

        /// <summary>
        /// Begins a html form using the provided url as the action.
        /// </summary>
        /// <param name="url">The url for the form.</param>
        public MvcUrlForm BeginUrlForm( string url )
        {
            return new MvcUrlForm( Html, url );
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

        /// <summary>
        /// Gets/Sets the page title to use in the layout base.
        /// </summary>
        public string PageTitle
        { 
            get
            {
                object pageTitle = TempData[ Keys.PageTitle ];
                if ( pageTitle != null ) return pageTitle.ToString();

                return UserCookie.Current.SiteName;
            }
            set
            {
                TempData[ Keys.PageTitle ] = value;
            }
        }

        /// <summary>
        /// Gets/Sets whether or not to hide the page title.
        /// </summary>
        public bool HideTitle
        {
            get
            {
                if ( TempData.ContainsKey( Keys.HideTitle ) ) return (bool)TempData[ Keys.HideTitle ];

                return false;
            }
            set
            {
                TempData[ Keys.HideTitle ] = value;
            }
        }

        /// <summary>
        /// Gets/Sets whether or not to hide the social network buttons.
        /// </summary>
        public bool HideSocialButtons
        {
            get
            {
                if ( TempData.ContainsKey( Keys.HideSocialButtons ) ) return (bool)TempData[ Keys.HideSocialButtons ];

                return false;
            }
            set
            {
                TempData[ Keys.HideSocialButtons ] = value;
            }
        }

        /// <summary>
        /// Gets/Sets whether to use the full width or allow the theme default.
        /// </summary>
        public bool UseFullWidth
        {
            get
            {
                if ( TempData.ContainsKey( Keys.UseFullWidth ) ) return (bool)TempData[ Keys.UseFullWidth ];

                return false;
            }
            set
            {
                TempData[ Keys.UseFullWidth ] = value;
            }
        }

        /// <summary>
        /// Gets/Sets whether or not this page is the current home page.
        /// </summary>
        public bool IsHomePage
        {
            get
            {
                if ( TempData.ContainsKey( Keys.IsHomePage ) ) return (bool)TempData[ Keys.IsHomePage ];

                return false;
            }
            set
            {
                TempData[ Keys.IsHomePage ] = value;
            }
        }

        /// <summary>
        /// Gets the current user profile.
        /// </summary>
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

        /// <summary>
        /// Gets the current user session.
        /// </summary>
        public UserSession UserSession
        {
            get
            {
                return UserSession.Current;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }

}
