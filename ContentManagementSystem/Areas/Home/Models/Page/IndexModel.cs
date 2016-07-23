﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;
using ContentManagementSystem.Managers;

namespace ContentManagementSystem.Models.Page
{
    public class IndexModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public IndexModel()
        {

        }

        public IndexModel( PageContent page, PageTemplate pageTemplate )
        {
            this.Title = page.Title;
            this.PageTemplate = pageTemplate;
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

        public string Title { get; set; }
        
        public PageTemplate PageTemplate { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}