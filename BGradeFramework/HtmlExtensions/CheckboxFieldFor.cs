using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    /// <summary>
    /// Provides extended functionality to the Html Helper for the purposes of creating checkbox fields.
    /// </summary>
    public static class CheckboxFieldForExtension
    {
        /// <summary>
        /// Generates the html for rendering a checkbox field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <returns>The generated html for a checkbox field.</returns>
        public static MvcHtmlString CheckboxFieldFor<TModel>( this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression )
        {
            return CheckboxFieldFor( helper, expression, null, null );
        }

        /// <summary>
        /// Generates the html for rendering a checkbox field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="htmlAttributes">Any additional html attributes that are to be applied to the input field.</param>
        /// <returns>The generated html for a checkbox field.</returns>
        public static MvcHtmlString CheckboxFieldFor<TModel>( this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object htmlAttributes )
        {
            return CheckboxFieldFor( helper, expression, htmlAttributes, null );
        }

        /// <summary>
        /// Generates the html for rendering a checkbox field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="fieldAttributes">Any additional html attributes that are to be applied to the input field.</param>
        /// <param name="labelAttributes">Any additional html attributes that are to be applied to the input label.</param>
        /// <returns>The generated html for a checkbox field.</returns>
        public static MvcHtmlString CheckboxFieldFor<TModel>( this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object fieldAttributes, object labelAttributes, bool excludeLabelTag = false )
        {
            TagBuilder dt = new TagBuilder( "dt" );
            TagBuilder dd = new TagBuilder( "dd" );

            dt.InnerHtml = "&nbsp;";

            dd.AddCssClass( "checkbox-field" );

            dd.InnerHtml = helper.CheckBoxFor( expression, fieldAttributes ).ToString();
            dd.InnerHtml += helper.LabelFor( expression, labelAttributes ).ToString();
            dd.InnerHtml += helper.ValidationMessageFor( expression ).ToString();

            if ( excludeLabelTag )
            {
                return new MvcHtmlString( dd.ToString() );
            }

            return new MvcHtmlString( dt.ToString() + dd.ToString() );
        }
    }
}
