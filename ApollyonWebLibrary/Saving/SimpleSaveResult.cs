using Newtonsoft.Json;

namespace ApollyonWebLibrary
{
    /// <summary>
    /// Shortcut object to provide JSON formatted save results.
    /// </summary>
    public class SimpleSaveResult
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Initialises the save result with a state only.
        /// </summary>
        /// <param name="state">The state of the save result.</param>
        private SimpleSaveResult( SimpleSaveResultState state )
        {
            this.State = state;
        }

        /// <summary>
        /// Initialises the save result with a state and a message.
        /// </summary>
        /// <param name="state">The state of the save result.</param>
        /// <param name="message">The message associated with the save result.</param>
        private SimpleSaveResult( SimpleSaveResultState state, string message )
        {
            this.State = state;
            this.Message = message;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Creates a successful save result object.
        /// </summary>
        public static SimpleSaveResult Success()
        {
            return new SimpleSaveResult( SimpleSaveResultState.Succeeded );
        }

        /// <summary>
        /// Creates a successful save result object.
        /// </summary>
        /// <param name="message">A message for the success state.</param>
        public static SimpleSaveResult Success( string message )
        {
            return new SimpleSaveResult( SimpleSaveResultState.Succeeded, message );
        }

        /// <summary>
        /// Creates a failed save result object.
        /// </summary>
        public static SimpleSaveResult Failed()
        {
            return new SimpleSaveResult( SimpleSaveResultState.Failed );
        }

        /// <summary>
        /// Creates a failed save result object.
        /// </summary>
        /// <param name="message">A message for the failed state.</param>
        public static SimpleSaveResult Failed( string message )
        {
            return new SimpleSaveResult( SimpleSaveResultState.Failed, message );
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

        /// <summary>
        /// Gets the current save result state.
        /// </summary>
        [JsonProperty( "state" )]
        public SimpleSaveResultState State { get; private set; }

        /// <summary>
        /// Gets the message associated with the state.
        /// </summary>
        [JsonProperty( "message" )]
        public string Message { get; private set; }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        /// <summary>
        /// Gets whether or not the save result is in a successful state.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccessful
        {
            get
            {
                return ( this.State == SimpleSaveResultState.Succeeded );
            }
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
