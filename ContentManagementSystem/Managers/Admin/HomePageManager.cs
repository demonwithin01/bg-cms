using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

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

        /// <summary>
        /// Gets the model for the home page of the current domain.
        /// </summary>
        public HomePageModel GetHomePageModel()
        {
            ContentManagementDb db = new ContentManagementDb();

            HomePageModel model = new HomePageModel();

            string name;
            model.HomePageTemplateModel = base.RetrieveHomePage( out name );
            model.HomePageTemplate = name;
            
            return model;
        }

        /// <summary>
        /// Saves the home page model into the database.
        /// </summary>
        public SaveResult SaveHomePageModel( HomePageModel model )
        {
            try
            {
                ContentManagementDb db = new ContentManagementDb();

                DomainHomePage homePage = db.DomainHomePages.Find( UserSession.Current.DomainId );

                if ( homePage == null )
                {
                    homePage = db.DomainHomePages.AddNew();
                    homePage.DomainId = UserSession.Current.DomainId;
                }

                homePage.ModelType = model.HomePageTemplate;
                homePage.HomePage = JsonConvert.SerializeObject( model.HomePageTemplateModel );

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