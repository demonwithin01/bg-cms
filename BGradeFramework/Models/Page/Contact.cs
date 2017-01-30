using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Framework.Models.Page.Sections;

namespace ContentManagementSystem.Framework.Models.Page
{
    [EditorLocation( "~/Areas/Admin/Views/Page/Templates/Contact.cshtml" )]
    [DisplayLocation( "~/Areas/Home/Views/Page/Templates/Contact.cshtml" )]
    public class Contact : PageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public Contact()
        {
            this.ContactSection = new ContactSection();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public ContactSection ContactSection { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
