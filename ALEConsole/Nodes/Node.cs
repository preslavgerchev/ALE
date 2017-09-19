namespace ALEConsole.Nodes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Symbols;

    public class Node
    {
        public Symbol Symbol { get; set; }

        public Node Parent { private set; get; }

        public List<Node> Children { get; set; }

        public Node(Symbol symbol)
        {
            this.Symbol = symbol;
            this.Children = new List<Node>();
        }

        public void AddChild(Node node)
        {
            this.Children.Add(node);
            node.Parent = this;
        }

        public static Node Initialize(IList<Symbol> input)
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

