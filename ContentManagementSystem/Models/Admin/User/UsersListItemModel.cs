using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Admin.Models
{
    public class UsersListItemModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public UsersListItemModel()
        {

        }

        public UsersListItemModel( UserProfile user )
        {
            this.UserId = user.UserId;
            this.Username = user.UserName;
            this.EmailAddress = user.EmailAddress;
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

        public int UserId { get; set; }

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public DateTime LastLogin { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}