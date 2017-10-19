namespace AutomataLogicEngineering.TruthTable
{
    using System.Linq;
    using System.Collections.Generic;
    using Common;
    using Nodes;
    using Symbols;

    /// <summary>
    /// Represents a truth table.
    /// </summary>
    public class TruthTable
    {
        /// <summary>
        /// Indicates whether the current truth table has been simplified or not.
        /// </summary>
        private bool hasBeenSimplified = false;

        /// <summary>
        /// Gets the list of truth table rows.
        /// </summary>
        public List<TruthTableRow> Rows { get; }

        /// <summary>
        /// Gets the truth table header.
        /// </summary>
        public TruthTableHeader Header { get; }

        /// <summary>
        /// Gets the hexadecimal representation of the result.
        /// </summary>
        public string HexadecimalResult =>
            string.Join(
                    separator: string.Empty,
                    values: this.Rows.Select(x => x.ResultRepresentation).Reverse())
                .ToHexString();

        /// <summary>
        /// Gets a value, indicating whether this truth table can be converted to a DNF one.
        /// </summary>
        public bool CanBeConvertedToDnf => this.Rows.Any(x => x.Result);

        /// <summary>
        /// Gets a value, indicating whether this truth table can be converted to a CNF one.
        /// </summary>
        public bool CanBeConvertedToCnf => this.Rows.Any(x => !x.Result);

        /// <summary>
        /// Initializes a new instance of the <see cref="TruthTable"/> class.
        /// </summary>
        /// <param name="header">The truth table header.</param>
        /// <param name="rows">The truth table rows.</param>
        public TruthTable(TruthTableHeader header, List<TruthTableRow> rows)
        {
            this.Header = header;
            this.Rows = rows;
        }

        /// <summary>
        /// Simplifies the given truth table and returns a new truth table.
        /// </summary>
        /// <returns>The new, simplified truth table.</returns>
        public TruthTable Simplify()
        {
            var simplifiedTable = this.SimplifyTable();
            while (simplifiedTable.hasBeenSimplified)
            {
                simplifiedTable = simplifiedTable.SimplifyTable();
            }

            return simplifiedTable;
        }

        /// <summary>
        /// Calculates the result for each row given the node tree, represented by the
        /// <paramref name="rootNode"/>.
        /// </summary>
        /// <param name="rootNode">The root node of the node tree.</param>
        public void Calculate(Node rootNode)
        {
            foreach (var row in this.Rows)
            {
                this.AssignValues(rootNode, row);
                row.Result = rootNode.Apply();
            }
        }

        /// <summary>
        /// Converts the truth table to a DNF form.
        /// </summary>
        /// <returns>The string representation of the DNF form.</returns>
        public string ToDnfForm()
        {
            var dnfString = string.Empty;
            var trueRows = this.Rows.Where(x => x.Result).ToList();
            for (var i = 0; i < trueRows.Count; i++)
            {
                var stringifiedRow = trueRows[i].ToDnfSymbols();
                dnfString = i == 0 ? stringifiedRow : $"|({dnfString},{stringifiedRow})";
            }

            return dnfString;
        }

        /// <summary>
        /// Converts the truth table to a CNF form.
        /// </summary>
        /// <returns>The string representation of the CNF form.</returns>
        public string ToCnfForm()
        {
            var cnfString = string.Empty;
            var falseRows = this.Rows.Where(x => !x.Result).ToList();
            for (var i = 0; i < falseRows.Count; i++)
            {
                var stringifiedRow = falseRows[i].ToCnfSymbols();
                cnfString = i == 0 ? stringifiedRow : $"&({cnfString},{stringifiedRow})";
            }

            return cnfString;
        }

        /// <summary>
        /// Simplifies the given truth table and returns a new truth table.
        /// </summary>
        /// <returns>The new, simplified truth table.</returns>
        private TruthTable SimplifyTable()
        {
            var simplified = false;
            var newRows = new List<TruthTableRow>();
            for (var i = 0; i < this.Rows.Count; i++)
            {
                var simplifiedRows = this.SimplifyForRow(i);
                if (simplifiedRows.Any())
                {
                    simplified = true;
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

            return new TruthTable(this.Header, filteredRows) { hasBeenSimplified = simplified };
        }

        /// <summary>
        /// Assigns the values from the predicates of given truth table row to the root node and
        /// its children.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="row">The truth table row.</param>
        private void AssignValues(Node rootNode, TruthTableRow row)
        {
            foreach (var cell in row.Cells)
            {
                this.AssignValueToNode(rootNode, cell);
            }
        }

        /// <summary>
        /// Assigns the given <paramref name="cell"/>'s value to the predicate it matches
        /// in the provided node and its children.
        /// </summary>
        /// <param name="node">The node to whose predicate the value will be assigned to.</param>
        /// <param name="cell">The cell the value of which should be assigned.</param>
        private void AssignValueToNode(Node node, TruthTableCell cell)
        {
            if (node.Symbol.Id == cell.Id && node.Symbol is Predicate pred && !pred.IsDigit)
            {
                pred.Value = cell.SymbolInCell == '1';
            }
            else
            {
                if (!node.Children.Any())
                    return;

                foreach (var child in node.Children)
                {
                    AssignValueToNode(child, cell);
                }
            }
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
