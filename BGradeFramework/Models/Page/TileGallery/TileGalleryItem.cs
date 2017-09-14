using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.Page
{
    public class TileGalleryItem
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public TileGalleryItem()
        {
            this.Notes = new List<string>();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public void UpdateUploadEntity( Upload upload )
        {
            this.ImageUrl = upload.PhysicalLocation;
        }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonProperty( "uploadId" )]
        public int UploadId { get; set; }
        
        [Required( ErrorMessage = "Please enter in the title" )]
        [JsonProperty( "title" )]
        public string Title { get; set; }
        
        [JsonProperty( "notes" )]
        public List<string> Notes { get; set; }


        [JsonIgnore]
        public string ImageUrl { get; private set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
