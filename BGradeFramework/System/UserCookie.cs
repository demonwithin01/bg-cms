﻿using ContentManagementSystemDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContentManagementSystem.Framework
{
    public class UserCookie
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Class Members

        private static string COOKIE_KEY = "user-session";

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public UserCookie()
        {
            NavItems = new List<NavItem>();
        }

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

        private UserCookie( UserProfile user, HttpContextBase context )
        {
            NavItems = new List<NavItem>();

            ContentManagementDb db = new ContentManagementDb();

            Domain domain = Domain.FindMatchedDomain( context.Request.Url, db );

            Initialise( db, domain, user );

            UserSession.CreateInstance( user, domain );
        }

        private void Initialise( ContentManagementDb db, Domain domain, UserProfile user = null )
        {
            DomainId = domain.DomainId;
            SiteName = domain.Name;
            
            if ( user != null )
            {
                UserId = user.UserId;

                Role = (Role.Data)( user.RoleId );
                IsAdministrator = user.IsAdministrator;
            }
            else
            {
                Role = ContentManagementSystemDatabase.Role.Data.GeneralUser;
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

            menuItems = menuItems.Where( d => d.DomainId == DomainId ).WhereActive();

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

        public bool CheckAdminAccess()
        {
            return ( Role == ContentManagementSystemDatabase.Role.Data.Administrator && UserSession.Current.Role == ContentManagementSystemDatabase.Role.Data.Administrator );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        public static UserCookie CreateInstance( UserProfile user, HttpContextBase context )
        {
            UserCookie userCookie = new UserCookie( user, context );

            Current = userCookie;

            return userCookie;
        }

        private static void SetCookie( UserCookie userCookie )
        {
            string cookieValue = JsonConvert.SerializeObject( userCookie );
            HttpCookie cookie = new HttpCookie( COOKIE_KEY, cookieValue );

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

        private static string Encode( UserCookie userCookie )
        {
            string cookieValue = JsonConvert.SerializeObject( userCookie );
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes( cookieValue );
            return Convert.ToBase64String( encoded );
        }

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

        [JsonProperty( "domain-id" )]
        public int DomainId { get; private set; }

        [JsonProperty( "user-id" )]
        public int UserId { get; private set; }

        public bool IsLoggedIn { get { return ( this.UserId > 0 ); } }

        public bool IsValidUrl { get { return ( this.DomainId > 0 ); } }

        [JsonProperty( "site-name" )]
        public string SiteName { get; private set; }

        [JsonProperty( "role" )]
        public Role.Data Role { get; set; }

        [JsonProperty( "is-admin" )]
        public bool IsAdministrator { get; private set; }

        [JsonProperty( "nav-items" )]
        public List<NavItem> NavItems { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        public static UserCookie Current
        {
            get
            {
                HttpContext context = HttpContext.Current;
                HttpCookie cookie = context.Request.Cookies[ COOKIE_KEY ];
                UserCookie userCookie;
                
                if ( cookie != null )
                {
                    userCookie = JsonConvert.DeserializeObject<UserCookie>( cookie.Value );
                }
                else
                {
                    userCookie = new UserCookie( context );
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
