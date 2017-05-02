using System;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Specifies the location to find the display view for a page template.
    /// </summary>
    public class DisplayLocationAttribute : Attribute
    {
        /// <summary>
        /// Specifies the location to find the display view for a page template.
        /// </summary>
        /// <param name="location">The location to find the view.</param>
        public DisplayLocationAttribute( string location )
        {
            Location = location;
        }

        /// <summary>
        /// Gets the location of the page template display view.
        /// </summary>
        public string Location { get; private set; }
    }
}
