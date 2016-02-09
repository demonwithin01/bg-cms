using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class NavigationModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public NavigationModel()
        {

        }

        public NavigationModel( DomainNavigationItem navItem )
        {
            AutoMap.Map( navItem, this );
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

        public int? DomainNavigationItemId { get; set; }

        [Display( Name = "Page:" )]
        public int PageId { get; set; }

        [Display( Name = "Title:" )]
        public string Title { get; set; }

        [Display( Name = "Is Login Required?" )]
        public bool LoginRequired { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}