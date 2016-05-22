using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Helpers
{
    public class SelectListGenerator
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        private ProductsContext _productRepository;

        #endregion
        
        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public SelectList HomePageTemplates( string selected )
        {
            IEnumerable<CachedEditableModel> cachedModels = CMSCache.HomePages.Select( s => s.Value );

            return new SelectList( cachedModels, "ModelName", "FriendlyName", selected );
        }

        public SelectList ProductCategories( int? selected, bool canAddNew = false )
        {
            List<ProductCategory> productCategories = ProductRepository.ProductCategories.WhereActive().Where( s => s.DomainId == UserCookie.Current.DomainId ).ToList();

            productCategories = productCategories.OrderBy( p => p.Name ).ToList();

            productCategories.Insert( 0, new ProductCategory() { ProductCategoryId = 0, Name = "Add New Category" } );

            return new SelectList( productCategories, "ProductCategoryId", "Name", selected );
        }

        public SelectList ProductCategories( int? selected, string optionalText )
        {
            List<ProductCategory> productCategories = ProductRepository.ProductCategories.WhereActive().Where( s => s.DomainId == UserCookie.Current.DomainId ).ToList();

            productCategories = productCategories.OrderBy( p => p.Name ).ToList();

            productCategories.Insert( 0, new ProductCategory() { ProductCategoryId = 0, Name = optionalText } );

            return new SelectList( productCategories, "ProductCategoryId", "Name", selected );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        private ProductsContext ProductRepository
        {
            get
            {
                if ( _productRepository == null )
                    _productRepository = new ProductsContext();

                return _productRepository;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}