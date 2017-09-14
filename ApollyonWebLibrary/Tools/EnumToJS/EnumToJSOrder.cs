namespace ApollyonWebLibrary.Tools
{
    /// <summary>
    /// Conversion ordering when converting a C# type to a JavaScript equivalent.
    /// </summary>
    public enum EnumToJSOrder
    {
        /// <summary>
        /// Leave the order as the order the types were added.
        /// </summary>
        Default,

        /// <summary>
        /// Sorts the types by the type name in an ascending order.
        /// </summary>
        Ascending,

        /// <summary>
        /// Sorts the types by the type name in a descending order.
        /// </summary>
        Descending
    }
}
