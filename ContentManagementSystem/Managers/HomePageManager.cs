﻿using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.Managers
{
    public class HomePageManager
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public HomePageTemplate RetrieveHomePage()
        {
            string name;

            return RetrieveHomePage( out name );
        }

        public HomePageTemplate RetrieveHomePage( out string name )
        {
            DomainHomePage entity = Query.DomainHomePage( UserCookie.Current.DomainId );

            bool newNeeded = false;

            if ( entity == null )
            {
                newNeeded = true;
                entity = new DomainHomePage()
                {
                    ModelType = "Ribbon",
                    HomePage = ""
                };
            }

            name = entity.ModelType;

            CachedEditableModel cachedModel = CMSCache.HomePages[ entity.ModelType ];

            HomePageTemplate homePage = JsonConvert.DeserializeObject( entity.HomePage, cachedModel.ModelType ) as HomePageTemplate;

            if ( newNeeded )
            {
                homePage = new Framework.Models.HomePage.Ribbon();
            }

            homePage.DisplayLocation = cachedModel.DisplayLocation;
            homePage.EditorLocation = cachedModel.EditorLocation;

            return homePage;
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