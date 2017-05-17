using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;
using ContentManagementSystem.Admin.Managers;
using System.ComponentModel;

namespace ContentManagementSystem.Admin.Models
{
    public class PageModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public PageModel()
        {

        }

        public PageModel( Page page, PageManager pageManager )
        {
            PageContent pageContent = page.PageContent.OrderByDescending( s => s.UTCDateUpdated ).First();
            AutoMap.Map( pageContent, this );

            string modelType;

            this.PageTemplateModel = pageManager.RetrievePage( pageContent, out modelType );

            this.ModelType = modelType;
        }

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

        public int? PageId { get; set; }

        [DisplayName( "Page Template" )]
        [Required( ErrorMessage = "Please select a page template" )]
        public string ModelType { get; set; }

        [DisplayName( "Title" )]
        [Required( ErrorMessage = "Please enter in a title" )]
        public string Title { get; set; }
        
        public bool Publish { get; set; }

        public PageTemplate PageTemplateModel { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}