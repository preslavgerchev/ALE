﻿namespace AutomataLogicEngineering.TruthTable
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a single row in the truth table.
    /// </summary>
    public class TruthTableRow
    {
        /// <summary>
        /// Gets the list of all predicates in the row.
        /// </summary>
        public List<TruthTableCell> Cells { get; }

        /// <summary>
        /// Gets or sets the result when the predicates in this row are applied.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Indicates whether a row can be skipped when the truth table is being displayed.
        /// </summary>
        public bool CanBeSkipped { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TruthTableRow"/> class.
        /// </summary>
        /// <param name="cells">The predicates in the row.</param>
        public TruthTableRow(List<TruthTableCell> cells)
        {
            this.Cells = cells;
            this.CanBeSkipped = false;
        }

        /// <summary>
        /// Checks whether the two rows can be simplified. If so a new row is returned,
        /// else null is returned.
        /// </summary>
        /// <param name="otherRow">The other row to comparew with.</param>
        /// <returns>A new row or null.</returns>
        public TruthTableRow TrySimplifyRowOrNull(TruthTableRow otherRow)
        {
            if (this.Cells.Count != otherRow.Cells.Count)
            {
                throw new Exception("Internal error. Cannot compare to a row with different amount of predicates.");
            }

            var newCells = new List<TruthTableCell>();
            var amountOfSimplified = 0;
            var amountOfEqual = 0;
            for (var i = 0; i < this.Cells.Count; i++)
            {
                var firstCell = this.Cells[i];
                var secondCell = otherRow.Cells[i];

                if (firstCell.SymbolInCell != secondCell.SymbolInCell)
                {
                    newCells.Add(new TruthTableCell('*', firstCell.Id));
                    amountOfSimplified++;
                }
                else
                {
                    newCells.Add(firstCell);
                    amountOfEqual++;
                }
            }

            return amountOfSimplified == 1 && amountOfEqual + 1 == this.Cells.Count
                ? new TruthTableRow(newCells) { Result = this.Result }
                : null;
        }

        /// <summary>
        /// Checks whether the row is equal to the provided one.
        /// </summary>
        /// <param name="other">The other row.</param>
        /// <returns>True if the two rows are equal,else - false.</returns>
        public bool IsEqualTo(TruthTableRow other)
        {
            if (this.Cells.Count != other.Cells.Count)
            {
                throw new Exception("Internal error. Cannot compare to a row with different amount of predicates.");
            }

            for (var i = 0; i < this.Cells.Count; i++)
            {
                var firstCell = this.Cells[i];
                var secondCell = other.Cells[i];

                if (firstCell.SymbolInCell != secondCell.SymbolInCell)
                {
                    return false;
                }
            }

            return true;
        }
    }
}