using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    public class QueryOnlyDatabase : DbContext
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public QueryOnlyDatabase()
            : base( "ContentManagementSystem" )
        {
            base.Configuration.AutoDetectChangesEnabled = false;
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public DbSet<DomainHomePage> DomainHomePages { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
