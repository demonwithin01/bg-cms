using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    

    public sealed class HtmlWrap : IDisposable
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        /// <summary>
        /// Holds a reference to the MVC html helper object.
        /// </summary>
        private HtmlHelper _htmlHelper;

        /// <summary>
        /// Holds an element to the element used to wrap around the html, if any.
        /// </summary>
        private HtmlWrapElement _element;

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new html wrapping object, responsible for writing out the element opening/closing tags.
        /// </summary>
        /// <param name="htmlHelper">A reference to the MVC html helper object.</param>
        /// <param name="element">The html helper element to wrap with.</param>
        public HtmlWrap( HtmlHelper htmlHelper, HtmlWrapElement element )
        {
            this._htmlHelper = htmlHelper;
            this._element = element;

            if ( this._element != null )
            {
                TagBuilder tagBuilder = new TagBuilder( this._element.Tag );

                foreach ( var attribute in this._element.HtmlAttributes )
                {
                    tagBuilder.Attributes.Add( attribute.Key, attribute.Value.ToString() );
                }

                htmlHelper.ViewContext.Writer.WriteLine( tagBuilder.ToString().Replace( "</" + this._element.Tag + ">", "" ) );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Renders out the closing tag if an element is specified.
        /// </summary>
        public void Dispose()
        {
            if ( this._element != null )
            {
                _htmlHelper.ViewContext.Writer.WriteLine( "</" + this._element.Tag + ">" );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }

    public static class HtmlWrapExtension
    {
        /// <summary>
        /// Allows html markup to be selectively wrapped by an element. If no element is provided, no extra markup is rendered.
        /// </summary>
        /// <param name="htmlHelper">A reference to the MVC html helper object.</param>
        /// <param name="element">The element, if any, to wrap the html in.</param>
        /// <returns>An object that provides the ability to include the html in a using statement.</returns>
        public static HtmlWrap Wrap( this HtmlHelper htmlHelper, HtmlWrapElement element )
        {
            return new HtmlWrap( htmlHelper, element );
        }
    }
}
