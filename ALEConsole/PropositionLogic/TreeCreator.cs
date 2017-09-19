namespace ALEConsole.PropositionLogic
{
    using System.Collections.Generic;
    using Nodes;
    using Symbols;

    public static class TreeCreator
    {
        public static Node Initialize(string input)
        {
            var symbols = Parser.ParseToSymbols(input);
            Validator.Validate(symbols);
            return TreeCreator.CreateTree(symbols);
        }

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
