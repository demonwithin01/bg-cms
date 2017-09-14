using ContentManagementSystem.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Admin.Models
{
    public class HomePageModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [Display( Name = "Template" ), Required( ErrorMessage = "Please select a home page template" )]
        public string HomePageTemplate { get; set; }

        public HomePageTemplate HomePageTemplateModel { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}