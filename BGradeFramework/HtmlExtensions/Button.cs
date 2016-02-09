using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    public static class ButtonExtension
    {
        public static MvcHtmlString Button<TModel>( this HtmlHelper<TModel> helper, string text, string id = null, string classes = null )
        {
            return RenderButton( text, "button", id, classes );
        }

        public static MvcHtmlString SubmitButton<TModel>( this HtmlHelper<TModel> helper, string text, string id = null, string classes = null )
        {
            return RenderButton( text, "submit", id, classes );
        }

        private static MvcHtmlString RenderButton( string text, string type, string id, string classes )
        {
            string button = "<button";

            if ( string.IsNullOrEmpty( id ) == false )
            {
                button += " id=\"" + id + "\"";
            }

            if ( string.IsNullOrEmpty( classes ) == false )
            {
                button += " classes=\"" + classes + "\"";
            }

            button += " type=\"" + type + "\">" + text + " </button>";

            return new MvcHtmlString( button );
        }
    }
}
