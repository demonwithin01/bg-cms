using System;
using System.IO;
using System.Text;

namespace ApollyonWebLibrary.Tools
{
    /// <summary>
    /// The JavaScript file generator.
    /// </summary>
    public abstract class JSFileGenerator
    {

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Class Members

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Constructor & Intialisation

        /// <summary>
        /// Configures the default values.
        /// </summary>
        protected JSFileGenerator()
        {
            this.AddGeneratedFileHeader = true;
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Public Methods

        /// <summary>
        /// Saves the content out under the specified filename.
        /// </summary>
        /// <param name="filename">The name of the file to save the generated JavaScript to.</param>
        public virtual void SaveAs( string filename )
        {
            StringBuilder fileContent = new StringBuilder();

            if ( string.IsNullOrEmpty( this.FileHeader ) == false )
            {
                fileContent.AppendLine( this.FileHeader );
            }

            if ( this.AddGeneratedFileHeader )
            {
                fileContent.AppendLine( "/** GENERATED FILE **/" );
            }

            GetFileContents( fileContent );

            try
            {
                TextWriter writer = new StreamWriter( filename );

                writer.Write( fileContent.ToString() );

                writer.Close();
            }
            catch( Exception exception )
            {
                throw new Exception( "The JS file could not be generated", exception );
            }
        }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Protected Methods

        /// <summary>
        /// Gets the file content to be rendered to the file.
        /// </summary>
        /// <param name="fileContent">The file content string builder.</param>
        protected abstract void GetFileContents( StringBuilder fileContent );

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Static Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Private Methods

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Properties

        /// <summary>
        /// Gets/Sets whether or not to add text to the top of the file indicating that this file is generated code.
        /// True by default.
        /// </summary>
        public bool AddGeneratedFileHeader { get; set; }

        /// <summary>
        /// Gets/Sets a file header to use at the top of the file.
        /// </summary>
        public string FileHeader { get; set; }

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

        #region Derived Properties

        #endregion

        /* ----------------------------------------------------------------------------------------------------------------------------------------- */

    }
}
