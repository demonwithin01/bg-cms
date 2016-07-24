using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Models
{
    public class UsersListModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public UsersListModel( int domainId, ContentManagementDb db )
        {
            this.Users = db.Users.Where( s => s.DomainId == domainId ).ToList().Select( s => new UsersListItemModel( s ) ).ToList();
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

        public List<UsersListItemModel> Users { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}