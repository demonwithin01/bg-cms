using ContentManagementSystemDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagementSystem.BaseClasses
{
    /// <summary>
    /// Provides the bases for a data manager.
    /// </summary>
    public class ManagerBase
    {
        /// <summary>
        /// Holds a reference to a database instance.
        /// </summary>
        private ContentManagementDb _db;

        /// <summary>
        /// Gets an instance of the database.
        /// </summary>
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