using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ContentManagementSystem.Framework.Models.HomePage.ContentTypes;
using Newtonsoft.Json;

namespace ContentManagementSystem.Framework.Models.HomePage
{
    public class RibbonItemContent
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        public RibbonItemContent()
        {
            ContentType = ContentType.EditableContent;
            Content = new EditableContent();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Internal Methods

        internal void PrepareForDisplay()
        {
            Content.PrepareForDisplay();
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        private void Deserialize( string value )
        {
            switch ( ContentType )
            {
                case ContentType.EditableContent:
                    Content = JsonConvert.DeserializeObject<EditableContent>( value );
                    break;
                case ContentType.Banner:
                    Content = JsonConvert.DeserializeObject<Banner>( value );
                    break;
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public ContentType ContentType { get; set; }

        [AllowHtml]
        public string Html { get; set; }

        public string Dimensions { get; set; }

        [JsonIgnore]
        public ContentTypeBase Content { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        [JsonProperty( "contentJson" )]
        [AllowHtml]
        public string ContentJson
        {
            get
            {
                return JsonConvert.SerializeObject( Content );
            }
            set
            {
                Deserialize( value );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
