using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework.Helpers
{
    /// <summary>
    /// Helper class for generating the html of a form with a provided url.
    /// </summary>
    public sealed class MvcUrlForm : IDisposable
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        /// <summary>
        /// The html helper to use for rendering.
        /// </summary>
        private HtmlHelper _htmlHelper;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new form tag.
        /// </summary>
        /// <param name="htmlHelper">The html helper to use for rendering the text.</param>
        /// <param name="url">The url to use for the form action.</param>
        public MvcUrlForm( HtmlHelper htmlHelper, string url )
        {
            _htmlHelper = htmlHelper;

            _htmlHelper.ViewContext.Writer.WriteLine( "<form action=\"" + url + "\" method=\"post\">" );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Closes the form tag.
        /// </summary>
        public void Dispose()
        {
            _htmlHelper.ViewContext.Writer.WriteLine( "</form>" );
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
