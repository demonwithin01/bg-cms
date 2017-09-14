using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ApollyonWebLibrary.Web
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Creates a MvcForm with the specified id attribute.
        /// </summary>
        public static MvcForm NamedForm( this HtmlHelper htmlHelper, string id )
        {
            return htmlHelper.BeginForm( null, null, FormMethod.Post, new { Id = id } );
        }
    }
}
