using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContentManagementSystem.Framework
{
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

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonIgnore]
        public HttpRequest Request { get; set; }

        [JsonIgnore]
        public bool HideBackgroundColor { get; set; }
        
        [JsonIgnore]
        public string EditorLocation { get; set; }

        [JsonIgnore]
        public string DisplayLocation { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
