using System.Web;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework
{
    /// <summary>
    /// Defines the locations for viewing/editing a page template. Acts as a base for all page templates.
    /// </summary>
    public class PageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Initiliases the model for editor purposes.
        /// </summary>
        public virtual void InitialiseForEditor()
        {

        }

        /// <summary>
        /// Initiliases the model for display purposes.
        /// </summary>
        public virtual void InitialiseForDisplay()
        {

        }

        /// <summary>
        /// Raised before the object is saved.
        /// </summary>
        public virtual void OnBeforeSave()
        {

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Gest the current request information.
        /// </summary>
        [JsonIgnore]
        public HttpRequest Request { get; set; }

        /// <summary>
        /// Gets/Sets whether or not to hide the background colour for the current page.
        /// </summary>
        [JsonIgnore]
        public bool HideBackgroundColor { get; set; }

        /// <summary>
        /// Gets/Sets the view location for editing the page template.
        /// </summary>
        [JsonIgnore]
        public string EditorLocation { get; set; }

        /// <summary>
        /// Gets/Sets the view location for viewing the page template.
        /// </summary>
        [JsonIgnore]
        public string DisplayLocation { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
