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
    public class ManagerBase : IDisposable
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

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose( bool disposing )
        {
            if ( !disposedValue )
            {
                if ( disposing )
                {
                    if ( this._db != null ) this._db.Dispose();
                }
                
                disposedValue = true;
            }
        }
        
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose( true );
        }

        #endregion
    }
}