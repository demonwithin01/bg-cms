using System.Collections.Generic;
using System.Web;

namespace ApollyonWebLibrary
{
    /// <summary>
    /// Provides new functionality to all strings.
    /// </summary>
    public static class StringHelpers
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
        /// Turns a model name into a human readable format.
        /// </summary>
        /// <param name="value">The string to be turned into a human readable format.</param>
        /// <returns>The model name in a human readable format.</returns>
        public static string HumanReadable( string value )
        {
            return value.Replace(
                string.Format( "%s|%s|%s",
                               "(?<=[A-Z])(?=[A-Z][a-z])",
                               "(?<=[^A-Z])(?=[A-Z])",
                               "(?<=[A-Za-z])(?=[^A-Za-z])"
                ),
                " "
            );
        }

        /// <summary>
        /// Maps the current path into a location on the server file system.
        /// </summary>
        /// <param name="path">The path to be mapped to the server file system.</param>
        /// <returns>The path mapped to the server file system.</returns>
        public static string MapToServer( string path )
        {
            return HttpContext.Current.Server.MapPath( path );
        }

        /// <summary>
        /// Repeats the string 'x' number of times.
        /// </summary>
        /// <param name="str">The string to be repeated.</param>
        /// <param name="count">The number of times to repeat the string.</param>
        public static string Repeat( string str, int count )
        {
            return Repeat( str, count, "" );
        }

        /// <summary>
        /// Repeats the string 'x' number of times.
        /// </summary>
        /// <param name="str">The string to be repeated.</param>
        /// <param name="count">The number of times to repeat the string.</param>
        /// <param name="separator">The separator between repeats.</param>
        public static string Repeat( string str, int count, string separator )
        {
            if( count < 1 )
            {
                return "";
            }

            List<string> strs = new List<string>();

            for( int i = 0 ; i < count ; i++ )
            {
                strs.Add( str );
            }

            return string.Join( separator, strs );
        }

        /// <summary>
        /// Converts the string to camel case.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        public static string ToCamelCase( string str )
        {
            if( string.IsNullOrEmpty( str ) ) return str;

            str = str.Trim();

            if( str == "" ) return str;

            for( int i = 0 ; i < str.Length ; i++ )
            {
                if( str[ i ] == ' ' && i + 1 < str.Length && char.IsLower( str[ i + 1 ] ) )
                {
                    string res = str.Substring( 0, i + 1 ) + char.ToUpper( str[ i + 1 ] );

                    if( i + 2 < str.Length )
                    {
                        res += str.Substring( i + 2 );
                    }

                    str = res;

                    i++;
                }
                else if( i == 0 && char.IsUpper( str[ i ] ) )
                {
                    str = char.ToLower( str[ i ] ) + str.Substring( 1 );
                }
            }

            str = str.Replace( " ", "" );

            return str;
        }

        /// <summary>
        /// Converts a camel case string to a sentence human readable equivalent, capitalising each word.
        /// </summary>
        /// <param name="str">The string to be converted from camel case.</param>
        public static string FromCamelCase( string str )
        {
            if( string.IsNullOrEmpty( str ) ) return str;

            str = char.ToUpper( str[ 0 ] ) + str.Substring( 1 );

            for( int i = 1 ; i < str.Length - 1 ; i++ )
            {
                if( char.IsLower( str[ i ] ) && char.IsUpper( str[ i + 1 ] ) )
                {
                    str = str.Substring( 0, i + 1 ) + " " + str.Substring( i + 1 );
                }
            }

            return str;
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
}
