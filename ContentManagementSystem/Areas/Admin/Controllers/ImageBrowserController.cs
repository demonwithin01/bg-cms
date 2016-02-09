using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManagementSystem.Admin.Controllers
{
    public class ImageBrowserController : Controller
    {
        // GET: Admin/ImageBrowser
        public ActionResult Select()
        {
            return View();
        }
    }
}