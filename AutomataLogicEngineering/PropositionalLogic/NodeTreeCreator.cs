namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Collections.Generic;
    using Nodes;
    using Symbols;

    /// <summary>
    /// A static class, responsible for creating a tree out of a given string input.
    /// </summary>
    public static class NodeTreeCreator
    {
        /// <summary>
        /// Parses, validates and converts the input into a node tree, returning the 
        /// root node of the tree.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>The root node of the tree.</returns>
        public static Node Initialize(string input)
        {
            var symbols = Parser.ParseToSymbols(input);
            // TODO PREGER refactor validation
            // Validator.Validate(symbols);
            return NodeTreeCreator.CreateTree(symbols);
        }

        /// <summary>
        /// Creates a tree, given the parsed input as a list of symbols.
        /// </summary>
        /// <param name="input">The list of symbols.</param>
        /// <returns>The root node of the tree.</returns>
        private static Node CreateTree(IList<Symbol> input)
        {
            Node parentNode = null;
            foreach (var symbol in input)
            {
                if (symbol is Connective)
                {
                    if (parentNode == null)
                    {
                        parentNode = new Node(symbol);
                    }
                    else
                    {
                        Node node = new Node(symbol);
                        parentNode.AddChild(node);
                        parentNode = node;
                    }
                }
                else if (symbol is Predicate)
                {
                    if (parentNode == null)
                    {
                        parentNode = new Node(symbol);
                    }
                    else
                    {
                        Node node = new Node(symbol);
                        parentNode.AddChild(node);
                    }
                }
                else if (symbol is Parenthesis parenthesis)
                {
                    if (parenthesis.Side == ParenthesisSide.Closing)
                    {
                        if (parentNode?.Parent != null)
                            parentNode = parentNode?.Parent;
                    }
                }
            }

            return parentNode;
        }
    }
}