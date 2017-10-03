namespace AutomataLogicEngineering.Test.HexadecimalTests
{
    /// <summary>
    /// Represents a hex pair - the string input and the hexadecimal result, that should be
    /// obtained after parsing and calculating the input.
    /// </summary>
    public class HexPair
    {
        /// <summary>
        /// Gets or sets the input in string format.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the expected hexadecimal result.
        /// </summary>
        public string ExpectedHex { get; set; }
    }
}
