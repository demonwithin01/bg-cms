using System.Web.Mvc;
using LowercaseRoutesMVC4;

namespace ContentManagementSystem.Areas.Home
{
    //public class HomeAreaRegistration : AreaRegistration
    //{
    //    public override string AreaName
    //    {
    //        get
    //        {
    //            return "Home";
    //        }
    //    }

    //    public override void RegisterArea( AreaRegistrationContext context )
    //    {
    //        context.MapRouteLowercase(
    //            "About",
    //            "About",
    //            new { area = "Home", controller = "Home", action = "About" },
    //            namespaces: new string[] { "ContentManagementSystem.Home.Controllers" }
    //        );

    //        context.MapRouteLowercase(
    //            name: "PageWithId",
    //            url: "Page/{pageId}",
    //            defaults: new { area = "Home", controller = "Page", action = "Index", id = UrlParameter.Optional },
    //            namespaces: new string[] { "ContentManagementSystem.Home.Controllers" }
    //        );

    //        context.MapRouteLowercase(
    //            name: "BlogPost",
    //            url: "post/{blogPostId}",
    //            defaults: new { area = "Home", controller = "BlogPost", action = "Index" },
    //            namespaces: new string[] { "ContentManagementSystem.Home.Controllers" } );

    //        //routes.MapRoute(
    //        //    name: "Default",
    //        //    url: "{controller}/{action}/{id}",
    //        //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    //        //    namespaces: new string[] { "ContentManagementSystem.Controllers" }
    //        //);

    //        //context.MapRouteLowercase(
    //        //    "Default",
    //        //    "{controller}/{action}/{id}",
    //        //    new { area = "Home", id = UrlParameter.Optional },
    //        //    namespaces: new string[] { "ContentManagementSystem.Home.Controllers" }
    //        //);

    //        context.MapRouteLowercase(
    //            "Home_Default",
    //            "Home/{controller}/{action}/{id}",
    //            new { area = "Home", id = UrlParameter.Optional },
    //            namespaces: new string[] { "ContentManagementSystem.Home.Controllers" }
    //        );

    //        context.MapRouteLowercase(
    //            "Home_Page",
    //            "",
    //            new { area = "Home", controller = "Home", action = "Index", id = UrlParameter.Optional },
    //            namespaces: new string[] { "ContentManagementSystem.Home.Controllers" }
    //        );
    //    }
    //}
}
