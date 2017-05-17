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
    [EditorLocation( "~/Views/Admin/PageTemplates/TileGallery.cshtml" )]
    [DisplayLocation( "~/Views/Home/PageTemplates/TileGallery.cshtml" )]
    public class TileGallery : PageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public TileGallery()
        {
            base.HideBackgroundColor = true;
            this.Items = new List<TileGalleryItem>();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void InitialiseForDisplay()
        {
            FillItemsWithUploads();
        }

        public override void InitialiseForEditor()
        {
            FillItemsWithUploads();
        }

        public override void OnBeforeSave()
        {
            this.Items = this.Items.Where( s => s != null ).ToList();

            foreach ( TileGalleryItem item in this.Items )
            {
                item.Notes = item.Notes.Where( s => s != null ).ToList();
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private void FillItemsWithUploads()
        {
            List<int> uploadIds = this.Items.Select( s => s.UploadId ).Distinct().ToList();

            ContentManagementDb db = new ContentManagementDb();

            Dictionary<int, Upload> uploads = new Dictionary<int, Upload>();

            db.Uploads.Join( uploadIds, o => o.UploadId, i => i, ( o, i ) => new { Key = i, Value = o } ).ToList().ForEach( s => uploads.Add( s.Key, s.Value ) );

            foreach ( TileGalleryItem item in this.Items )
            {
                item.UpdateUploadEntity( uploads[ item.UploadId ] );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonProperty( "items" )]
        public List<TileGalleryItem> Items { get; set; }

        [Display( Name = "Search" )]
        [JsonIgnore]
        public string SearchBox { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
