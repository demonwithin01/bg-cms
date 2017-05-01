using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using log4net;

namespace ContentManagementSystem.Framework
{
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

        public static void Error( object messageObject, Exception exception )
        {
            ILog logger = CreateLogger();

            logger.Error( messageObject, exception );
        }

        public static void Error( string message, Exception exception )
        {
            ILog logger = CreateLogger();

            logger.Error( message, exception );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

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
