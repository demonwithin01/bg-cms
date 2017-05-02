using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    /// <summary>
    /// Provides extended functionality to the Html Helper for the purposes of creating password fields.
    /// </summary>
    public static class PasswordFieldForExtension
    {
        /// <summary>
        /// Generates the html for rendering a password field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <returns>The generated html for a password field.</returns>
        public static MvcHtmlString PasswordFieldFor<TModel>( this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression )
        {
            return PasswordFieldFor( helper, expression, null );
        }

        /// <summary>
        /// Generates the html for rendering a password field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="htmlAttributes">Any additional html attributes that are to be applied to the input field.</param>
        /// <returns>The generated html for a password field.</returns>
        public static MvcHtmlString PasswordFieldFor<TModel>( this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression, object htmlAttributes )
        {
            //TODO: Attempt to simplify and move to common method for all FieldFor methods.
            TagBuilder dt = new TagBuilder( "dt" );
            TagBuilder dd = new TagBuilder( "dd" );

            dt.InnerHtml = helper.LabelFor( expression ).ToString();
            dd.InnerHtml = helper.PasswordFor( expression, htmlAttributes ).ToString();
            dd.InnerHtml += helper.ValidationMessageFor( expression ).ToString();

            return new MvcHtmlString( dt.ToString() + dd.ToString() );
        }
    }
}
