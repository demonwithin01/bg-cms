namespace ApollyonWebLibrary.Extensions
{
    /// <summary>
    /// Defines a series of extensions for the decimal type.
    /// </summary>
    public static class DecimalExtensions
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
        /// Converts the provided decimal value to a currency.
        /// </summary>
        /// <param name="value">The decimal value to become a currency string.</param>
        /// <param name="precision">The number of decimal places for the currency.</param>
        public static string ToCurrency( this decimal value, int precision = 0 )
        {
            return string.Format( "{0:C" + precision + "}", value );
        }

        /// <summary>
        /// Converts the provided decimal value to a currency. If no value is provided, 
        /// then an empty string is returned.
        /// </summary>
        /// <param name="value">The decimal value to become a currency string.</param>
        /// <param name="precision">The number of decimal places for the currency.</param>
        public static string ToCurrency( this decimal? value, int precision = 0 )
        {
            return value.HasValue ? ToCurrency( value.Value, precision ) : "";
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
