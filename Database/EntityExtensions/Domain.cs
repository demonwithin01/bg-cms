using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /// <summary>
        /// Determines if the provided entity can be accessed by this domain.
        /// </summary>
        /// <param name="toCheck">The item to check access for.</param>
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

            if ( url.StartsWith( "www." ) )
            {
                url = url.Substring( "www.".Length );
            }

            db = db ?? new ContentManagementDb();

            return db.Domains.Include( s => s.BackgroundUpload ).Include( s => s.LogoUpload ).FirstOrDefault( d => d.DomainUrl.ToLower() == url );
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
