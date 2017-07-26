using System.Web.Mvc;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Framework.Models.HomePage;
using ContentManagementSystem.Framework.Models.HomePage.ContentTypes;

namespace ContentManagementSystem.Controllers
{
    public partial class AdminController
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        [Route( "home-page/edit" )]
        public ViewResult HomePageEdit()
        {
            HomePageManager manager = new HomePageManager();
            return View( manager.GetHomePageModel() );
        }

        [HttpPost]
        [Route( "home-page/edit" )]
        public ActionResult HomePageEdit( HomePageModel model )
        {
            CachedEditableModel cachedModel = CMSCache.HomePages[ model.HomePageTemplate ];

            model.HomePageTemplateModel = GetHomePageModel( cachedModel );

            if( model.HomePageTemplateModel != null )
            {
                HomePageManager manager = new HomePageManager();
                SaveResult result = manager.SaveHomePageModel( model );

                if( result.State == SaveResultState.Success )
                {
                    return Redirect( "/admin" );
                }
            }

            return View( model );
        }

        [HttpPost]
        [Route( "home-page/edit/banner-editor" )]
        public ActionResult BannerEditorModal( Banner bannerModel )
        {
            bannerModel = bannerModel ?? new Banner();

            return PartialView( "EditorTemplates/Banner", bannerModel );
        }

        [HttpPost]
        public ActionResult LoadEditor( ContentType contentType )
        {
            ContentTypeBase contentModel = ContentTypeBase.CreateNewModel( contentType );

            if ( TryUpdateModel( contentModel ) == false )
            {

                return Json( null );
            }

            return PartialView();
        }
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}