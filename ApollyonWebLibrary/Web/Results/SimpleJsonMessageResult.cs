using Newtonsoft.Json;

namespace ApollyonWebLibrary.Web
{
    /// <summary>
    /// Creates a simple json success result with the provided message.
    /// </summary>
    public class SimpleJsonMessageResult : SimpleJsonResult
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Creates a simple json message result object.
        /// </summary>
        public SimpleJsonMessageResult()
            : base()
        {

        }

        /// <summary>
        /// Creates a simple json message result object.
        /// </summary>
        /// <param name="success">Whether or not the request was successful.</param>
        /// <param name="message">The message to add to the response json.</param>
        public SimpleJsonMessageResult( bool success, string message )
            : base( success )
        {
            this.Message = message;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Shortcut for creating a failed message response.
        /// </summary>
        /// <param name="message">The message to add to the response json.</param>
        public static SimpleJsonMessageResult Failed( string message )
        {
            return new SimpleJsonMessageResult( false, message );
        }

        /// <summary>
        /// Shortcut for creating a succeeded message response.
        /// </summary>
        /// <param name="message">The message to add to the response json.</param>
        public static SimpleJsonMessageResult Succeeded( string message )
        {
            return new SimpleJsonMessageResult( true, message );
        }

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

        [JsonProperty( "message" )]
        public string Message { get; set; }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
