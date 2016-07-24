using ContentManagementSystem.Admin.Managers;
using ContentManagementSystem.Admin.Models;
using ContentManagementSystem.BaseClasses;
using ContentManagementSystem.Framework;
using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManagementSystem.Admin.Controllers
{
    [Authorization( new Role[] { Role.Administrator } )]
    public class UserController : AdminContentManagementController<UserManager>
    {
        public ActionResult List()
        {
            return View( new UsersListModel( UserSession.Current.DomainId, base.Database ) );
        }

        public ActionResult ViewUser( int id )
        {
            UserModel model = base.Manager.GetUserModel( id );

            return View( model );
        }

        [HttpPost]
        public ActionResult ViewUser( UserModel model )
        {
            SaveResult result = base.Manager.UpdateUser( model );

            if ( result.State == SaveResultState.Success )
            {
                return RedirectToAction( "List" );
            }

            return View( model );
        }
    }
}