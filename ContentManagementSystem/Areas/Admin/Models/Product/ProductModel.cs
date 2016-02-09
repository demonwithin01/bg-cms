using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class ProductModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ProductModel()
        {

        }

        public ProductModel( int productId, ContentManagementDb db )
        {
            Product product = db.Products.Find( productId );

            AutoMap.Map( product, this );

            this.ProductImageModels = product.ProductImages.Where( s => s.IsDeleted == false ).OrderBy( s => s.Ordinal ).ToList().Select( s => new ProductImageModel( s ) ).ToList();
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

        public int? ProductId { get; set; }

        [Display( Name = "Category" )]
        public int? ProductCategoryId { get; set; }

        [Display( Name = "Item No" )]
        public string ItemNo { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Display( Name = "Stock" ) ]
        public int StockCount { get; set; }
        
        public List<ProductImageModel> ProductImageModels { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}