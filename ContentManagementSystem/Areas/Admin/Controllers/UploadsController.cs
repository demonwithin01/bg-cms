using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework;
using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role.Data[] { Role.Data.Administrator } )]
    public class UploadsController : AdminContentManagementController<UploadsManager>
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Page Actions
        
        public ActionResult List()
        {
            return View( new UploadsListModel( UserSession.Current.DomainId, base.Database ) );
        }

        public ActionResult Create()
        {
            return View( "Edit", base.Manager.GetUploadModel( null ) );
        }
        
        public ActionResult Edit( int id )
        {
            return View( base.Manager.GetUploadModel( id ) );
        }

        [HttpPost]
        public ActionResult Edit( UploadModel model )
        {
            SaveResult result = base.Manager.SaveImage( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "List" );
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