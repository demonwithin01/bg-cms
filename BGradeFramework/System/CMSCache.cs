using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Framework
{
    public static class CMSCache
    {

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Constructors/Initialisation

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        public static void Load()
        {
            LoadEditableModels( "ContentManagementSystem.Framework.Models.HomePage", HomePages );
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Loads all editable models into memory for the specified namespace.
        /// </summary>
        /// <param name="@namespace">The namespace to load the models from</param>
        /// <param name="list">The list to load the models into</param>
        private static void LoadEditableModels( string @namespace, Dictionary<string, CachedEditableModel> list )
        {
            List<Type> types = Assembly.GetAssembly( typeof( CMSCache ) ).GetTypes().Where( s => s.Namespace == @namespace ).ToList();

            list = new Dictionary<string, CachedEditableModel>();

            foreach ( Type type in types )
            {
                DisplayLocationAttribute displayAttribute = type.GetCustomAttribute<DisplayLocationAttribute>();
                EditorLocationAttribute editorAttribute = type.GetCustomAttribute<EditorLocationAttribute>();

                if ( displayAttribute == null || editorAttribute == null )
                {
                    continue;
                }

                CachedEditableModel model = new CachedEditableModel()
                {
                    DisplayLocation = displayAttribute.Location,
                    EditorLocation = editorAttribute.Location,
                    ModelName = type.Name,
                    AssemblyQualifiedName = type.AssemblyQualifiedName,
                    ModelType = type
                };

                list.Add( model.ModelName, model );
            }
        }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Holds all the cached home page models.
        /// </summary>
        public static Dictionary<string, CachedEditableModel> HomePages { get; private set; }

        #endregion

        /* ---------------------------------------------------------------------------------------------------------- */

    }
}
