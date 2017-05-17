using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.Page
{
    [EditorLocation( "~/Views/Admin/PageTemplates/Shop.cshtml" )]
    [DisplayLocation( "~/Areas/Home/Views/Page/Templates/Shop.cshtml" )]
    public class Shop : PageTemplate
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

        public string StoreId { get; set; }

        public int CategoriesPerRow { get; set; }
        
        

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
