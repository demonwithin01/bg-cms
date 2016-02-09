using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class ProductManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public SaveResult SaveProduct( ProductModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            Product product = db.Products.Find( model.ProductId );

            if ( product == null )
            {
                return CreateProduct( model, db );
            }

            return UpdateProduct( product, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private SaveResult CreateProduct( ProductModel model, ContentManagementDb db )
        {
            try
            {
                Product product = db.Products.Create();
                product.Initialise();

                AutoMap.Map( model, product );

                product.DomainId = UserSession.Current.DomainId;

                db.Products.Add( product );

                UpdateProductImages( product, model );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch// ( Exception ex )
            {
                return SaveResult.Fail;
            }
        }

        private SaveResult UpdateProduct( Product product, ProductModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false )
                return SaveResult.AccessDenied;

            if ( UserSession.Current.CurrentDomain( db ).CanAccess( product ) == false )
                return SaveResult.IncorrectDomain;

            try
            {
                AutoMap.Map( model, product );
                product.UpdateTimeStamp();

                UpdateProductImages( product, model );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch// ( Exception ex )
            {
                return SaveResult.Fail;
            }
        }

        private void UpdateProductImages( Product product, ProductModel model )
        {
            product.ProductImages.ToList().ForEach( s => s.IsDeleted = true );

            if ( model.ProductImageModels != null )
            {
                foreach ( ProductImageModel productImageModel in model.ProductImageModels )
                {
                    ProductImage productImage = product.ProductImages.FirstOrDefault( s => s.UploadId == productImageModel.UploadId );

                    if ( productImage == null )
                    {
                        productImage = new ProductImage();
                        productImage.Initialise();

                        productImage.UploadId = productImageModel.UploadId;

                        product.ProductImages.Add( productImage );
                    }

                    productImage.Ordinal = productImageModel.Ordinal;
                    productImage.IsDeleted = false;
                }
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}