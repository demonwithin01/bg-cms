using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    
    /// <summary>
    /// Tells AutoMap to ignore a property when mapping.
    /// </summary>
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false, Inherited = true )]
    public class AutoMapIgnoreAttribute : Attribute
    {

    }

    /// <summary>
    /// Tells AutoMap to map the property to a property with a different name.
    /// </summary>
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false, Inherited = true )]
    public class MapsToAttribute : Attribute
    {

        /// <summary>
        /// The name of the property to map to.
        /// </summary>
        public string MapsTo { get; set; }

        /// <summary>
        /// Tells AutoMap to map the property to a property with a different name.
        /// </summary>
        /// <param name="mapsTo">The name of the property to map to</param>
        public MapsToAttribute( string mapsTo )
        {
            MapsTo = mapsTo;
        }

    }

    /// <summary>
    /// Tells AutoMap to map the property from a property with a different name.
    /// </summary>
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false, Inherited = true )]
    public class MapsFromAttribute : Attribute
    {

        /// <summary>
        /// The name of the property to map from.
        /// </summary>
        public string MapsFrom { get; set; }

        /// <summary>
        /// Tells AutoMap to map the property from a property with a different name.
        /// </summary>
        /// <param name="mapsFrom">The name of the property to map from</param>
        public MapsFromAttribute( string mapsFrom )
        {
            MapsFrom = mapsFrom;
        }

    }

}
