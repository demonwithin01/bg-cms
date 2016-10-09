using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class DomainManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public DomainModel GetDomainSettings()
        {
            Domain domain = UserSession.Current.CurrentDomain();

            return new DomainModel( domain );
        }
        
        public SaveResult SaveDomainSettings( DomainModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            Domain domain = db.Domains.Find( UserSession.Current.DomainId );

            AutoMap.Map( model, domain );

            domain.UpdateTimeStamp();

            db.SaveChanges();

            return SaveResult.Success;
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