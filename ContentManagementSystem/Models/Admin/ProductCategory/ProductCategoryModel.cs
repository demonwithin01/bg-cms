using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class ProductCategoryModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ProductCategoryModel()
        {

        }

        public ProductCategoryModel( int productCategoryId, ContentManagementDb db )
        {
            ProductCategory productCategory = db.ProductCategories.Find( productCategoryId );

            AutoMap.Map( productCategory, this );
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
            
        public int? ProductCategoryId
        { get; set; }
        
        public string Name
        { get; set; }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}