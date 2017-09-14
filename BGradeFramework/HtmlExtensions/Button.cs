using System.Web.Mvc;
using ApollyonWebLibrary.Extensions;

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
        /// Creates the html for a submit button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString SubmitButtonFor<TModel>( this HtmlHelper<TModel> helper, string formId, string text )
        {
            return SubmitButtonFor( helper, formId, text, null, ButtonType.Primary, null );
        }

        /// <summary>
        /// Creates the html for a submit button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="id">The id to use for the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString SubmitButtonFor<TModel>( this HtmlHelper<TModel> helper, string formId, string text, string id )
        {
            return SubmitButtonFor( helper, formId, text, id, ButtonType.Primary, null );
        }

        /// <summary>
        /// Creates the html for a submit button.
        /// </summary>
        /// <typeparam name="TModel">The model that the helper is based off.</typeparam>
        /// <param name="helper">The current html helper.</param>
        /// <param name="text">The text to display on the button.</param>
        /// <param name="id">The id to use for the button.</param>
        /// <returns>The generated html for the button.</returns>
        public static MvcHtmlString SubmitButtonFor<TModel>( this HtmlHelper<TModel> helper, string formId, string text, string id, ButtonType buttonType )
        {
            return SubmitButtonFor( helper, formId, text, id, buttonType, null );
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
        public static MvcHtmlString SubmitButtonFor<TModel>( this HtmlHelper<TModel> helper, string formId, string text, string id, ButtonType buttonType, string classes )
        {
            return RenderButton( text, buttonType, "button", id, classes, formId );
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
        private static MvcHtmlString RenderButton( string text, ButtonType buttonType, string type, string id, string classes, string formId = null )
        {
            string button = "<button";

            if ( string.IsNullOrEmpty( id ) == false )
            {
                button += " id=\"" + id + "\"";
            }

            classes = ( "button " + buttonType.GetDisplayText() + " " + ( classes ?? "" ) ).Trim();

            button += " class=\"" + classes + "\"";

            if ( formId != null )
            {
                button += " onclick=\"$('#" + formId + "').submit()\"";
            }

            button += " type=\"" + type + "\">" + text + " </button>";
            
            return new MvcHtmlString( button );
        }
    }
}
