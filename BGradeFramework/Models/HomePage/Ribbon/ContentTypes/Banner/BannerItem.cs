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
}
