using System.Linq;
using System.Web;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Framework
{
    //TODO: Move away from using the static property for getting the current session.
    /// <summary>
    /// Maintains the information on a user session.
    /// </summary>
    public class UserSession
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Class Members

        /// <summary>
        /// The key for accessing the user session.
        /// </summary>
        private static string SESSION_KEY = "user-session";

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new user session based off the current http context.
        /// </summary>
        /// <param name="context">The current http context.</param>
        private UserSession( HttpContext context )
        {
            ContentManagementDb db = new ContentManagementDb();

            Domain domain = Domain.FindMatchedDomain( context.Request.Url, db );

            if ( context.User.Identity.Name == string.Empty )
            {
                if ( domain != null )
                {
                    Initialise( domain );
                }

                return;
            }

            UserProfile user = db.Users.FirstOrDefault( u => u.UserName == context.User.Identity.Name );
            
            if ( user != null && domain != null )
            {
                Initialise( domain, user );
            }
        }

        /// <summary>
        /// Creates a user session from the known user and domain.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <param name="domain">The current domain.</param>
        private UserSession( UserProfile user, Domain domain )
        {
            Initialise( domain, user );
        }

        /// <summary>
        /// Creates a user session from the known domain and the possibly known user.
        /// </summary>
        /// <param name="domain">The current domain.</param>
        /// <param name="user">The possibly known current user.</param>
        private void Initialise( Domain domain, UserProfile user = null )
        {
            DomainId = domain.DomainId;

            if ( user != null )
            {
                UserId = user.UserId;
                
                Role = user.Role;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods
            
        /// <summary>
        /// Retrieves the current domain from the database.
        /// </summary>
        public Domain CurrentDomain()
        {
            ContentManagementDb db = new ContentManagementDb();

            return db.Domains.Find( DomainId );
        }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        /// <summary>
        /// Creates a new instance of the user session for the current user and domain.
        /// </summary>
        /// <param name="user">The currently logged in user.</param>
        /// <param name="domain">The current domain.</param>
        public static UserSession CreateInstance( UserProfile user, Domain domain )
        {
            UserSession userSession = new UserSession( user, domain );

            Current = userSession;

            return userSession;
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
        public int DomainId { get; private set; }

        /// <summary>
        /// Gets the current user ID.
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Gets whether there is currently a user logged in.
        /// </summary>
        public bool IsLoggedIn { get { return ( this.UserId > 0 ); } }

        /// <summary>
        /// Gets whether or not the current domain is valid.
        /// </summary>
        public bool IsValidUrl { get { return ( this.DomainId > 0 ); } }
        
        /// <summary>
        /// Gets the role for the current user.
        /// </summary>
        public Role Role { get; private set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        /// <summary>
        /// Gets whether or not the current user is an administrator.
        /// </summary>
        public bool IsAdministrator
        {
            get
            {
                return ( Role == Role.Administrator );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Properties

        /// <summary>
        /// Gets the user session for the current http context.
        /// </summary>
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
