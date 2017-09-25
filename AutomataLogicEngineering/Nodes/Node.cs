﻿namespace AutomataLogicEngineering.Nodes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Symbols;

    /// <summary>
    /// A single node, representing a node in the node tree. The node may contain children 
    /// and may have a parent.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets the symbol of the node.
        /// </summary>
        public Symbol Symbol { get; }

        /// <summary>
        /// Gets the parent of the node.
        /// </summary>
        public Node Parent { private set; get; }

        /// <summary>
        /// Gets the children of the node.
        /// </summary>
        public List<Node> Children { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="symbol">The symbol to initialize with.</param>
        public Node(Symbol symbol)
        {
            this.Symbol = symbol;
            this.Children = new List<Node>();
        }

        /// <summary>
        /// Adds a child node to the children list.
        /// </summary>
        /// <param name="node">The child node to add.</param>
        public void AddChild(Node node)
        {
            this.Children.Add(node);
            node.Parent = this;
        }

        /// <summary>
        /// Recursively applies all operations on the node and its children. This method should
        /// always be called on the root node to get correct results.
        /// </summary>
        /// <returns>The end value of the entire proposional input.</returns>
        public bool Apply()
        {
            // We cannot apply anything on a node that's not connective.
            if (!(this.Symbol is Connective))
            {
                throw new Exception("Internal error. Cannot call Apply(..) for a predicate.");
            }

            var symbolConn = this.Symbol as Connective;

            // In case all children of the connective are predicates this means we do not have to go
            // further recursively and we can directly calculate the value of the children.
            if (this.Children.All(x => x.Symbol is Predicate))
            {
                Predicate firstChild = this.Children[0].Symbol as Predicate;
                Predicate secondChild = null;
                if (symbolConn.Type != ConnectiveType.Not)
                {
                    secondChild = this.Children[1].Symbol as Predicate;
                }

                return this.Apply(firstChild.Value, secondChild?.Value ?? false);
            }

            // If we have a predicate and a connective as children then we can use the value of the predicate directly
            // and we can recursively call Apply(..) for the connective.
            if (this.Children.Count(x => x.Symbol is Predicate) == 1
                && this.Children.Count(x => x.Symbol is Connective) == 1)
            {
                var predicate = this.Children.Single(x => x.Symbol is Predicate).Symbol as Predicate;
                var connective = this.Children.Single(x => x.Symbol is Connective);

                return this.Apply(predicate.Value, connective.Apply());
            }

            // Else we have two 1 or two connectives as children. Call Apply(..) recursively for all the children.
            return this.Apply(
                this.Children[0].Apply(), symbolConn.Type != ConnectiveType.Not && this.Children[1].Apply());
        }

        /// <summary>
        /// Applies the current node's connective on two values and returns the outcome.
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value. Has default value since the 
        /// connective type may be a NOT in which case only one value is needed.</param>
        /// <returns>The result of the connective, applied to the provided values.</returns>
        private bool Apply(bool firstValue, bool secondValue = false)
        {
            // We cannot apply anything on a node that's not connective.
            if (!(this.Symbol is Connective))
            {
                throw new Exception("Internal error. Cannot call Apply(..) for a predicate.");
            }

            var symbolConn = (Connective) this.Symbol;
            switch (symbolConn.Type)
            {
                case ConnectiveType.And:
                    return firstValue && secondValue;
                case ConnectiveType.Or:
                    return firstValue || secondValue;
                case ConnectiveType.Implication:
                    return !firstValue || secondValue;
                case ConnectiveType.Not:
                    return !firstValue;
                case ConnectiveType.BiImplication:
                    return firstValue == secondValue;
                default:
                    throw new Exception($"Unknown connective type {symbolConn.Type} found.");
            }
        }
    }
}