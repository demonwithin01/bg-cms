using Newtonsoft.Json;

namespace ApollyonWebLibrary.Web
{
    /// <summary>
    /// Creates a simple json success result with the provided html.
    /// </summary>
    public class SimpleJsonHtmlResult : SimpleJsonResult
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Creates a simple json html result object.
        /// </summary>
        public SimpleJsonHtmlResult()
            : base()
        {

        }

        /// <summary>
        /// Creates a simple json html result object.
        /// </summary>
        /// <param name="success">Whether or not the request was successful.</param>
        /// <param name="html">The html to add to the response json.</param>
        public SimpleJsonHtmlResult( bool success, string html )
            : base( success )
        {
            this.Html = html;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonProperty( "html" )]
        public string Html { get; set; }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
