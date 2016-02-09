using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework
{
    public class UserSession
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Class Members

        private static string SESSION_KEY = "user-session";

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        private UserSession( HttpContext context )
        {
            ContentManagementDb db = new ContentManagementDb();

            Domain domain = Domain.FindMatchedDomain( context.Request.Url, db );

            if ( context.User.Identity.Name == string.Empty )
            {
                if ( domain != null )
                {
                    this.Initialise( domain );
                }

                return;
            }

            UserProfile user = db.Users.FirstOrDefault( u => u.UserName == context.User.Identity.Name );
            
            if ( user != null )
            {
                if ( domain != null )
                {
                    this.Initialise( domain, user );
                }
            }
        }

        private UserSession( UserProfile user, HttpContextBase context )
        {
            Domain domain = Domain.FindMatchedDomain( context.Request.Url );

            this.Initialise( domain, user );
        }

        private void Initialise( Domain domain, UserProfile user = null )
        {
            this.DomainId = domain.DomainId;

            if ( user != null )
            {
                this.UserId = user.UserId;

                this.IsAdministrator = user.IsAdministrator;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public List<DomainNavigationItem> GetMenuItems( ContentManagementDb db = null )
        {
            db = db ?? new ContentManagementDb();

            Domain domain = CurrentDomain( db );

            if ( domain == null ) return new List<DomainNavigationItem>();

            IQueryable<DomainNavigationItem> menuItems = db.DomainNavigationItems.Where( d => d.DomainId == DomainId ).WhereActive();
            
            if ( this.IsLoggedIn == false )
            {
                menuItems = menuItems.Where( m => m.LoginRequired == false );
            }
            
            return menuItems.OrderBy( d => d.Ordinal ).ToList();
        }

        public Domain CurrentDomain( ContentManagementDb db = null )
        {
            db = db ?? new ContentManagementDb();

            return db.Domains.Find( DomainId );
        }

        public UserProfile CurrentUser( ContentManagementDb db = null )
        {
            db = db ?? new ContentManagementDb();

            return db.Users.Find( UserId );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        public static UserSession CreateInstance( UserProfile user, HttpContextBase context )
        {
            UserSession userSession = new UserSession( user , context);

            Current = userSession;

            return userSession;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties
        
        public int DomainId
        {
            get; private set;
        }

        public int UserId
        {
            get; private set;
        }

        public bool IsLoggedIn { get { return ( this.UserId > 0 ); } }

        public bool IsValidUrl { get { return ( this.DomainId > 0 ); } }

        public bool IsAdministrator
        {
            get; private set;
        }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        public static UserSession Current
        {
            get
            {
                HttpContext context = HttpContext.Current;
                UserSession userSession = context.Session[ SESSION_KEY ] as UserSession;

                if ( userSession == null )
                {
                    userSession = new UserSession( context );
                    context.Session[ SESSION_KEY ] = userSession;
                }

                return userSession;
            }
            set
            {
                HttpContext context = HttpContext.Current;
                context.Session[ SESSION_KEY ] = value;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
