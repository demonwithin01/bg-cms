using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.Page.Sections
{
    public class ContactSection : PageSectionTemplate
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

        [Display( Name = "Name" )]
        public string Name { get; set; }

        [Display( Name = "Email" )]
        public string EmailAddress { get; set; }

        [Display( Name = "Enquiry" )]
        public string Enquiry { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
