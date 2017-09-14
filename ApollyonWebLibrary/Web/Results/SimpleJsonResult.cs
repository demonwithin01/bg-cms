using Newtonsoft.Json;

namespace ApollyonWebLibrary.Web
{
    /// <summary>
    /// A simple json result designed to automatically expose the Success property.
    /// Must be derived from in order to make this class have meaning in a response.
    /// </summary>
    public abstract class SimpleJsonResult
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Creates a simple json result object.
        /// </summary>
        public SimpleJsonResult()
        {

        }

        /// <summary>
        /// Creates a simple json result object.
        /// </summary>
        /// <param name="success">Whether or not the request was successful.</param>
        public SimpleJsonResult( bool success )
        {
            this.Success = success;
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

        [JsonProperty( "success" )]
        public bool Success { get; set; }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
