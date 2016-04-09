using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework
{
    public static class CreateSelectList
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public static List<SelectListItem> FromEnum<TEnum>( TEnum selected ) where TEnum : struct, IConvertible
        {
            Array values = Enum.GetValues( typeof( TEnum ) );
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach ( var value in values )
            {
                SelectListItem item = new SelectListItem();
                selectList.Add( new SelectListItem()
                {
                    Text = ( (Enum)value ).GetDescription(),
                    Value = ( (int)value ).ToString()
                } );

            }
            
            return selectList;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
