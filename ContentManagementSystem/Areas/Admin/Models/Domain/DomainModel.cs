using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class DomainModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private List<Upload> _uploads;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public DomainModel()
        {

        }

        public DomainModel( Domain domain )
        {
            AutoMap.Map( domain, this );

            _uploads = new ContentManagementDb().Uploads.WhereActive().Where( s => s.DomainId == UserSession.Current.DomainId ).ToList();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public SelectList GetImageOptions( int? selectedValue )
        {
            return new SelectList( _uploads, "UploadId", "Title", selectedValue );
        }

        public SelectList GetThemeOptions()
        {
            string themesLocation = HttpContext.Current.Server.MapPath( ContentLocation.ThemesLocation );

            string[] themeNames = Directory.GetFiles( themesLocation, "*.min.css" );

            List<KeyValuePair<string, string>> themes = themeNames.Select( s => Path.GetFileNameWithoutExtension( s ).Replace( ".min", "" ) ).Select( s => new KeyValuePair<string, string>( s, s ) ).ToList();

            return new SelectList( themes, "Key", "Value", this.Theme );
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

        [Display( Name = "Background Image" )]
        public int? BackgroundUploadId { get; set; }

        [Display( Name = "Logo Image" )]
        public int? LogoUploadId { get; set; }
        
        [Display( Name = "Site Name" )]
        [Required( ErrorMessage = "Please enter in the name of your site" )]
        public string Name { get; set; }
        
        [Display( Name = "Theme" )]
        [Required( ErrorMessage = "Please select a theme for your site")]
        public string Theme { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}