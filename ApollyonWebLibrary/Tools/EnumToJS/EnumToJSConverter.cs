using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using ApollyonWebLibrary.Extensions;

namespace ApollyonWebLibrary.Tools
{
    /// <summary>
    /// Converts a series of enumeration types to a JavaScript equivalent and saves them out.
    /// </summary>
    public class EnumToJSConverter : JSFileGenerator
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members
           
        /// <summary>
        /// The namespace that the enumerated values are to be contained within.
        /// </summary>
        private string _namespace;

        /// <summary>
        /// Holds the collection of enum types to format.
        /// </summary>
        private List<Type> _toFormat;

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Converts a series of enumeration types to a JavaScript equivalent and saves them out.
        /// </summary>
        public EnumToJSConverter()
            : this ( null )
        {

        }

        /// <summary>
        /// Converts a series of enumeration types to a JavaScript equivalent and saves them out.
        /// </summary>
        /// <param name="namespace">The namespace/object that the enumerated values are to be contained within.</param>
        public EnumToJSConverter( string @namespace )
            : base()
        {
            this.AutoGenerateNamespaceSafeguard = true;
            this.Format = EnumToJSConversionFormat.Default;
            this.Order = EnumToJSOrder.Default;
            this.IndentationType = EnumToJSIndentation.Tab;

            this._namespace = @namespace;

            this._toFormat = new List<Type>();
        }
        
        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Adds the provided enumeration type to the JS file.
        /// If the type is not a valid enum, then nothing is added to the file.
        /// </summary>
        /// <typeparam name="T">The enumeration type.</typeparam>
        public void Add<T>()
        {
            Add( typeof( T ) );
        }

        /// <summary>
        /// Adds the provided enumeration type to the JS file.
        /// If the type is not a valid enum, then nothing is added to the file.
        /// </summary>
        /// <param name="type">The enumeration type.</param>
        public void Add( Type type )
        {
            if ( type.IsEnum == false )
            {
                throw new Exception( "The type provided must be an enumeration." );
            }

            this._toFormat.Add( type );
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        /// <summary>
        /// Joins the generated enumerations into the file.
        /// </summary>
        /// <param name="fileContent">The file content to add the enumerations to.</param>
        protected override void GetFileContents( StringBuilder fileContent )
        {
            List<string> enumerations = new List<string>();
            string prepend = "var ";
            List<Type> toFormat;

            switch( this.Order )
            {
                default:
                case EnumToJSOrder.Default:
                    toFormat = this._toFormat.ToList();
                    break;
                case EnumToJSOrder.Ascending:
                    toFormat = this._toFormat.OrderBy( s => s.Name ).ToList();
                    break;
                case EnumToJSOrder.Descending:
                    toFormat = this._toFormat.OrderByDescending( s => s.Name ).ToList();
                    break;
            }

            if ( string.IsNullOrEmpty( this._namespace ) == false )
            {
                if( this.AutoGenerateNamespaceSafeguard )
                {
                    prepend = GenerateNamespaceSafeguards();

                    fileContent.Append( prepend + Environment.NewLine );
                }
                
                prepend = this._namespace + ".";
            }

            foreach ( Type type in toFormat )
            {
                enumerations.Add( Convert( type, prepend ) );
            }

            fileContent.Append( string.Join( StringHelpers.Repeat( Environment.NewLine, 2 ), enumerations ) );
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        /// <summary>
        /// Converts the provided type to a JS equivalent.
        /// </summary>
        /// <param name="type">The enumeration type.</param>
        /// <param name="level">The level of indentation required.</param>
        private string Convert( Type type, string prepend = null )
        {
            string newLine = Environment.NewLine;
            string indentation = GetIndentation();

            const string format = "{0}: \"{1}\"";

            List<string> integerIndexed = new List<string>();
            List<string> nameIndexed = new List<string>();

            List<string> allIndices = new List<string>();

            IEnumerable<FieldInfo> fields = type.GetFields().Where( s => s.Name != "value__" );
            Type descriptionType = typeof( DescriptionAttribute );

            string typeName = type.Name;
            string enumName;

            switch( this.Format )
            {
                default:
                case EnumToJSConversionFormat.Default:
                    enumName = typeName;
                    break;

                case EnumToJSConversionFormat.CamelCase:
                    enumName = StringHelpers.ToCamelCase( typeName );
                    break;
            }

            foreach( FieldInfo field in fields )
            {
                DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute( field, descriptionType ) as DescriptionAttribute;

                int integerValue = (int)field.GetRawConstantValue();

                if( descriptionAttribute != null && !string.IsNullOrEmpty( descriptionAttribute.Description ) )
                {
                    integerIndexed.Add( string.Format( format, integerValue, descriptionAttribute.Description ) );
                }
                else
                {
                    integerIndexed.Add( string.Format( format, integerValue, field.Name ) );
                }

                nameIndexed.Add( string.Format( "\"{0}\": {1}", field.Name, integerValue ) );
            }

            allIndices.AddRange( integerIndexed );
            allIndices.AddRange( nameIndexed );

            if( allIndices.Count == 0 )
            {
                return string.Empty;
            }

            return prepend + enumName + " = {" + newLine + indentation + string.Join( "," + newLine + indentation, allIndices ) + newLine + "};";
        }

        /// <summary>
        /// Gets the indentation type in its string equivalent.
        /// </summary>
        /// <returns>The string equivalent of the indentation type.</returns>
        private string GetIndentation()
        {
            switch( this.IndentationType )
            {
                default:
                case EnumToJSIndentation.Tab:
                    return "\t";
                case EnumToJSIndentation.Space:
                    return " ";
                case EnumToJSIndentation.SpaceX2:
                    return "  ";
                case EnumToJSIndentation.SpaceX4:
                    return "    ";
            }
        }

        /// <summary>
        /// Generates the namespace creation code to ensure the namespace exists.
        /// </summary>
        /// <returns>The JavaScript required to generate the namespace.</returns>
        private string GenerateNamespaceSafeguards()
        {
            string[] split = this._namespace.Split( '.' );
            string result = "";

            for ( var i = 0 ; i < split.Length ; i++ )
            {
                string obj = "";

                for ( var j = 0 ; j < i ; j++ )
                {
                    obj += split[ j ] + ".";
                }

                obj += split[ i ];

                string toAppend = "var " + obj + " = " + obj + " || {};";

                result += toAppend + Environment.NewLine;
            }

            return result;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Gets/Sets whether or not to automatically generate the namespace object safeguards to ensure an object exists.
        /// </summary>
        public bool AutoGenerateNamespaceSafeguard { get; set; }

        /// <summary>
        /// Gets/Sets the format to use for generating the enumeration name.
        /// </summary>
        public EnumToJSConversionFormat Format { get; set; }

        /// <summary>
        /// Gets/Sets the order to sort the types when saving to the file.
        /// </summary>
        public EnumToJSOrder Order { get; set; }

        /// <summary>
        /// Gets/Sets the indentation type to use.
        /// </summary>
        public EnumToJSIndentation IndentationType { get; set; }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
