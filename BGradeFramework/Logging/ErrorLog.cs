using System;
using System.Web;
using log4net;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Provides functionality for logging errors/warnings/messages into the database.
    /// </summary>
    public static class ErrorLog
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Logs an exception into the log table of the database.
        /// </summary>
        /// <param name="messageObject">The object to log into the error.</param>
        /// <param name="exception">The exception that occurred.</param>
        public static void Error( object messageObject, Exception exception )
        {
            ILog logger = CreateLogger();

            logger.Error( messageObject, exception );
        }

        /// <summary>
        /// Logs an exception into the log table of the database.
        /// </summary>
        /// <param name="message">The message to log into the error.</param>
        /// <param name="exception">The exception that occurred.</param>
        public static void Error( string message, Exception exception )
        {
            ILog logger = CreateLogger();

            logger.Error( message, exception );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Creates the logger with the common details that will be attached to all log messages.
        /// </summary>
        /// <returns>The logger that will be used to log the actual message.</returns>
        private static ILog CreateLogger()
        {
            ILog logger = LogManager.GetLogger( "errorLog" );

            if ( HttpContext.Current != null && UserSession.Current.UserId > 0 )
            {
                LogicalThreadContext.Properties[ "loggedInUserId" ] = UserSession.Current.UserId;
            }
            else
            {
                LogicalThreadContext.Properties[ "loggedInUserId" ] = null;
            }

            if ( HttpContext.Current != null )
            {
                string domain = HttpContext.Current.Request.Url.Authority;

                if ( domain.StartsWith( "www." ) )
                {
                    domain = domain.Substring( 4 );
                }

                LogicalThreadContext.Properties[ "domain" ] = domain;
            }
            else
            {
                LogicalThreadContext.Properties[ "domain" ] = "Unknown";
            }

            return logger;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
