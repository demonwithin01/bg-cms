using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContentManagementSystem.Framework
{
    //TODO: Utilise from BGrade Library
    /// <summary>
    /// Provides new functionality to all strings.
    /// </summary>
    public static class StringHelpers
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
        /// Turns a model name into a human readable format.
        /// </summary>
        /// <param name="value">The string to be turned into a human readable format.</param>
        /// <returns>The model name in a human readable format.</returns>
        public static string HumanReadable( string value )
        {
            return value.Replace(
                string.Format( "%s|%s|%s",
                               "(?<=[A-Z])(?=[A-Z][a-z])",
                               "(?<=[^A-Z])(?=[A-Z])",
                               "(?<=[A-Za-z])(?=[^A-Za-z])"
                ),
                " "
            );
        }

        /// <summary>
        /// Maps the current path into a location on the server file system.
        /// </summary>
        /// <param name="path">The path to be mapped to the server file system.</param>
        /// <returns>The path mapped to the server file system.</returns>
        public static string MapToServer( string path )
        {
            return HttpContext.Current.Server.MapPath( path );
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
