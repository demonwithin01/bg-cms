using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystem.Models.Home;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Managers;

namespace ContentManagementSystem.Home.Controllers
{
    public class HomeController : BaseController
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        /// <summary>
        /// GET: /home/
        /// </summary>
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();

            HomePageManager manager = new HomePageManager();
            model.HomePageTemplateModel = manager.RetrieveHomePage();
            model.Title = UserCookie.Current.SiteName;
            
            return View( model );
        }

        /// <summary>
        /// GET: /home/about
        /// </summary>
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        /// <summary>
        /// GET: /home/contact
        /// </summary>
        public ActionResult Contact()
        {
            return View( new ContactModel() );
        }

        /// <summary>
        /// POST: /home/contact
        /// </summary>
        [HttpPost]
        public JsonResult Contact( ContactModel model )
        {
            return JsonActionResult( new ContentManagementSystem.Framework.ValidationResult( true ) );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

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
