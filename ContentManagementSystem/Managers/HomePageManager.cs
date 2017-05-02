using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;
using Newtonsoft.Json;

namespace ContentManagementSystem.Managers
{
    /// <summary>
    /// Contains all functionality related to retrieving and saving the home page information.
    /// </summary>
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
    
        /// <summary>
        /// Retrieves the home page template model for the current domain.
        /// </summary>
        /// <returns>The current domains home page template.</returns>
        public HomePageTemplate RetrieveHomePage()
        {
            string name;

            return RetrieveHomePage( out name );
        }

        /// <summary>
        /// Retrieves the home page template model for the current domain.
        /// </summary>
        /// <param name="name">Holds the name of the model type that was retrieved.</param>
        /// <returns>The current domains home page template.</returns>
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