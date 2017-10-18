namespace AutomataLogicEngineering.TruthTable
{
    using System.Collections.Generic;

    /// <summary>
    /// A class, that represents the header row of a truth table.
    /// </summary>
    public class TruthTableHeader
    {
        /// <summary>
        /// Gets the headers of the truth table.
        /// </summary>
        public List<string> Headers { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TruthTableHeader"/> class.
        /// </summary>
        /// <param name="headers">The headers to initialize with.</param>
        public TruthTableHeader(List<string> headers)
        {
            this.Headers = headers;
        }
    }
}
