namespace AutomataLogicEngineering.TruthTable
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a truth table.
    /// </summary>
    public class TruthTable
    {
        /// <summary>
        /// Gets the list of truth table rows.
        /// </summary>
        public List<TruthTableRow> Rows { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TruthTable"/> class.
        /// </summary>
        /// <param name="rows">The truth table rows.</param>
        public TruthTable(List<TruthTableRow> rows)
        {
            this.Rows = rows;
        }
    }
}
