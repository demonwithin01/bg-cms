using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Framework.Models.HomePage.ContentTypes;

namespace ContentManagementSystem.Framework.Models.HomePage
{
    public abstract class ContentTypeBase
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Creates a new model that can be used to update from a post request.
        /// </summary>
        /// <param name="contentType">The content type to base the model from.</param>
        /// <returns>A derived instance of ContentTypeBase for the specified content type.</returns>
        public static ContentTypeBase CreateNewModel( ContentType contentType )
        {
            switch( contentType )
            {
                default:
                case ContentType.EditableContent:
                    return new EditableContent();

                case ContentType.Banner:
                    return new Banner();
            }
        }

        public abstract void PrepareForDisplay();

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Internal Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
