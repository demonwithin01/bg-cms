using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.BaseClasses
{
    /// <summary>
    /// The admin content controller admin, providing a manager
    /// </summary>
    /// <typeparam name="T">The manager class type.</typeparam>
    public class AdminContentManagementController<T> : ContentManagementController where T : class, new()
    {
        /// <summary>
        /// Maintains an instance to the manager associated with the controlled.
        /// </summary>
        private T _manager;

        /// <summary>
        /// Gets the instance of the manager.
        /// </summary>
        protected T Manager
        {
            get
            {
                if ( this._manager == null )
                {
                    this._manager = new T();
                }
                
                return this._manager;
            }
        }
    }
}
