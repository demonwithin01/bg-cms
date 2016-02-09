using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentManagementSystem.Framework.BaseClasses;
using ContentManagementSystemDatabase;

namespace ContentManagementSystem.BaseClasses
{
    public class AdminContentManagementController<T> : ContentManagementController where T : new()
    {
        private T _manager;

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
