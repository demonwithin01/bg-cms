using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    
    public static class CheckboxFieldForExtension
    {

        public static MvcHtmlString CheckboxFieldFor<TModel>( this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object htmlAttributes = null )
        {

            TagBuilder dt = new TagBuilder( "dt" );
            TagBuilder dd = new TagBuilder( "dd" );

            dt.InnerHtml = "&nbsp;";

            dd.AddCssClass( "checkbox-field" );

            dd.InnerHtml = helper.CheckBoxFor( expression, htmlAttributes ).ToString();
            dd.InnerHtml += helper.LabelFor( expression ).ToString();
            dd.InnerHtml += helper.ValidationMessageFor( expression ).ToString();

            return new MvcHtmlString( dt.ToString() + dd.ToString() );

        }

    }

}
