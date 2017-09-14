using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    public static class SectionScripts
    {
        /// <summary>
        /// Adds the section initialiser to the list of initialisers that will be rendered out as part of the page initialisation.
        /// The initialiser is expected to be a single line of JavaScript only.
        /// </summary>
        /// <param name="htmlHelper">The standard html helper.</param>
        /// <param name="initialiser">The string that will initialise this section.</param>
        /// <returns>An empty string, provided for Razor compatibility.</returns>
        public static MvcHtmlString SectionInit( this HtmlHelper htmlHelper, string initialiser )
        {
            object sectionInitIndex = htmlHelper.ViewContext.HttpContext.Items[ "_section_index_" ];

            int index = 0;

            if ( sectionInitIndex != null )
            {
                index = (int)sectionInitIndex;
            }

            initialiser = "_site.initialisePageSection(" + initialiser + ");";
            
            htmlHelper.ViewContext.HttpContext.Items[ "_section_init_" + index + "_" ] = initialiser;

            htmlHelper.ViewContext.HttpContext.Items[ "_section_index_" ] = ++index;

            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// Renders the section initialisers for the current page.
        /// </summary>
        /// <param name="htmlHelper">The standard html helper.</param>
        /// <returns>An mvc string with all the initialisers separated by new lines.</returns>
        public static MvcHtmlString RenderSectionInitialisers( this HtmlHelper htmlHelper )
        {
            StringBuilder stringBuilder = new StringBuilder();

            IDictionary items = htmlHelper.ViewContext.HttpContext.Items;
            var keys = items.Keys;
            
            foreach ( object key in keys )
            {
                if ( key.ToString().StartsWith( "_section_init_" ) )
                {
                    stringBuilder.AppendLine( items[ key ].ToString() );
                }
            }

            return new MvcHtmlString( stringBuilder.ToString() );
        }
    }
}
