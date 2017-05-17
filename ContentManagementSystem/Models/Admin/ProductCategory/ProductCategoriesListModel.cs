using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class ProductCategoriesListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public ProductCategoriesListModel( ContentManagementDb db )
        {
            int domainId = UserSession.Current.DomainId;
            this.ProductCategories = db.ProductCategories.Where( p => p.DomainId == domainId ).ToList().Select( p => new ProductCategoriesListItemModel( p ) ).ToList();
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

        public List<ProductCategoriesListItemModel> ProductCategories { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}