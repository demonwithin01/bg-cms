using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Shop.Models
{
    public class ProductsListItemModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ProductsListItemModel( Product product )
        {
            AutoMap.Map( product, this );

            this.IsInStock = ( product.StockCount > 0 );

            this.ImageLocation = product.ProductImages.First().Upload.PhysicalLocation;
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

        public int ProductId
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public decimal Price
        {
            get; set;
        }

        public bool IsInStock
        {
            get; set;
        }

        public string ImageLocation { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}