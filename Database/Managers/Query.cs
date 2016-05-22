using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    public static class Query
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
        /// Gets the home page entity for the specified domain.
        /// </summary>
        /// <param name="domainId">The domain to get the home page for</param>
        public static DomainHomePage DomainHomePage( int domainId )
        {
            return new QueryOnlyDatabase().DomainHomePages.Find( domainId );
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
