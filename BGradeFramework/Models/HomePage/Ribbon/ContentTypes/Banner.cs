using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.HomePage.ContentTypes
{
    public class BannerItem
    {
        [JsonProperty( "uploadId" )]
        public int UploadId { get; set; }

        [JsonIgnore]
        public string ImgUrl { get; set; }
    }

    public class Banner : ContentTypeBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public Banner()
        {
            this.Slides = new List<BannerItem>();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Internal Methods

        internal override void PrepareForDisplay()
        {
            List<int> uploadIds = Slides.Select( s => s.UploadId ).ToList();

            List<Upload> uploads = new ContentManagementDb().Uploads.Where( s => uploadIds.Contains( s.UploadId ) ).ToList();

            foreach ( Upload upload in uploads )
            {
                Slides.Where( s => s.UploadId == upload.UploadId ).ToList().ForEach( s => s.ImgUrl = upload.PhysicalLocation );
            }
        }

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
