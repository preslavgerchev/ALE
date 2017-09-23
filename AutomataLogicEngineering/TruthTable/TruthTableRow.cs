namespace AutomataLogicEngineering.TruthTable
{
    using System.Collections.Generic;
    using Symbols;

    /// <summary>
    /// Represents a single row in the truth table.
    /// </summary>
    public class TruthTableRow
    {
        /// <summary>
        /// Gets the list of all predicates in the row.
        /// </summary>
        public List<Predicate> Predicates { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TruthTableRow"/> class.
        /// </summary>
        /// <param name="predicates">The predicates in the row.</param>
        public TruthTableRow(List<Predicate> predicates)
        {
            this.Predicates = predicates;
        }
    }
}
