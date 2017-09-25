namespace AutomataLogicEngineering.TruthTable
{
    using System.Linq;
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
        /// Gets a value indicating whether the truth table can be simplified.
        /// </summary>
        public bool CanBeSimplified => this.Rows.Count > this.Simplify().Rows.Count;
        
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
            for (var i = 0; i < this.Rows.Count; i++)
            {
                var simplifiedRows = this.SimplifyForRow(i);
                if (simplifiedRows.Any())
                {
                    newRows.AddRange(simplifiedRows);
                }
                else
                {
                    newRows.Add(this.Rows[i]);
                }
            }
            var filteredRows = new List<TruthTableRow>();
            foreach (var addedRow in newRows.Where(x => !x.CanBeSkipped).ToList())
            {
                if (!filteredRows.Any(x => x.IsEqualTo(addedRow)))
                {
                    filteredRows.Add(addedRow);
                }
            }
            return new TruthTable(filteredRows);
        }

        /// <summary>
        /// Simplifies a given row in <see cref="Rows"/> collection.
        /// </summary>
        /// <param name="index">The index of the row.</param>
        /// <returns>A list of simplified rows.</returns>
        private List<TruthTableRow> SimplifyForRow(int index)
        {
            var currentRow = this.Rows[index];
            var newRows = new List<TruthTableRow>();

            for (var i = index + 1; i < this.Rows.Count; i++)
            {
                var row = this.Rows[i];
                if (currentRow.Result != row.Result) continue;

                var simplifiedRow = currentRow.TrySimplifyRowOrNull(row);

                if (simplifiedRow != null)
                {
                    newRows.Add(simplifiedRow);
                    row.CanBeSkipped = true;
                }
            }

            return newRows;
        }
    }
}
