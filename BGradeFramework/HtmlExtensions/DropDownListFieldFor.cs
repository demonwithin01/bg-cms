using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    /// <summary>
    /// Provides extended functionality to the Html Helper for the purposes of creating dropdown fields.
    /// </summary>
    public static class DropDownListFieldForExtension
    {
        /// <summary>
        /// Generates the html for rendering a dropdown field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <typeparam name="TProperty">The property type that the value is to be set/retrieved on/from.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="selectList">The items to display in the dropdown.</param>
        /// <returns>The generated html for a dropdown field.</returns>
        public static MvcHtmlString DropDownListFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList )
        {
            return DropDownListFieldFor( helper, expression, selectList, null, null );
        }

        /// <summary>
        /// Generates the html for rendering a dropdown field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <typeparam name="TProperty">The property type that the value is to be set/retrieved on/from.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="selectList">The items to display in the dropdown.</param>
        /// <param name="optionLabel">The label to use when there is no item selected.</param>
        /// <returns>The generated html for a dropdown field.</returns>
        public static MvcHtmlString DropDownListFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel )
        {
            return DropDownListFieldFor( helper, expression, selectList, optionLabel, null );
        }

        /// <summary>
        /// Generates the html for rendering a dropdown field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <typeparam name="TProperty">The property type that the value is to be set/retrieved on/from.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="selectList">The items to display in the dropdown.</param>
        /// <param name="htmlAttributes">Any additional html attributes that are to be applied to the input field.</param>
        /// <returns>The generated html for a dropdown field.</returns>
        public static MvcHtmlString DropDownListFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes )
        {
            return DropDownListFieldFor( helper, expression, selectList, null, htmlAttributes );
        }

        /// <summary>
        /// Generates the html for rendering a dropdown field with the label.
        /// </summary>
        /// <typeparam name="TModel">The model type that the html helper is using.</typeparam>
        /// <typeparam name="TProperty">The property type that the value is to be set/retrieved on/from.</typeparam>
        /// <param name="helper">The instance of the html helper.</param>
        /// <param name="expression">The expression that defines access to the property to display.</param>
        /// <param name="selectList">The items to display in the dropdown.</param>
        /// <param name="optionLabel">The label to use when there is no item selected.</param>
        /// <param name="htmlAttributes">Any additional html attributes that are to be applied to the input field.</param>
        /// <returns>The generated html for a dropdown field.</returns>
        public static MvcHtmlString DropDownListFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes )
        {
            //TODO: Attempt to simplify and move to common method for all FieldFor methods.
            TagBuilder dt = new TagBuilder( "dt" );
            TagBuilder dd = new TagBuilder( "dd" );

            dt.InnerHtml = helper.LabelFor( expression ).ToString();
            dd.InnerHtml = helper.DropDownListFor( expression, selectList, optionLabel, htmlAttributes ).ToString();
            dd.InnerHtml += helper.ValidationMessageFor( expression ).ToString();

            return new MvcHtmlString( dt.ToString() + dd.ToString() );
        }
    }
}
