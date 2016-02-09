using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManagementSystem.Areas.Home.Controllers
{
    public class SiteContentController : Controller
    {
        // GET: Home/SiteContent
        public ActionResult Index( string filename )
        {
            return View();
        }
    }
}