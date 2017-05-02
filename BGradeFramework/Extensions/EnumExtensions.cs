using System;
using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Framework
{
    //TODO: Move to BGrade library.
    /// <summary>
    /// Defines new functionality to enumeration types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description of the enum.
        /// </summary>
        /// <param name="source">The enum to get the description from.</param>
        /// <returns>The name on the display attribute if provided, otherwise null.</returns>
        public static string GetDescription( this Enum source )
        {
            //TODO: Stop forcing requirement of display attribute, use enumeration text instead if not provided.
            Type type = source.GetType();
            
            object[] properties = type.GetMember( source.ToString() )[0].GetCustomAttributes( false );

            foreach ( object property in properties )
            {
                if ( property is DisplayAttribute )
                {
                    return ( ( property as DisplayAttribute ).Name );
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the description of the enum.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="source">The enum to get the description from.</param>
        /// <returns>The name on the display attribute if provided, otherwise null.</returns>
        public static string GetDescription<TEnum>( this TEnum source ) where TEnum : struct, IConvertible
        {
            //TODO: Stop forcing requirement of display attribute, use enumeration text instead if not provided.
            if( source is Enum )
            {
                return GetDescription( source as Enum );
            }

            return null;
        }
    }
}
