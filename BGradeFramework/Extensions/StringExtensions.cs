using System.Web;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Provides new functionality to all strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Turns a model name into a human readable format.
        /// </summary>
        /// <param name="value">The string to be turned into a human readable format.</param>
        /// <returns>The model name in a human readable format.</returns>
        public static string HumanReadable( this string value )
        {
            //TODO: Remove from extensions, not reqired on all/most strings.
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
        public static string MapToServer( this string path )
        {
            //TODO: Remove from extensions, not required on all/most strings.
            return HttpContext.Current.Server.MapPath( path );
        }
    }
}
