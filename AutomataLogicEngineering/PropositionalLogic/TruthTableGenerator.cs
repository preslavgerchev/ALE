using System;

namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using Nodes;
    using Symbols;

    public class TruthTableGenerator
    {

        public static List<TruthTableRow> GenerateTruthTable(Node node)
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
                    var currentNode = allPredicates[j];
                    var predicate = new Predicate(currentNode.Symbol.CharSymbol)
                        {
                            Value = binaryRepresentation[j] == '1',
                            Id = currentNode.Symbol.Id
                        };
                    rowList.Add(predicate);
                }
                rows.Add(new TruthTableRow(rowList));
            }

            return rows;
        }

        public static List<Node> GetAllPredicates(Node node)
        {
            var nodeList = new List<Node>();
            TraverseNodes(node, ref nodeList);
            return nodeList;
        }

        private static void TraverseNodes(Node node, ref List<Node> predicates)
        {
            if (node.Symbol is Predicate)
                predicates.Add(node);

            if (!node.Children.Any())
                return;

            foreach (var child in node.Children)
            {
                TraverseNodes(child, ref predicates);
            }
        }
    }
}
