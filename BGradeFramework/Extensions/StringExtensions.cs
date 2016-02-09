using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContentManagementSystem.Framework
{
    public static class StringExtensions
    {

        public static string MapToServer( this string path )
        {
            return HttpContext.Current.Server.MapPath( path );
        }
    }
}
