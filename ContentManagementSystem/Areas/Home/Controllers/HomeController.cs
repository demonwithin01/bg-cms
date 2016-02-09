using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystem.Models.Home;

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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
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
