using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystemDatabase
{
    public class ContentManagementContextBase : DbContext
    {

        public ContentManagementContextBase()
            : base ( "ContentManagementSystem" ) { }
        
    }
}
