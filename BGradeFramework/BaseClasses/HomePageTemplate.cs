using Newtonsoft.Json;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Defines the locations for viewing/editing a home page template. Acts as a base for all home page templates.
    /// </summary>
    public class HomePageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Gets/Sets the view location for editing the home page template.
        /// </summary>
        [JsonIgnore]
        public string EditorLocation { get; set; }

        /// <summary>
        /// Gets/Sets the view location for displaying the home page template.
        /// </summary>
        [JsonIgnore]
        public string DisplayLocation { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
