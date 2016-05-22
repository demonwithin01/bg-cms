using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Shop.Models;
using ContentManagementSystemDatabase;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystem.Framework;

namespace ContentManagementSystem.Areas.Shop.Controllers
{
    public class ProductsController : ContentManagementController
    {
        // GET: Shop/Products
        public ActionResult Index()
        {
            return View( new ProductsListModel() );
        }

        public void ProductDetails( int productId )
        {
            try
            {
                Product product = base.Database.Products.Find( productId );

                if ( product.DomainId == UserCookie.Current.DomainId )
                {
                    ProductDetailsModel model = new ProductDetailsModel( product );
                }
            }
            catch
            {

            }
        }
    }
}