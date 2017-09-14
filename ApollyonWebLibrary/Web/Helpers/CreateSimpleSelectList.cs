using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ApollyonWebLibrary.Extensions;

namespace ApollyonWebLibrary.Web
{
    public static class CreateSimpleSelectList
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Generates a select list for a series of numbers.
        /// </summary>
        /// <param name="start">The initial number to start the loop from.</param>
        /// <param name="end">The last number to end the list on.</param>
        /// <param name="selected">The currently selected number.</param>
        public static List<SelectListItem> NumberList( int start, int end, int? selected )
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            bool reverse = false;

            if( start > end )
            {
                reverse = true;

                int temp = start;
                start = end;
                end = temp;
            }

            for( int i = start ; i <= end ; i++ )
            {
                string value = i.ToString();

                selectList.Add( new SelectListItem()
                {
                    Value = value,
                    Text = value,
                    Selected = ( i == selected )
                } );
            }

            if( reverse )
            {
                selectList.Reverse();
            }

            return selectList;
        }

        /// <summary>
        /// Creates a select list from the provided enumeration.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="selected">The currently selected enumeration.</param>
        public static List<SelectListItem> FromEnum<TEnum>( TEnum selected ) where TEnum : struct, IConvertible
        {
            return FromEnum( selected, (TEnum[])Enum.GetValues( typeof( TEnum ) ) );
        }
        
        /// <summary>
        /// Creates a select list from the provided enumeration.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="selected">The currently selected enumeration.</param>
        public static List<SelectListItem> FromEnum<TEnum>( TEnum selected, TEnum[] availableOptions ) where TEnum : struct, IConvertible
        {
            Array values = Enum.GetValues( typeof( TEnum ) );
            values = availableOptions;

            List<SelectListItem> selectList = new List<SelectListItem>();
            int selectedValue = Convert.ToInt32( selected );
            
            foreach( var value in values )
            {
                SelectListItem item = new SelectListItem();
                selectList.Add( new SelectListItem()
                {
                    Text = ( (Enum)value ).GetDisplayText(),
                    Value = ( (int)value ).ToString(),
                    Selected = (int)value == selectedValue
                } );

            }

            return selectList;
        }

        /// <summary>
        /// Creates a select list for a boolean.
        /// </summary>
        /// <param name="selected">Whether or not the 'true' label should be selected.</param>
        /// <param name="trueLabel">The label to use for the 'true' value. Defaults to 'Yes'.</param>
        /// <param name="falseLabel">The label to use for the 'false' value. Defaults to 'No'.</param>
        public static List<SelectListItem> ForBoolean( bool selected, string trueLabel = "Yes", string falseLabel = "No" )
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add( new SelectListItem() { Value = "true", Text = trueLabel, Selected = ( selected == true ) } );
            selectList.Add( new SelectListItem() { Value = "false", Text = falseLabel, Selected = ( selected == false ) } );

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
