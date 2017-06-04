using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.Page
{
    [EditorLocation( "~/Views/Admin/PageTemplates/TiledNavigation.cshtml" )]
    [DisplayLocation( "~/Views/Home/PageTemplates/TiledNavigation.cshtml" )]
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
            this.NavigationItems = new List<ImageNavigationItem>();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void InitialiseForEditor()
        {
            base.InitialiseForEditor();

            _selectList = CreateSelectList.NavPages( null );

            foreach ( ImageNavigationItem item in this.NavigationItems )
            {
                item.ImageNavigation = this;
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
