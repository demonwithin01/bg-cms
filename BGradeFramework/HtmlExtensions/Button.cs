using System.Web.Mvc;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    /// <summary>
    /// Provides extended functionality to the Html Helper for the purposes of creating buttons.
    /// </summary>
    public static class ButtonExtension
    {
        /// <summary>
        /// Creates the html for a standard button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="type">The button display type.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString Button<TModel>( this HtmlHelper<TModel> helper, string text, ButtonType type )
        {
            return Button( helper, text, type, null, null );
        }

        /// <summary>
        /// Creates the html for a standard button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="type">The button display type.</param>
        /// <param name="id">The id to use for the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString Button<TModel>( this HtmlHelper<TModel> helper, string text, ButtonType type, string id )
        {
            return Button( helper, text, type, id, null );
        }

        /// <summary>
        /// Creates the html for a standard button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="type">The button display type.</param>
        /// <param name="id">The id to use for the button.</param>
        /// <param name="classes">Additional classes to add to the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString Button<TModel>( this HtmlHelper<TModel> helper, string text, ButtonType type, string id, string classes )
        {
            return RenderButton( text, type, "button", id, classes );
        }


        /// <summary>
        /// Creates the html for a submit button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString SubmitButton<TModel>( this HtmlHelper<TModel> helper, string text )
        {
            return SubmitButton( helper, text, null, null );
        }

        /// <summary>
        /// Creates the html for a submit button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="id">The id to use for the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString SubmitButton<TModel>( this HtmlHelper<TModel> helper, string text, string id )
        {
            return SubmitButton( helper, text, id, null );
        }

        /// <summary>
        /// Creates the html for a submit button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="id">The id to use for the button.</param>
        /// <param name="classes">Additional classes to add to the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString SubmitButton<TModel>( this HtmlHelper<TModel> helper, string text, string id, string classes )
        {
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
