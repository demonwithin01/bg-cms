using System.Web;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Extends functionality of Html strings.
    /// </summary>
    public static class HtmlStringExtensions
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
        /// Escapes double quotes so that they can be written inside JavaScript strings.
        /// </summary>
        /// <param name="html">The html that contains quotes to be escaped.</param>
        /// <returns>A html string where double quotes have been escaped.</returns>
        public static IHtmlString EscapeQuotes( this IHtmlString html )
        {
            return new MvcHtmlString( html.ToString().Replace( "\"", "\\\"" ) );
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
