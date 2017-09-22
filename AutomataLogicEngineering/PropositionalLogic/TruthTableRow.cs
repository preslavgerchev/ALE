
namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Collections.Generic;
    using Symbols;

    public class TruthTableRow
    {
        public List<Predicate> Predicates { get; }

        public TruthTableRow(List<Predicate> predicates)
        {
            this.Predicates = predicates;
        }
    }
}
