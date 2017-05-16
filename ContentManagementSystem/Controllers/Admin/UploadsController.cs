using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.Framework;

namespace ContentManagementSystem.Controllers
{
    public partial class AdminController
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        #endregion

        /* ----------------------------------------------------------------------------------------------------------*/

        #region Page Actions

        [Route( "uploads/list" )]
        public ActionResult UploadsList()
        {
            return View( new UploadsListModel( UserSession.Current.DomainId, base.Database ) );
        }
        
        [Route( "uploads/create" )]
        [Route( "uploads/edit/{id}" )]
        public ActionResult UploadsEdit( int? id = null )
        {
            UploadsManager manager = new UploadsManager();

            return View( manager.GetUploadModel( id ) );
        }

        [HttpPost]
        [Route( "uploads/create" )]
        [Route( "uploads/edit" )]
        [Route( "uploads/edit/{id}" )]
        public ActionResult UploadsEdit( UploadModel model )
        {
            UploadsManager manager = new UploadsManager();

            SaveResult result = manager.SaveImage( model );

            if( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "UploadsList" );
            }

            return View( model );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Ajax Actions

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

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

        #region Derived Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}