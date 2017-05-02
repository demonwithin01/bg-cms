using System.Web.Mvc;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    /// <summary>
    /// Provides extended functionality to the Html Helper for the purposes of creating buttons.
    /// </summary>
    public static class ButtonExtension
    {

        public static MvcHtmlString Button<TModel>( this HtmlHelper<TModel> helper, string text, ButtonType type, string id = null, string classes = null )
        {
            //TODO: Create signatures that do not utilise default values.
            //TODO: Comment.
            return RenderButton( text, type, "button", id, classes );
        }

        public static MvcHtmlString SubmitButton<TModel>( this HtmlHelper<TModel> helper, string text, string id = null, string classes = null )
        {
            //TODO: Create signatures that do not utilise default values.
            //TODO: Comment.
            return RenderButton( text, ButtonType.Primary, "submit", id, classes );
        }

        /// <summary>
        /// Creates the html required for a button.
        /// </summary>
        /// <param name="text">The text to display in the button.</param>
        /// <param name="buttonType">The type of button to render.</param>
        /// <param name="type">The button type attribute value.</param>
        /// <param name="id">The id to use on the button.</param>
        /// <param name="classes">The classes to use on the button.</param>
        /// <returns>The html of the generated button.</returns>
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
