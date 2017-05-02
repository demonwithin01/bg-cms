using System;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Specifies the location to find the editor view for a page template.
    /// </summary>
    public class EditorLocationAttribute : Attribute
    {
        /// <summary>
        /// Specifies the location to find the editor view for a page template.
        /// </summary>
        /// <param name="location">The location to find the view.</param>
        public EditorLocationAttribute( string location )
        {
            Location = location;
        }

        /// <summary>
        /// Gets the location of the page template editor view.
        /// </summary>
        public string Location { get; private set; }
    }
}
