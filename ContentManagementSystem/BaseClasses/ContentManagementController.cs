using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.BaseClasses
{
    /// <summary>
    /// The default content controller base.
    /// </summary>
    public class ContentManagementController : BaseController
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        /// <summary>
        /// A reference to the content management database.
        /// </summary>
        private ContentManagementDb _db;

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

            if( result.Result )
            {
                dictionary.Add( "success", true );
                if( result.DisplayNotification )
                {
                    dictionary.Add( "result", NotificationType.Confirmation.GetDescription() );
                }
            }
            else
            {
                dictionary.Add( "success", false );
                if( result.DisplayNotification )
                {
                    dictionary.Add( "result", NotificationType.Error.GetDescription() );
                }
            }

            if( result.DisplayNotification )
            {
                dictionary.Add( "displayNotification", true );
                dictionary.Add( "message", result.Message );
            }
            
            return ConvertRouteValueDictionaryToJSObject( dictionary );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        /// <summary>
        /// Logs the exception into the database.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException( ExceptionContext filterContext )
        {
            ErrorLog.Error( "Unknown Exception", filterContext.Exception );

            base.OnException( filterContext );
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

        /// <summary>
        /// Gets the current reference to the content management database.
        /// </summary>
        public ContentManagementDb Database
        {
            get
            {
                return ( this._db ?? ( this._db = new ContentManagementDb() ) );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
