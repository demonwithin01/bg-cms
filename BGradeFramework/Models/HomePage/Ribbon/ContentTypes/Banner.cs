using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.HomePage.ContentTypes
{
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
            this.BannerType = BannerType.Carousel;
            this.Width = "100%";
            this.Height = "100%";
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void PrepareForDisplay()
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

        #region Internal Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonProperty( "bannerType" )]
        [Display( Name = "Banner Type" )]
        public BannerType BannerType { get; set; }

        [JsonProperty( "height" )]
        public string Height { get; set; }

        [JsonProperty( "width" )]
        public string Width { get; set; }

        [JsonProperty( "slides" )]
        public List<BannerItem> Slides { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
