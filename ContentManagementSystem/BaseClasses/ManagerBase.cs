using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.BaseClasses
{
    public class ManagerBase
    {
        private ContentManagementDb _db;

        public ContentManagementDb Database
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