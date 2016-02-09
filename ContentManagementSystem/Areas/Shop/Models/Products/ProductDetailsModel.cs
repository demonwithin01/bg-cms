using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Shop.Models
{
    public class ProductDetailsModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ProductDetailsModel()
        {
        }

        public ProductDetailsModel( Product product )
        {
            AutoMap.Map( product, this );
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

        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockCount { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}