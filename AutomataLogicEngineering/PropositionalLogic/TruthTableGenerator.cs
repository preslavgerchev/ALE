namespace AutomataLogicEngineering.PropositionalLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nodes;
    using Symbols;
    using TruthTable;

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
            var possibleCombinations = Math.Pow(2, allPredicates.Count);
            for (var i = 0; i < possibleCombinations; i++)
            {
                var binaryRepresentation = Convert.ToString(i, 2).PadLeft(allPredicates.Count, '0');
                var rowList = new List<Predicate>();
                for (var j = 0; j < binaryRepresentation.Length; j++)
                {
                    var currentPredicate = allPredicates[j];
                    // Make a copy of the predicate such it can be found later on when calculating
                    // the outcome of the input.
                    rowList.Add(new Predicate(
                        currentPredicate.CharSymbol,
                        currentPredicate.Id,
                        binaryRepresentation[j] == '1'));
                }
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
        /// Assigns the values from the predicates of given truth table row to the root node and
        /// its children.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="row">The truth table row.</param>
        public static void AssignValues(Node rootNode, TruthTableRow row)
        {
            foreach (var predicate in row.Predicates)
            {
                AssignValueToNode(rootNode, predicate);
            }
        }

        /// <summary>
        /// If the <paramref name="node"/>'s symbol is a predicate then it will be added to the 
        /// <paramref name="predicates"/> list.
        /// </summary>
        /// <param name="node">The node to verify the symbol for.</param>
        /// <param name="predicates">The list to add the predicate to.</param>
        private static void FindAndAddPredicates(Node node, List<Predicate> predicates)
        {
            if (node.Symbol is Predicate pred)
                predicates.Add(pred);

            if (!node.Children.Any())
                return;

            foreach (var child in node.Children)
            {
                FindAndAddPredicates(child, predicates);
            }
        }

        /// <summary>
        /// Assigns the given <paramref name="predicate"/>'s value to the predicate it matches
        /// in the provided node and its children.
        /// </summary>
        /// <param name="node">The node to whose predicate the value will be assigned to.</param>
        /// <param name="predicate">The predicate the value of which should be assigned.</param>
        private static void AssignValueToNode(Node node, Predicate predicate)
        {
            if (node.Symbol.Id == predicate.Id && node.Symbol is Predicate pred)
            {
                pred.Value = predicate.Value;
            }
            else
            {
                if (!node.Children.Any())
                    return;

                foreach (var child in node.Children)
                {
                    AssignValueToNode(child, predicate);
                }
            }
        }
    }
}
