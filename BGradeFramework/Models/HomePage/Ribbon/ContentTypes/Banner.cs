using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.HomePage.ContentTypes
{
    public class BannerItem
    {
        [JsonProperty( "uploadId" )]
        public int UploadId { get; set; }
    }

    public class Banner : ContentTypeBase
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

        [JsonProperty( "slides" )]
        public List<BannerItem> Slides { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
