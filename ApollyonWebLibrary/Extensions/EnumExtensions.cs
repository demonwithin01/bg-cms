using System;
using System.ComponentModel.DataAnnotations;

namespace ApollyonWebLibrary.Extensions
{
    /// <summary>
    /// Defines new functionality to enumeration types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description of the enum.
        /// </summary>
        /// <param name="source">The enum to get the description from.</param>
        /// <returns>The name on the display attribute if provided, otherwise the enumeration name.</returns>
        public static string GetDescription( this Enum source )
        {
            Type type = source.GetType();

            object[] properties = type.GetMember( source.ToString() )[ 0 ].GetCustomAttributes( false );

            foreach( object property in properties )
            {
                if( property is DisplayAttribute )
                {
                    return ( ( property as DisplayAttribute ).Name );
                }
            }

            return source.ToString();
        }

        /// <summary>
        /// Gets the description of the enum.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="source">The enum to get the description from.</param>
        /// <returns>The name on the display attribute if provided, otherwise the enumeration name.</returns>
        public static string GetDescription<TEnum>( this TEnum source ) where TEnum : struct, IConvertible
        {
            if( source is Enum )
            {
                return GetDescription( source as Enum );
            }

            return null;
        }

        /// <summary>
        /// Gets the enumeration as an integer.
        /// </summary>
        /// <param name="source">The enumeration to convert.</param>
        /// <returns>The enumeration in its integer format.</returns>
        public static int ToInt( this Enum source )
        {
            return Convert.ToInt32( source );
        }
    }
}
