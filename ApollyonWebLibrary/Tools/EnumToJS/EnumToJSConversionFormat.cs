namespace ApollyonWebLibrary.Tools
{
    /// <summary>
    /// Conversion formats for converting the name of an enumeration to a JavaScript equivalent.
    /// </summary>
    public enum EnumToJSConversionFormat
    {
        /// <summary>
        /// Use the same name as the enumeration type.
        /// </summary>
        Default,

        /// <summary>
        /// Converts the name of the enumeration to camel case.
        /// </summary>
        CamelCase
    }
}
