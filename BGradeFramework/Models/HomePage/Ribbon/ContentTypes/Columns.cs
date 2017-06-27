using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.HomePage.ContentTypes
{
    public class Columns : ContentTypeBase
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

        [JsonProperty( "layout" )]
        public RibbonColumns Layout { get; set; }

        [JsonProperty( "columns" )]
        public List<RibbonItemContent> ColumnsContent { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
