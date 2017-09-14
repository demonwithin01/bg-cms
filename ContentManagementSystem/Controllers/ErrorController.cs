using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManagementSystem.Controllers
{
    [RouteArea( "error" )]
    public class ErrorController : Controller
    {
        [Route( "not-found" )]
        public ActionResult NotFound()
        {
            return View();
        }

        [Route( "" )]
        public ActionResult ServerError()
        {
            return View();
        }
    }
}