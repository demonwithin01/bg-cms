using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.HomePage
{
    [EditorLocation( "~/Views/Admin/HomePageTemplates/Ribbon.cshtml" )]
    [DisplayLocation( "~/Views/Home/HomePageTemplates/Ribbon.cshtml" )]
    public class Ribbon : HomePageTemplate
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public Ribbon()
        {
            Items = new List<RibbonItem>();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public override void PrepareForDisplay()
        {
            foreach ( RibbonItem item in Items )
            {
                item.PrepareForDisplay();
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Internal Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public List<RibbonItem> Items { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
