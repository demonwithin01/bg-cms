using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    public static class ButtonExtension
    {
        public static MvcHtmlString Button<TModel>( this HtmlHelper<TModel> helper, string text, ButtonType type, string id = null, string classes = null )
        {
            return RenderButton( text, type, "button", id, classes );
        }

        public static MvcHtmlString SubmitButton<TModel>( this HtmlHelper<TModel> helper, string text, string id = null, string classes = null )
        {
            return RenderButton( text, ButtonType.Primary, "submit", id, classes );
        }

        private static MvcHtmlString RenderButton( string text, ButtonType buttonType, string type, string id, string classes)
        {
            string button = "<button";

            if ( string.IsNullOrEmpty( id ) == false )
            {
                button += " id=\"" + id + "\"";
            }

            classes = ( "button " + buttonType.GetDescription() + " " + ( classes ?? "" ) ).Trim();

            button += " class=\"" + classes + "\"";

            button += " type=\"" + type + "\">" + text + " </button>";
            
            return new MvcHtmlString( button );
        }
    }
}
