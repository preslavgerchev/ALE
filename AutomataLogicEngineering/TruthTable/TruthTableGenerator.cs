namespace AutomataLogicEngineering.TruthTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nodes;
    using Symbols;

    /// <summary>
    /// A static class, responsible for generating a truth table out of a given root node.
    /// </summary>
    public class TruthTableGenerator
    {
        /// <summary>
        /// Generates a truth table for the given root node.
        /// </summary>
        /// <param name="node">The root node.</param>
        /// <returns>A truth table.</returns>
        public static TruthTable GenerateTruthTable(Node node)
        {
            var rows = new List<TruthTableRow>();
            var allPredicates = GetAllPredicates(node);
            var possibleCombinations = 1 << allPredicates.Count;
            for (var i = 0; i < possibleCombinations; i++)
            {
                var binaryRepresentation = Convert.ToString(i, 2).PadLeft(allPredicates.Count, '0');
                var rowList = binaryRepresentation
                    .Select((c, j) =>
                        new TruthTableCell(c == '1' ? '1' : '0', allPredicates[j].CharSymbol, allPredicates[j].Id))
                    .ToList();
                rows.Add(new TruthTableRow(rowList));
            }

            return new TruthTable(rows);
        }

        /// <summary>
        /// Finds all predicates in the given root node and its children.
        /// </summary>
        /// <param name="node">The root node.</param>
        /// <returns>A list of all predicates in the root node and its children.</returns>
        public static List<Predicate> GetAllPredicates(Node node)
        {
            var predicatesList = new List<Predicate>();
            FindAndAddPredicates(node, predicatesList);
            return predicatesList;
        }

        /// <summary>
        /// If the <paramref name="node"/>'s symbol is a predicate then it will be added to the 
        /// <paramref name="predicates"/> list.
        /// </summary>
        /// <param name="node">The node to verify the symbol for.</param>
        /// <param name="predicates">The list to add the predicate to.</param>
        private static void FindAndAddPredicates(Node node, List<Predicate> predicates)
        {
            if (node.Symbol is Predicate pred && predicates.All(x => x.CharSymbol != pred.CharSymbol))
                predicates.Add(pred);

            if (!node.Children.Any())
                return;

            foreach (var child in node.Children)
            {
                FindAndAddPredicates(child, predicates);
            }
        }
    }
}
