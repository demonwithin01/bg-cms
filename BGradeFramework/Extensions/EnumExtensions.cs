using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    
    public static class EnumExtensions
    {

        /// <summary>
        /// Gets the description of the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetDescription( this Enum source )
        {

            Type type = source.GetType();

            object[] properties = type.GetCustomAttributes( false );

            foreach ( object property in properties )
            {

                if ( property is DisplayAttribute )
                {
                    return ( ( property as DisplayAttribute ).Name );
                }

            }

            return null;

        }

    }

}
