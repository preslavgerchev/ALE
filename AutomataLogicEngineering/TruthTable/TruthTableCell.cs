namespace AutomataLogicEngineering.TruthTable
{
    using System;

    /// <summary>
    /// Represents a single truth table cell in a truth table row.
    /// </summary>
    public class TruthTableCell
    {
        /// <summary>
        /// Gets the symbol in the cell. Can be either '1', '0' or '*'.
        /// </summary>
        public char SymbolInCell { get; }

        /// <summary>
        /// Gets the unique identifier that can be used to identify a predicate such that a value
        /// can be assigned.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TruthTableCell"/> class.
        /// </summary>
        /// <param name="symbolInCell">The symbol in the truth table cell.</param>
        /// <param name="id">The unique identifier.</param>
        public TruthTableCell(char symbolInCell, Guid id)
        {
            this.SymbolInCell = symbolInCell;
            this.Id = id;
        }
    }
}