using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApollyonWebLibrary.Converters
{
    public class JsonDateConverter : JsonConverter
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
        /// Checks if the provided property type is able to be converted by this converted.
        /// </summary>
        /// <param name="objectType">The object type of the property to convert.</param>
        /// <returns>True if the type is the same as DateTime, otherwise false.</returns>
        public override bool CanConvert( Type objectType )
        {
            return ( typeof( DateTime ) == objectType );
        }

        /// <summary>
        /// Reads the value and attempts to convert it to a DateTime.
        /// </summary>
        /// <param name="reader">The json reader.</param>
        /// <param name="objectType">The object type to write to.</param>
        /// <param name="existingValue">The existing value that has been provided.</param>
        /// <param name="serializer">The json serializer.</param>
        /// <returns>The converted DateTime object or null.</returns>
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            bool isNullableProperty = ( objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof( Nullable<> ) );
            DateTime? defaultReturnValue = null;

            if ( isNullableProperty == false )
            {
                defaultReturnValue = new DateTime();
            }

            if ( existingValue == null )
            {
                return defaultReturnValue;
            }

            string dateString = existingValue.ToString();
            DateTime date;

            if ( DateTime.TryParse( dateString, out date ) )
            {
                return date;
            }

            return defaultReturnValue;
        }

        /// <summary>
        /// Writes the value out in a valid format.
        /// </summary>
        /// <param name="writer">The json writer to write the value to.</param>
        /// <param name="value">The value to be written.</param>
        /// <param name="serializer">The json serializer.</param>
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if ( value == null )
            {
                writer.WriteUndefined();
            }
            else if ( value is DateTime )
            {
                writer.WriteValue( ( (DateTime)value ).ToShortDateString() );
            }
            else
            {
                writer.WriteUndefined();
            }
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
