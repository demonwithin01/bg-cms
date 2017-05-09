using System.Web.Mvc;

namespace ContentManagementSystem.Framework
{
    //TODO: Utilise from BGrade library.
    /// <summary>
    /// Forces the action or controller to only be available for an ajax request.
    /// </summary>
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        /// <summary>
        /// Checks to ensure the current request is an AJAX request.
        /// </summary>
        /// <param name="controllerContext">The current controller context.</param>
        /// <param name="methodInfo">The current controller action.</param>
        /// <returns>True if the request is an ajax request, false otherwise.</returns>
        public override bool IsValidForRequest( ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo )
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}
