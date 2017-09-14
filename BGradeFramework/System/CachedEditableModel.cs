using System;
using ContentManagementSystem.Framework.BaseClasses;

namespace ContentManagementSystem.Framework
{
    public class CachedEditableModel
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public HomePageTemplate GetHomePageModel()// BaseController controller )
        {
            dynamic model = Activator.CreateInstance( ModelType );

            //controller.UpdateObjectModel( model );

            return ( model as HomePageTemplate );
        }

        public PageTemplate GetPageModel()// BaseController controller )
        {
            dynamic model = Activator.CreateInstance( ModelType );

            //controller.UpdateObjectModel( model );

            return ( model as PageTemplate );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        public string ModelName { get; set; }

        public string FriendlyName { get; set; }

        public string AssemblyQualifiedName { get; set; }

        public Type ModelType { get; set; }

        public string DisplayLocation { get; set; }

        public string EditorLocation { get; set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
