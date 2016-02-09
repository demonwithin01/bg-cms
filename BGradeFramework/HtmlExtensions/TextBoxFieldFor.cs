using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    
    public static class TextBoxFieldForExtensions
    {

        public static MvcHtmlString TextBoxFieldFor<TModel, TProperty>( this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null )
        {

            TagBuilder dt = new TagBuilder( "dt" );
            TagBuilder dd = new TagBuilder( "dd" );

            dt.InnerHtml = helper.LabelFor( expression ).ToString();
            dd.InnerHtml = helper.TextBoxFor( expression, htmlAttributes ).ToString();
            dd.InnerHtml += helper.ValidationMessageFor( expression ).ToString();

            return new MvcHtmlString( dt.ToString() + dd.ToString() );

        }

    }

}
