using System.Web.Mvc;
using LowercaseRoutesMVC4;

namespace ContentManagementSystem.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea( AreaRegistrationContext context )
        {
            context.MapRouteLowercase(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { area = "Admin", action = "Index", id = UrlParameter.Optional },
                new string[] { "ContentManagementSystem.Admin.Controllers" }
            );

            context.MapRouteLowercase(
                "Admin_Home",
                "Admin/Home",
                new { Area = "Admin", controller = "Home", action = "Index" },
                new string[] { "ContentManagementSystem.Admin.Controllers" }
            );
        }
    }
}
