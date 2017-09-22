namespace AutomataLogicEngineering.Nodes
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

        public bool Apply()
        {
            if (!(this.Symbol is Connective))
                throw new Exception();

            var symbolConn = this.Symbol as Connective;
            if (this.Children.All(x => x.Symbol is Predicate))
            {
                Predicate firstChild = this.Children[0].Symbol as Predicate;
                Predicate secondChild = null;
                if (symbolConn.Type != ConnectiveType.Not)
                    secondChild = this.Children[1].Symbol as Predicate;

                return this.Apply(firstChild.Value, secondChild?.Value ?? false);
            }
            else if (this.Children.Count(x => x.Symbol is Predicate) == 1
                     && this.Children.Count(x => x.Symbol is Connective) == 1)
            {
                var predicate = this.Children
                    .Where(x => x.Symbol is Predicate)
                    .Select(x => x.Symbol)
                    .Cast<Predicate>()
                    .Single();

                var connective = this.Children.Single(x => x.Symbol is Connective);

                return this.Apply(predicate.Value, connective.Apply());
            }

            return this.Apply(this.Children[0].Apply(),
                symbolConn.Type != ConnectiveType.Not && this.Children[1].Apply());
        }

        private bool Apply(bool value1, bool value2 = false)
        {
            if (!(this.Symbol is Connective))
                throw new Exception();

            var symbolConn = this.Symbol as Connective;
            var returnVal = false;
            switch (symbolConn.Type)
            {
                case ConnectiveType.And:
                    returnVal = value1 && value2;
                    break;
                case ConnectiveType.Or:
                    returnVal = value1 || value2;
                    break;
                case ConnectiveType.Implication:
                    returnVal = !value1 || value2;
                    break;
                case ConnectiveType.Not:
                    returnVal = !value1;
                    break;
                case ConnectiveType.BiImplication:
                    returnVal = value1 == value2;
                    break;
            }

            return returnVal;

        }
    }
}