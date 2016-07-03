using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework.Models.HomePage
{
    public class RibbonItem
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public RibbonItem()
        {
            Columns = new List<RibbonItemContent>();
            Layout = RibbonColumns.OneColumn;
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

        public string Background { get; set; }

        public RibbonColumns Layout { get; set; }

        public string Height { get; set; }

        public List<RibbonItemContent> Columns { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
