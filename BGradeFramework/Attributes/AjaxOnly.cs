using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework
{
    
    /// <summary>
    /// Forces the action or controller to only be available for an ajax request.
    /// </summary>
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {

        public override bool IsValidForRequest( ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo )
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }

    }

}
