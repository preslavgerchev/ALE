using System;

namespace AutomataLogicEngineering.TruthTable
{
    using System.Collections.Generic;
    using Symbols;

    /// <summary>
    /// Represents a single row in the truth table.
    /// </summary>
    public class TruthTableRow : IEquatable<TruthTableRow>
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


        /// <summary>
        /// TODO PREGER
        /// </summary>
        /// <param name="otherRow"></param>
        /// <returns></returns>
        public TruthTableRow TrySimplify(TruthTableRow otherRow)
        {
            if (this.Predicates.Count != otherRow.Predicates.Count)
            {
                throw new Exception("Internal error. Cannot compare to a row with different amount of predicates.");
            }

            var newPredicates = new List<Predicate>();
            var amountOfMatches = 0;
            for (var i = 0; i < this.Predicates.Count; i++)
            {
                var firstPredicate = this.Predicates[i];
                var secondPredicate = otherRow.Predicates[i];

                if (firstPredicate.Value == secondPredicate.Value)
                {
                    newPredicates.Add(new Predicate('*', Guid.NewGuid()));
                    amountOfMatches++;
                }
                else
                {
                    newPredicates.Add(firstPredicate);
                }
            }

            return amountOfMatches > 1 ? new TruthTableRow(newPredicates) : null;
        }

        public bool Equals(TruthTableRow other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (this.Predicates.Count != other.Predicates.Count)
            {
                throw new Exception("Internal error. Cannot compare to a row with different amount of predicates.");
            }

            for (var i = 0; i < this.Predicates.Count; i++) 
            {
                var firstPredicate = this.Predicates[i];
                var secondPredicate = other.Predicates[i];

                if (firstPredicate.CharSymbol != secondPredicate.CharSymbol)
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TruthTableRow)obj);
        }

        public override int GetHashCode()
        {
            return (Predicates != null ? Predicates.GetHashCode() : 0);
        }
    }
}
