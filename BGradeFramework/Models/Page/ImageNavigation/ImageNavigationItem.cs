using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.Page
{
    public class ImageNavigationItem
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

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonProperty( "domainNavigationItemId" )]
        public int DomainNavigationItemId { get; set; }

        [JsonProperty( "uploadId" )]
        public int UploadId { get; set; }

        [JsonProperty( "navigationUrl" )]
        public string NavigationUrl { get; set; }

        [JsonProperty( "imageUrl" )]
        public string ImageUrl { get; set; }

        [JsonProperty( "title" )]
        public string Title { get; set; }

        [JsonIgnore]
        public ImageNavigation ImageNavigation { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
