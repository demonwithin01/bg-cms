using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Shop.Models
{
    public class ProductsListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ProductsListModel()
        {
            ProductsContext productsRepository = new ProductsContext();

            this.Products = productsRepository.Products.WhereActive().Where( s => s.DomainId == UserCookie.Current.DomainId ).ToList().Select( s => new ProductsListItemModel( s ) ).ToList();
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

        public List<ProductsListItemModel> Products
        {
            get; set;
        }

        [Display( Name = "Category" )]
        public int ProductCategoryId
        {
            get;
            set;
        }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}