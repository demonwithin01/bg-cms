using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.BaseClasses
{
    public class ContentManagementController : BaseController
    {
        private ContentManagementDb _db;

        protected ContentManagementDb Database
        {
            get
            {
                if ( this._db == null )
                {
                    this._db = new ContentManagementDb();
                }

                return this._db;
            }
        }
    }
}
