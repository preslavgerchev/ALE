namespace ALEConsole.Nodes
{
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
    }
}