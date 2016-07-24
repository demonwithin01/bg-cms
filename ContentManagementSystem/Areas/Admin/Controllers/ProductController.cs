using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role[] { Role.Administrator } )]
    public class ProductController : AdminContentManagementController<ProductManager>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        public ActionResult List()
        {
            return View( new ProductsListModel( base.Database ) );
        }

        public ActionResult Create()
        {
            return View( "Edit", new ProductModel() );
        }

        [HttpPost]
        public ActionResult Create( ProductModel model )
        {
            SaveResult result = base.Manager.SaveProduct( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "List" );
            }

            return View( "Edit", model );
        }

        public ActionResult Edit( int id )
        {
            return View( new ProductModel( id, base.Database ) );
        }

        [HttpPost]
        public ActionResult Edit( ProductModel model )
        {
            SaveResult result = base.Manager.SaveProduct( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "List" );
            }

            return View( model );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

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

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}