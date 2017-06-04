using System;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Used to set whether an item was successfully validate and the corresponding message.
    /// </summary>
    public class ValidationResult
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new standard validation result.
        /// </summary>
        /// <param name="result">Whether or not the validation was successful</param>
        /// <param name="displayNotification">Whether or not to display the message as a notification</param>
        public ValidationResult( bool result, bool displayNotification = true )
            : this( result, "", null, displayNotification )
        {

        }

        /// <summary>
        /// Creates a new validation result with a provided message.
        /// </summary>
        /// <param name="result">Whether or not the validation was successful</param>
        /// <param name="message">The message to display</param>
        /// <param name="displayNotification">Whether or not to display the message as a notification</param>
        public ValidationResult( bool result, string message, bool displayNotification = true )
            : this( result, message, null, displayNotification )
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">Whether or not the validation was successful</param>
        /// <param name="exception">The exception to use to generate the message (if enabled)</param>
        /// <param name="displayNotification">Whether or not to display the message as a notification</param>
        public ValidationResult( bool result, Exception exception, bool displayNotification = true )
            : this( result, "", exception, displayNotification )
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">Whether or not the validation was successful</param>
        /// <param name="message">The message to display (may be overwritten by the exception)</param>
        /// <param name="exception">The exception to use to generate the message (if enabled)</param>
        /// <param name="displayNotification">Whether or not to display the message as a notification</param>
        public ValidationResult( bool result, string message, Exception exception, bool displayNotification = true )
        {

            this.Result = result;
            this.DisplayNotification = displayNotification;
            this.Message = message;
            this.Exception = exception;

            if ( Settings.EnableValidationExceptionMessages && this.Result == false && this.Exception != null )
            {
                this.Message = GetExceptionMessage( exception );
            }

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Gets the message from the inner-most exception.
        /// </summary>
        /// <param name="exception">The exception to get the message from.</param>
        /// <returns>The exception message.</returns>
        private string GetExceptionMessage( Exception exception )
        {

            if ( exception.InnerException == null )
            {

                return exception.Message;

            }

            return GetExceptionMessage( exception );

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties
        
        /// <summary>
        /// Gets the result from the validation.
        /// </summary>
        public bool Result { get; private set; }

        /// <summary>
        /// Gets whether or not to display as a notification.
        /// </summary>
        public bool DisplayNotification { get; private set; }

        /// <summary>
        /// Gets the message that applies to the result.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the exception that applies to a failed result;
        /// </summary>
        public Exception Exception { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
