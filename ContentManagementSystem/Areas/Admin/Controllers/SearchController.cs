using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role[] { Role.Administrator } )]
    public class SearchController : ContentManagementController
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        //[HttpPost]
        //public JsonResult Uploads( string term )
        //{
        //    ContentManagementDb db = new ContentManagementDb();

        //    term = ( term ?? "" ).ToLower();

        //    var uploads = db.Uploads.Where( s => s.DomainId == UserSession.Current.DomainId && s.Title.ToLower().Contains( term ) ).Take( 10 );

        //    return Json( new { uploads = uploads.Select( s => new { uploadId = s.UploadId, fileLocation = s.PhysicalLocation, title = s.Title } ) } );
        //}

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