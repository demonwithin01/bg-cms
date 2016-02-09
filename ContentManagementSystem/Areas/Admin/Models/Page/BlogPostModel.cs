using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class BlogPostModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public BlogPostModel()
        {

        }

        public BlogPostModel( Page page )
        {
            PageContent pageContent = page.PageContent.OrderByDescending( s => s.UTCDateUpdated ).First();
            AutoMap.Map( pageContent, this );
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

        [Display( Name = "Page Title" )]
        public string Title { get; set; }

        [AllowHtml]
        [Display( Name = "Page Content" )]
        public string Content { get; set; }

        public bool Publish { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}