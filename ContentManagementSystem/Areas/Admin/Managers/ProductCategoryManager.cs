using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class ProductCategoryManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods
            
        public SaveResult SaveProductCategory( ProductCategoryModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            ProductCategory productCategory = db.ProductCategories.Find( model.ProductCategoryId );

            if ( productCategory == null )
            {
                return CreateProductCategory( model, db );
            }

            return UpdateProductCategory( productCategory, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private SaveResult CreateProductCategory( ProductCategoryModel model, ContentManagementDb db )
        {
            try
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.Initialise();

                AutoMap.Map( model, productCategory );
                
                productCategory.DomainId = UserSession.Current.DomainId;

                db.ProductCategories.Add( productCategory );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch// (Exception ex)
            {
                return SaveResult.Fail;
            }
        }

        private SaveResult UpdateProductCategory( ProductCategory product, ProductCategoryModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false )
                return SaveResult.AccessDenied;

            if ( UserSession.Current.CurrentDomain().CanAccess( product ) == false )
                return SaveResult.IncorrectDomain;

            try
            {
                AutoMap.Map( model, product );
                product.UpdateTimeStamp();

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}