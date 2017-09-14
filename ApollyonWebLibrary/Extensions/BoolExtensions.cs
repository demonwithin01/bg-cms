namespace ApollyonWebLibrary.Extensions
{
    /// <summary>
    /// Defines a series of extensions for the Boolean type.
    /// </summary>
    public static class BoolExtensions
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Converts the boolean value to a string equivalent.
        /// </summary>
        /// <param name="flag">The flag to convert.</param>
        /// <param name="trueLabel">The label to use if the flag is true.</param>
        /// <param name="falseLabel">The label to use if the flag is false.</param>
        public static string ToString( this bool flag, string trueLabel, string falseLabel )
        {
            return ( flag ? trueLabel : falseLabel );
        }

        /// <summary>
        /// Converts the boolean value to a Yes/No string equivalent.
        /// </summary>
        /// <param name="flag">The flag to convert.</param>
        public static string ToYesNo( this bool flag )
        {
            return flag.ToString( "Yes", "No" );
        }

        /// <summary>
        /// Converts the boolean value to a JavaScript boolean value.
        /// </summary>
        /// <param name="flag">The flag to convert.</param>
        public static string ToJS( this bool flag )
        {
            return flag.ToString( "true", "false" );
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

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
