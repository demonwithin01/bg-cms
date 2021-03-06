﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class NavigationManager
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
        /// Gets the navigation item from the database.
        /// </summary>
        public NavigationModel GetNavigationModel( int? navItemId )
        {
            ContentManagementDb db = new ContentManagementDb();

            DomainNavigationItem navItem = db.DomainNavigationItems.Find( navItemId );

            if ( navItem == null ) return new NavigationModel();

            return new NavigationModel( navItem );
        }

        /// <summary>
        /// Saves the navigation item into the database.
        /// </summary>
        public SaveResult SaveNavigationItem( NavigationModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            DomainNavigationItem navItem = db.DomainNavigationItems.Find( model.DomainNavigationItemId );

            if ( navItem == null )
            {
                return CreateNavItem( model, db );
            }

            return UpdateNavItem( navItem, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Creates a new row in the database.
        /// </summary>
        private SaveResult CreateNavItem( NavigationModel model, ContentManagementDb db )
        {
            try
            {
                DomainNavigationItem navItem = new DomainNavigationItem();
                navItem.Initialise();

                AutoMap.Map( model, navItem );

                int domainId = UserSession.Current.DomainId;
                navItem.DomainId = domainId;

                navItem.Ordinal = db.DomainNavigationItems.Where( s => s.DomainId == domainId && s.IsDeleted == false ).Select( s => s.Ordinal ).Max() + 1;

                db.DomainNavigationItems.Add( navItem );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        /// <summary>
        /// Updates an existing row in the database.
        /// </summary>
        private SaveResult UpdateNavItem( DomainNavigationItem navItem, NavigationModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false ) return SaveResult.AccessDenied;
            
            if ( UserSession.Current.CurrentDomain().CanAccess( navItem ) == false ) return SaveResult.IncorrectDomain;

            try
            {
                AutoMap.Map( model, navItem );
                navItem.UpdateTimeStamp();

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}