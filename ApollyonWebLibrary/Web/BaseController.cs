﻿using System.IO;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ApollyonWebLibrary.Web
{
    /// <summary>
    /// The base controller which provides common functionality to all site actions/controllers.
    /// </summary>
    public class BaseController : Controller
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        /// <summary>
        /// The application/json content type.
        /// </summary>
        private const string applicationJson = "application/json";

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

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

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
            if( string.IsNullOrEmpty( viewName ) )
            {
                viewName = base.ControllerContext.RouteData.GetRequiredString( "action" );
            }

            ViewData.Model = model;

            using( StringWriter writer = new StringWriter() )
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView( base.ControllerContext, viewName );
                ViewContext viewContext = new ViewContext( base.ControllerContext, viewResult.View, base.ViewData, base.TempData, writer );
                viewResult.View.Render( viewContext, writer );

                return writer.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// Returns JSON content using the newtonsoft json serializer.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ActionResult JsonContent( object result )
        {
            return Content( JsonConvert.SerializeObject( result ), applicationJson );
        }

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
