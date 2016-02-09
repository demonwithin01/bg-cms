using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystemDatabase.BaseClasses;

namespace ContentManagementSystemDatabase
{
    public partial class Domain
    {
        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public bool CanAccess( IDomainRestricted toCheck )
        {
            return ( this.DomainId == toCheck.DomainId );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        /// <summary>
        /// Finds the domain record that matches the url specified.
        /// </summary>
        public static Domain FindMatchedDomain( Uri uri, ContentManagementDb db = null )
        {
            string url = uri.Authority.ToLower();

            db = db ?? new ContentManagementDb();

            return db.Domains.FirstOrDefault( d => d.DomainUrl.ToLower() == url );
        }

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
