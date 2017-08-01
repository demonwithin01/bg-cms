using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.HomePage.ContentTypes
{
    public class EditableContent : ContentTypeBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public EditableContent()
        {
            Html = "";
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Internal Methods

        internal override void PrepareForDisplay()
        {

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [AllowHtml]
        [JsonProperty( "html" )]
        public string Html { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
