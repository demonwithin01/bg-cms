using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.Page
{
    [EditorLocation( "~/Views/Admin/PageTemplates/ImageNavigation.cshtml" )]
    [DisplayLocation( "~/Views/Home/PageTemplates/ImageNavigation.cshtml" )]
    public class ImageNavigation : PageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        [JsonIgnore]
        private List<SelectListItem> _selectList;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ImageNavigation()
        {
            base.HideBackgroundColor = true;

            this.NavigationItems = new List<ImageNavigationItem>();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void InitialiseForEditor()
        {
            base.InitialiseForEditor();

            _selectList = CreateSelectList.Pages( null );

            foreach ( ImageNavigationItem item in this.NavigationItems )
            {
                item.ImageNavigation = this;
            }
        }

        public override void OnBeforeSave()
        {
            base.OnBeforeSave();

            List<int> uploadIds = this.NavigationItems.Select( s => s.UploadId ).ToList();

            ContentManagementDb db = new ContentManagementDb();

            List<Upload> uploads = db.Uploads.Join( uploadIds, o => o.UploadId, i => i, ( o, i ) => o ).ToList();

            foreach ( ImageNavigationItem item in this.NavigationItems )
            {
                Upload upload = uploads.First( s => s.UploadId == item.UploadId );

                item.ImageUrl = upload.PhysicalLocation;
                item.NavigationUrl = "/page/" + item.PageId;
            }
        }

        public List<SelectListItem> NavPagesList()
        {
            return _selectList;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [JsonProperty( "navigationItems" )]
        public List<ImageNavigationItem> NavigationItems { get; set; }

        [Display( Name = "Search" )]
        [JsonIgnore]
        public string SearchBox { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
