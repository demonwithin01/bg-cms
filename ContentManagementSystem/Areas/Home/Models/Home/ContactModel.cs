using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Models.Home
{
    public class ContactModel
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

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        [Display( Name = "Subject:" )]
        [Required( ErrorMessage = "Please enter in a subject" )]
        public string Subject { get; set; }

        [Display( Name = "Your Name:" )]
        [Required( ErrorMessage = "Please enter in your full name" )]
        public string FullName { get; set; }

        [Display( Name = "Message:" )]
        [Required( ErrorMessage = "Please enter in a message to send" )]
        public string Message { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}