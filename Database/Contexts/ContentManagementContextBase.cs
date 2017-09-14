using System.Data.Entity;
using System.Diagnostics;

namespace ContentManagementSystemDatabase
{
    public class ContentManagementContextBase : DbContext
    {

        public ContentManagementContextBase()
            : base ( "ContentManagementSystem" )
        {
#if DEBUG
            this.Database.Log = ( text ) => Debug.WriteLine( text );
#endif
        }

    }
}
