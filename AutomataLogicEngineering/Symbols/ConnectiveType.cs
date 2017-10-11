namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// An enumeration, representing all the possible connectives.
    /// </summary>
    public enum ConnectiveType
    {
        /// <summary>
        /// Represents the & connective.
        /// </summary>
        And = 0,

        /// <summary>
        /// Represents the ^ connective.
        /// </summary>
        Or = 1,

        /// <summary>
        /// Represents the ~ connective.
        /// </summary>
        Not = 2,

        /// <summary>
        /// Represents the > connective.
        /// </summary>
        Implication = 3,

        /// <summary>
        /// Represents the = connective.
        /// </summary>
        BiImplication = 4,

        /// <summary>
        /// Represents the % connective.
        /// </summary>
        Nandify = 5
    }
}
