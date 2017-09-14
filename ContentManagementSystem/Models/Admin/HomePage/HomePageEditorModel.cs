using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentManagementSystem.Framework.Models.HomePage;

namespace ContentManagementSystem.Admin.Models
{
    public class HomePageEditorModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public HomePageEditorModel( ContentType contentType, ContentTypeBase contentModel )
        {
            this.ContentType = contentType;
            this.ContentModel = contentModel;
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

        public ContentType ContentType { get; set; }

        public ContentTypeBase ContentModel { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}