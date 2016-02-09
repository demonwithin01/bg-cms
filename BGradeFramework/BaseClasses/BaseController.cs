using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using ContentManagementSystem.Framework;

namespace ContentManagementSystem.Framework.BaseClasses
{
    
    public class BaseController : Controller
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Turns a validation result into a json result to be returned to the webpage.
        /// </summary>
        /// <param name="result">The validation result</param>
        /// <param name="data">Any additional data to add to the json object</param>
        /// <returns>A json result constructed from the validation result</returns>
        public JsonResult JsonActionResult( ValidationResult result, object data = null )
        {

            RouteValueDictionary dictionary = new RouteValueDictionary( data );

            if ( result.Result )
            {
                dictionary.Add( "success", true );
                if ( result.DisplayNotification )
                {
                    dictionary.Add( "result", NotificationType.Confirmation.GetDescription() );
                }
            }
            else
            {
                dictionary.Add( "success", false );
                if ( result.DisplayNotification )
                {
                    dictionary.Add( "result", NotificationType.Error.GetDescription() );
                }
            }

            if ( result.DisplayNotification )
            {
                dictionary.Add( "displayNotification", true );
                dictionary.Add( "message", result.Message );
            }


            return ConvertRouteValueDictionaryToJSObject( dictionary );

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        protected override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            if ( UserSession.Current.IsValidUrl == false )
            {

            }
            
            base.OnActionExecuting( filterContext );
        }

        /// <summary>
        /// Converts a route value dictionary into a json result.
        /// </summary>
        /// <param name="dictionary">The route value dictionary to convert into a json object</param>
        /// <returns>A json result built from the provided route value dictionary. Automatically uses JsonRequestBehavior.AllowGet</returns>
        protected JsonResult ConvertRouteValueDictionaryToJSObject( RouteValueDictionary dictionary )
        {

            string encoded = System.Web.Helpers.Json.Encode( new DynamicJsonObject( dictionary ) ); ;
            dynamic jsObject = new JavaScriptSerializer().Deserialize<object>( encoded );

            return Json( jsObject, JsonRequestBehavior.AllowGet );

        }

        /// <summary>
        /// Renders a partial view to a string.
        /// </summary>
        /// <returns>The view as a string</returns>
        protected string RenderPartialViewToString()
        {
            return RenderPartialViewToString( null, null );
        }

        /// <summary>
        /// Renders a partial view to a string.
        /// </summary>
        /// <param name="viewName">The view name to render</param>
        /// <returns>The view as a string</returns>
        protected string RenderPartialViewToString( string viewName )
        {
            return RenderPartialViewToString( viewName, null );
        }

        /// <summary>
        /// Renders a partial view to a string.
        /// </summary>
        /// <param name="model">The model to send to the partial view</param>
        /// <returns>The view as a string</returns>
        protected string RenderPartialViewToString( object model )
        {
            return RenderPartialViewToString( null, model );
        }

        /// <summary>
        /// Renders a partial view to a string.
        /// </summary>
        /// <param name="viewName">The view name to render</param>
        /// <param name="model">The model to send to the partial view</param>
        /// <returns>The view as a string</returns>
        protected string RenderPartialViewToString( string viewName, object model )
        {

            if ( string.IsNullOrEmpty( viewName ) )
            {
                viewName = base.ControllerContext.RouteData.GetRequiredString( "action" );
            }

            ViewData.Model = model;

            using ( StringWriter writer = new StringWriter() )
            {

                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView( base.ControllerContext, viewName );
                ViewContext viewContext = new ViewContext( base.ControllerContext, viewResult.View, base.ViewData, base.TempData, writer );
                viewResult.View.Render( viewContext, writer );

                return writer.GetStringBuilder().ToString();

            }

        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }

}
