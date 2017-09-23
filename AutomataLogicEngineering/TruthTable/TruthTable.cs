using System.Linq;

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

        /// <summary>
        /// Simplifies the given truth table and returns a new truth table.
        /// </summary>
        /// <returns>The new, simplified truth table.</returns>
        public TruthTable Simplify()
        {
            var newRows = new List<TruthTableRow>();
            for (int i = 0; i < this.Rows.Count; i++)
            {
                var currentRow = this.Rows[i];
                for (var j = i + 1; j < this.Rows.Count; j++)
                {
                    var simplifiedRow = currentRow.TrySimplify(this.Rows[j]);

                    if (simplifiedRow != null)
                        newRows.Add(simplifiedRow);
                }
            }

            return new TruthTable(newRows.GroupBy(x => x.Predicates.Select(y => y.CharSymbol)).Select(z => z.First())
                .ToList());
        }
    }
}
