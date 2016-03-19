using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Managers
{
    public class HomePageManager : ContentManagementSystem.Managers.HomePageManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public HomePageModel GetHomePageModel()
        {
            ContentManagementDb db = new ContentManagementDb();

            HomePageModel model = new HomePageModel();

            string name;
            model.HomePageTemplateModel = base.RetrieveHomePage( out name );
            model.HomePageTemplate = name;
            
            return model;
        }

        public SaveResult SaveHomePageModel( HomePageModel model )
        {
            ContentManagementDb db = new ContentManagementDb();

            return SaveResult.Fail;

            //if ( navItem == null )
            //{
            //    return CreateNavItem( model, db );
            //}

            //return UpdateNavItem( navItem, model, db );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private SaveResult CreateNavItem( NavigationModel model, ContentManagementDb db )
        {
            try
            {
                DomainNavigationItem navItem = new DomainNavigationItem();
                navItem.Initialise();

                AutoMap.Map( model, navItem );

                navItem.DomainId = UserSession.Current.DomainId;

                db.DomainNavigationItems.Add( navItem );

                db.SaveChanges();

                return SaveResult.Success;
            }
            catch
            {
                return SaveResult.Fail;
            }
        }

        private SaveResult UpdateNavItem( DomainNavigationItem navItem, NavigationModel model, ContentManagementDb db )
        {
            if ( UserSession.Current.IsAdministrator == false ) return SaveResult.AccessDenied;
            
            if ( UserSession.Current.CurrentDomain( db ).CanAccess( navItem ) == false ) return SaveResult.IncorrectDomain;

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