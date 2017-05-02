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

        public static MvcHtmlString DropDownListFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes = null )
        {
            //TODO: Create signatures that do not utilise default values.
            //TODO: Comment.
            //TODO: Attempt to simplify and move to common method for all FieldFor methods.
            TagBuilder dt = new TagBuilder( "dt" );
            TagBuilder dd = new TagBuilder( "dd" );
            
            dt.InnerHtml = helper.LabelFor( expression ).ToString();
            dd.InnerHtml = helper.DropDownListFor( expression, selectList, htmlAttributes ).ToString();
            dd.InnerHtml += helper.ValidationMessageFor( expression ).ToString();

            return new MvcHtmlString( dt.ToString() + dd.ToString() );
        }

        public static MvcHtmlString DropDownListFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes = null )
        {
            //TODO: Create signatures that do not utilise default values.
            //TODO: Comment.
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
