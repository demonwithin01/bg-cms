using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    

    public class HtmlWrap : IDisposable
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        HtmlHelper _htmlHelper;

        HtmlWrapElement _element;
        
        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

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
        public static HtmlWrap Wrap( this HtmlHelper htmlHelper, HtmlWrapElement element )
        {
            return new HtmlWrap( htmlHelper, element );
        }
    }
}
