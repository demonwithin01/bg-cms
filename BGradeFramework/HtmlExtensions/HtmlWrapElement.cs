using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    public class HtmlWrapElement
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public HtmlWrapElement( string tag )
        {
            this.Tag = tag.ToLower();
            this.HtmlAttributes = new RouteValueDictionary();
        }

        public HtmlWrapElement( string tag, object htmlAttributes )
        {
            this.Tag = tag.ToLower();
            this.HtmlAttributes = new RouteValueDictionary( htmlAttributes );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public string Tag { get; private set; }

        public RouteValueDictionary HtmlAttributes { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
