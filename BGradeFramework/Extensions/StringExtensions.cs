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
        public static string HumanReadable( this string value )
        {
            return value.Replace(
                string.Format( "%s|%s|%s",
                               "(?<=[A-Z])(?=[A-Z][a-z])",
                               "(?<=[^A-Z])(?=[A-Z])",
                               "(?<=[A-Za-z])(?=[^A-Za-z])"
                ),
                " "
            );
        }

        public static string MapToServer( this string path )
        {
            return HttpContext.Current.Server.MapPath( path );
        }
    }
}
