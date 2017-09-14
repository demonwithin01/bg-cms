using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace ContentManagementSystem.Framework.HtmlExtensions
{
    /// <summary>
    /// Provides the information required to wrap razor html in an element with the provided tag.
    /// </summary>
    public class HtmlWrapElement
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        /// <summary>
        /// Creates a new object to wrap razor html with.
        /// </summary>
        /// <param name="tag">The tag to wrap the html with.</param>
        public HtmlWrapElement( string tag )
        {
            this.Tag = tag.ToLower();
            this.HtmlAttributes = new RouteValueDictionary();
        }

        /// <summary>
        /// Creates a new object to wrap razor html with.
        /// </summary>
        /// <param name="tag">The tag to wrap the html with.</param>
        /// <param name="htmlAttributes">Attributes to add to the tag.</param>
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

        /// <summary>
        /// Gets the tag to wrap the razor html with.
        /// </summary>
        public string Tag { get; private set; }

        /// <summary>
        /// Gets the attributes to add to the wrapping element.
        /// </summary>
        public RouteValueDictionary HtmlAttributes { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
