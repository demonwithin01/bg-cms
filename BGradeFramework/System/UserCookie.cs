using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework
{
    //TODO: Move away from using the static property for getting the current cookie.
    /// <summary>
    /// Defines the cookie for the user information during their current session.
    /// </summary>
    public class UserCookie
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Class Members

        /// <summary>
        /// The key for the cookie information.
        /// </summary>
        private static string COOKIE_KEY = "user-session";

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new blank user cookie.
        /// </summary>
        public UserCookie()
        {
            NavItems = new List<NavItem>();
        }

        /// <summary>
        /// Creates a new user cookie based off any known information in the current http context.
        /// </summary>
        /// <param name="context">The current http context.</param>
        private UserCookie( HttpContext context )
        {
            NavItems = new List<NavItem>();

            ContentManagementDb db = new ContentManagementDb();

            Domain domain = Domain.FindMatchedDomain( context.Request.Url, db );

            if ( context.User.Identity.Name == string.Empty )
            {
                if ( domain != null )
                {
                    Initialise( db, domain );
                }

                return;
            }

            UserProfile user = db.Users.FirstOrDefault( u => u.UserName == context.User.Identity.Name );

            if ( user != null )
            {
                if ( domain != null )
                {
                    Initialise( db, domain, user );
                }
            }

            UserSession.CreateInstance( user, domain );
        }

        /// <summary>
        /// Creates a new user cookie based off the provided user and the current http context.
        /// </summary>
        /// <param name="user">The user to create this cookie for.</param>
        /// <param name="context">The current http context.</param>
        private UserCookie( UserProfile user, HttpContextBase context )
        {
            NavItems = new List<NavItem>();

            ContentManagementDb db = new ContentManagementDb();

            Domain domain = Domain.FindMatchedDomain( context.Request.Url, db );

            Initialise( db, domain, user );

            UserSession.CreateInstance( user, domain );
        }

        /// <summary>
        /// Creates a new user cookie based off an existing cookie and a known domain.
        /// </summary>
        /// <param name="cookie">The existing cookie.</param>
        /// <param name="domain">The current domain.</param>
        /// <param name="db">A reference to an existing database connection.</param>
        private UserCookie( UserCookie cookie, Domain domain, ContentManagementDb db )
        {
            NavItems = new List<NavItem>();

            UserProfile user = db.Users.FirstOrDefault( u => u.UserId == UserSession.Current.UserId );

            Initialise( db, domain, user );
        }

        /// <summary>
        /// Creates a new user cookie based off a known domain and a possibly known user.
        /// </summary>
        /// <param name="db">A reference to an existing database connection.</param>
        /// <param name="domain">The current domain.</param>
        /// <param name="user">The current possible user.</param>
        private void Initialise( ContentManagementDb db, Domain domain, UserProfile user = null )
        {
            DomainId = domain.DomainId;
            SiteName = domain.Name;
            Theme = domain.Theme;
            LastUpdated = domain.DateUpdated;

            if ( domain.BackgroundUpload != null )
            {
                BackgroundUrl = domain.BackgroundUpload.PhysicalLocation;
            }

            if ( domain.LogoUpload != null )
            {
                LogoUrl = domain.LogoUpload.PhysicalLocation;
            }

            if ( user != null )
            {
                UserId = user.UserId;

                Role = user.Role;
            }
            else
            {
                Role = ContentManagementSystemDatabase.Role.GeneralUser;
            }

            IQueryable<DomainNavigationItem> menuItems;

            if ( IsLoggedIn )
            {
                menuItems = db.DomainNavigationItems;
            }
            else
            {
                menuItems = db.DomainNavigationItems.Include( s => s.Page );
            }

            menuItems = menuItems.Include( s => s.SubNavigationItems )
                                 .Where( d => d.DomainId == DomainId && d.ParentDomainNavigationItemId == null )
                                 .WhereActive();

            if ( this.IsLoggedIn == false )
            {
                menuItems = menuItems.Where( m => m.Page.RequiresLogin == false );
            }

            NavItems = menuItems.OrderBy( d => d.Ordinal )
                                .ToList()
                                .Select( s => new NavItem( s ) )
                                .ToList();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods
            
        /// <summary>
        /// Checks if the user has the provided role.
        /// If the role request is a general user, then only the cookie is checked, otherwise the UserSession is also queried.
        /// </summary>
        /// <param name="role">The role to check to see if the current user has access.</param>
        public bool HasRole( Role role )
        {
            if ( role == Role.GeneralUser )
            {
                return true;
            }

            return ( Role == role && UserSession.Current.Role == role );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        /// <summary>
        /// Creates the UserCookie instance from the provided user profile and the current http context.
        /// </summary>
        /// <param name="user">The user to create this cookie for.</param>
        /// <param name="context">The current http context.</param>
        /// <returns></returns>
        public static UserCookie CreateInstance( UserProfile user, HttpContextBase context )
        {
            UserCookie userCookie = new UserCookie( user, context );

            Current = userCookie;

            return userCookie;
        }

        /// <summary>
        /// Sets the cookie into the cookie details for the request/response.
        /// </summary>
        /// <param name="userCookie">The cookie to add to the request/response.</param>
        private static void SetCookie( UserCookie userCookie )
        {
            string cookieValue = JsonConvert.SerializeObject( userCookie );
            HttpCookie cookie = new HttpCookie( COOKIE_KEY, cookieValue );
            cookie.Expires = DateTime.UtcNow.AddDays( 1 );

            HttpContext context = HttpContext.Current;

            if ( context.Request.Cookies.AllKeys.Contains( COOKIE_KEY ) )
            {
                context.Request.Cookies.Set( cookie );
            }
            else
            {
                context.Request.Cookies.Add( cookie );
            }

            if ( context.Response.Cookies.AllKeys.Contains( COOKIE_KEY ) )
            {
                context.Response.Cookies.Set( cookie );
            }
            else
            {
                context.Response.Cookies.Add( cookie );
            }
        }

        /// <summary>
        /// Encodes the cookie into a base64 string.
        /// </summary>
        /// <param name="userCookie">The cookie to be encoded.</param>
        private static string Encode( UserCookie userCookie )
        {
            string cookieValue = JsonConvert.SerializeObject( userCookie );
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes( cookieValue );
            return Convert.ToBase64String( encoded );
        }

        /// <summary>
        /// Decodes the cookie from a base64 string.
        /// </summary>
        /// <param name="cookieValue">The cookie as a base64 string.</param>
        private static UserCookie Decode( string cookieValue )
        {
            byte[] encoded = Convert.FromBase64String( cookieValue );
            cookieValue = Encoding.UTF8.GetString( encoded );
            return JsonConvert.DeserializeObject<UserCookie>( cookieValue );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Gets the current domain ID.
        /// </summary>
        [JsonProperty( "domain-id" )]
        public int DomainId { get; private set; }

        /// <summary>
        /// Gets the current user ID.
        /// </summary>
        [JsonProperty( "user-id" )]
        public int UserId { get; private set; }

        /// <summary>
        /// Gets the name of the site.
        /// </summary>
        [JsonProperty( "site-name" )]
        public string SiteName { get; private set; }

        /// <summary>
        /// Gets the url for the background image of the current domain.
        /// </summary>
        [JsonProperty( "background-url" )]
        public string BackgroundUrl { get; private set; }

        /// <summary>
        /// Gets the url for the logo image of the current domain.
        /// </summary>
        [JsonProperty( "logo-url" )]
        public string LogoUrl { get; private set; }
        
        /// <summary>
        /// Gets the name of the theme for the current domain.
        /// </summary>
        [JsonProperty( "theme" )]
        public string Theme { get; private set; }

        /// <summary>
        /// Gets the role that this user has been assigned to.
        /// </summary>
        [JsonProperty( "role" )]
        public Role Role { get; set; }
        
        /// <summary>
        /// Gets the navigation items for the current domain.
        /// </summary>
        [JsonProperty( "nav-items" )]
        public List<NavItem> NavItems { get; private set; }

        /// <summary>
        /// Gets the time that this cookie was last updated.
        /// </summary>
        [JsonProperty( "last-updated" )]
        public DateTime LastUpdated { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        /// <summary>
        /// Gets whether or not there is a user logged in.
        /// </summary>
        [JsonIgnore]
        public bool IsLoggedIn { get { return ( this.UserId > 0 ); } }

        /// <summary>
        /// Gets whether or not the current url exists as a domain in the database.
        /// </summary>
        [JsonIgnore]
        public bool IsValidUrl { get { return ( this.DomainId > 0 ); } }

        /// <summary>
        /// Gets/Sets the current user cookie for the request.
        /// </summary>
        public static UserCookie Current
        {
            get
            {
                HttpContext context = HttpContext.Current;
                HttpCookie cookie = context.Request.Cookies[ COOKIE_KEY ];
                UserCookie userCookie = null;
                Domain domain;
                ContentManagementDb db;
                
                if ( cookie != null )
                {
                    userCookie = JsonConvert.DeserializeObject<UserCookie>( cookie.Value );
                }

                if ( userCookie == null )
                {
                    userCookie = new UserCookie( context );
                    SetCookie( userCookie );
                }
                else if ( userCookie.LastUpdated < (domain = ( db = new ContentManagementDb() ).Domains.Find( userCookie.DomainId )  ).DateUpdated )
                {
                    userCookie = new UserCookie( userCookie, domain, db );
                    SetCookie( userCookie );
                }
                
                return userCookie;
            }
            set
            {
                SetCookie( value );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
