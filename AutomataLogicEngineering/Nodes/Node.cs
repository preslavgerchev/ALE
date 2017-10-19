namespace AutomataLogicEngineering.Nodes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Symbols;

    /// <summary>
    /// A single node, representing a node in the node tree. The node may contain children 
    /// and may have a parent.
    /// </summary>
    public sealed class Node
    {
        /// <summary>
        /// The infix representation of the implication connective.
        /// </summary>
        private const string InfixImplication = "⇒";

        /// <summary>
        /// The infix representation of the biimplication connective.
        /// </summary>
        private const string InfixBiimplication = "⇔";

        /// <summary>
        /// The infix representation of the dinsjunction connective.
        /// </summary>
        private const string InfixDisjunction = "∨";

        /// <summary>
        /// The infix representation of the conjunction connective.
        /// </summary>
        private const string InfixConjunction = "∧";

        /// <summary>
        /// The infix representation of the nandify connective.
        /// </summary>
        private const string InfixNandify = "⊼";

        /// <summary>
        /// The infix representation of the negation connective.
        /// </summary>
        private const string InfixNegation = "¬";

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
        /// Gets the infix notation for the given node tree, represented by the root node.
        /// </summary>
        /// <returns>The infix notation.</returns>
        public string GetInfixNotation()
        {
            // If the root node is a single predicate, then return it's value
            // directly.
            if (this.Symbol is Predicate p)
            {
                return GetInfixNotationForPredicate(p.ToString());
            }

            if (!(this.Symbol is Connective))
            {
                throw new Exception(
                    $"Internal error. Cannot call GetInfixNotation(..) for symbol '{this.Symbol.CharSymbol}'.");
            }

            var symbolConn = (Connective)this.Symbol;

            // In case all children of the connective are predicates this means we do not have to go
            // further recursively and we can directly get the infix notation, using the children predicates.
            if (this.Children.All(x => x.Symbol is Predicate))
            {
                var firstChild = this.Children[0].Symbol as Predicate;
                Predicate secondChild = null;
                if (symbolConn.Type != ConnectiveType.Not)
                {
                    secondChild = this.Children[1].Symbol as Predicate;
                }

                return this.GetInfixNotation(
                    firstChild.ToString(),
                    secondChild?.ToString() ?? string.Empty);
            }

            // If we have a predicate and a connective as children then we can use the value of the predicate 
            // directly and we can recursively call GetInfixNotation(..) for the connective.
            if (this.Children.Count(x => x.Symbol is Predicate) == 1
                && this.Children.Count(x => x.Symbol is Connective) == 1)
            {
                var predicate = this.Children.Single(x => x.Symbol is Predicate).Symbol as Predicate;
                var connective = this.Children.Single(x => x.Symbol is Connective);
                var connectiveIndex = this.Children.IndexOf(connective);

                return connectiveIndex == 0
                    ? this.GetInfixNotation(connective.GetInfixNotation(), predicate.ToString())
                    : this.GetInfixNotation(predicate.ToString(), connective.GetInfixNotation());
            }

            // Else we have a connective. If it's negation then only use the infix notation from the firt child.
            if (symbolConn.Type == ConnectiveType.Not)
            {
                return this.GetInfixNotation(this.Children[0].GetInfixNotation());
            }
            // Else we have connectives as children. Call GetInfixNotation(..) recursively for all the children.
            return this.GetInfixNotation(
                this.Children[0].GetInfixNotation(),
                this.Children[1].GetInfixNotation());
        }

        /// <summary>
        /// Gets the infix notation for the given node tree, represented by the root node.
        /// </summary>
        /// <returns>The infix notation.</returns>
        public string Nandify()
        {
            // If the root node is a single predicate, then return it's value
            // directly.
            if (this.Symbol is Predicate p)
            {
                return p.ToString();
            }

            if (!(this.Symbol is Connective))
            {
                throw new Exception(
                    $"Internal error. Cannot call Nandify(..) for symbol '{this.Symbol.CharSymbol}'.");
            }

            var symbolConn = (Connective)this.Symbol;

            // In case all children of the connective are predicates this means we do not have to go
            // further recursively and we can directly get the infix notation, using the children predicates.
            if (this.Children.All(x => x.Symbol is Predicate))
            {
                var firstChild = this.Children[0].Symbol as Predicate;
                Predicate secondChild = null;
                if (symbolConn.Type != ConnectiveType.Not)
                {
                    secondChild = this.Children[1].Symbol as Predicate;
                }

                return this.Nandify(
                    firstChild.ToString(),
                    secondChild?.ToString() ?? string.Empty);
            }

            // If we have a predicate and a connective as children then we can use the value of the predicate 
            // directly and we can recursively call GetInfixNotation(..) for the connective.
            if (this.Children.Count(x => x.Symbol is Predicate) == 1
                && this.Children.Count(x => x.Symbol is Connective) == 1)
            {
                var predicate = this.Children.Single(x => x.Symbol is Predicate).Symbol as Predicate;
                var connective = this.Children.Single(x => x.Symbol is Connective);
                var connectiveIndex = this.Children.IndexOf(connective);

                return connectiveIndex == 0
                    ? this.Nandify(connective.Nandify(), predicate.ToString())
                    : this.Nandify(predicate.ToString(), connective.Nandify());
            }

            // Else we have a connective. If it's negation then only use the infix notation from the firt child.
            if (symbolConn.Type == ConnectiveType.Not)
            {
                return this.Nandify(this.Children[0].Nandify());
            }
            // Else we have connectives as children. Call Nandify(..) recursively for all the children.
            return this.Nandify(
                this.Children[0].Nandify(),
                this.Children[1].Nandify());
        }

        /// <summary>
        /// Recursively applies all operations on the node and its children. This method should
        /// always be called on the root node to get correct results.
        /// </summary>
        /// <returns>The end value of the entire proposional input.</returns>
        public bool Apply()
        {
            // If the root node is a single predicate, then return it's value
            // directly.
            if (this.Symbol is Predicate p)
            {
                return p.Value;
            }

            // Else the node is not a single predicate, then we cannot apply on anything but
            // a connective.
            if (!(this.Symbol is Connective))
            {
                throw new Exception($"Internal error. Cannot call Apply(..) for symbol '{this.Symbol.CharSymbol}'.");
            }

            var symbolConn = (Connective)this.Symbol;

            // In case all children of the connective are predicates this means we do not have to go
            // further recursively and we can directly calculate the value of the children.
            if (this.Children.All(x => x.Symbol is Predicate))
            {
                var firstChild = this.Children[0].Symbol as Predicate;
                Predicate secondChild = null;
                if (symbolConn.Type != ConnectiveType.Not)
                {
                    secondChild = this.Children[1].Symbol as Predicate;
                }

                return this.Apply(firstChild.Value, secondChild?.Value ?? false);
            }

            // If we have a predicate and a connective as children then we can use the value of the predicate 
            // directly and we can recursively call Apply(..) for the connective.
            if (this.Children.Count(x => x.Symbol is Predicate) == 1
                && this.Children.Count(x => x.Symbol is Connective) == 1)
            {
                var predicate = this.Children.Single(x => x.Symbol is Predicate).Symbol as Predicate;
                var connective = this.Children.Single(x => x.Symbol is Connective);
                var connectiveIndex = this.Children.IndexOf(connective);

                // If the connective is an implication (>) then it matters which value is passed first. As such we 
                // determine the connective index and if first then we pass the connective first.
                return connectiveIndex == 0
                    ? this.Apply(connective.Apply(), predicate.Value)
                    : this.Apply(predicate.Value, connective.Apply());
            }

            // Else we have two 1 or two connectives as children. Call Apply(..) recursively for all the children.
            return this.Apply(
                this.Children[0].Apply(),
                symbolConn.Type != ConnectiveType.Not && this.Children[1].Apply());
        }

        /// <summary>
        /// Applies the current node's connective on two values and returns the outcome.
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value. Has default value since the 
        /// connective type may be a NOT (~) in which case only one value is needed.</param>
        /// <returns>The result of the connective, applied to the provided values.</returns>
        private bool Apply(bool firstValue, bool secondValue = false)
        {   
            var symbolConn = (Connective)this.Symbol;
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
                case ConnectiveType.Nandify:
                    return !(firstValue && secondValue);
                default:
                    throw new Exception($"Unknown connective type {symbolConn.Type} found.");
            }
        }

        /// <summary>
        /// Gets the infix notation of the given two predicates.
        /// </summary>
        /// <param name="firstPredicate">The first predicate.</param>
        /// <param name="secondPredicate">The second predicate. Has default value since the 
        /// connective type may be a NOT (~) in which case only one value is needed.</param>
        /// <returns>The result of applying infix notation to the provided values.</returns>
        private string GetInfixNotation(string firstPredicate, string secondPredicate = "")
        {
            firstPredicate = GetInfixNotationForPredicate(firstPredicate);
            secondPredicate = GetInfixNotationForPredicate(secondPredicate);
            
            var symbolConn = (Connective)this.Symbol;
            switch (symbolConn.Type)
            {
                case ConnectiveType.And:
                    return $"({firstPredicate} {InfixConjunction} {secondPredicate})";
                case ConnectiveType.Or:
                    return $"({firstPredicate} {InfixDisjunction} {secondPredicate})";
                case ConnectiveType.Implication:
                    return $"({firstPredicate} {InfixImplication} {secondPredicate})";
                case ConnectiveType.Not:
                    return $"{InfixNegation}({firstPredicate})";
                case ConnectiveType.BiImplication:
                    return $"({firstPredicate} {InfixBiimplication} {secondPredicate})";
                case ConnectiveType.Nandify:
                    return $"({firstPredicate} {InfixNandify} {secondPredicate})";
                default:
                    throw new Exception($"Unknown connective type {symbolConn.Type} found.");
            }
        }

        /// <summary>
        /// Gets the infix notation of the given two predicates.
        /// </summary>
        /// <param name="firstPredicate">The first predicate.</param>
        /// <param name="secondPredicate">The second predicate. Has default value since the 
        /// connective type may be a NOT (~) in which case only one value is needed.</param>
        /// <returns>The result of applying infix notation to the provided values.</returns>
        private string Nandify(string firstPredicate, string secondPredicate = "")
        {
            var symbolConn = (Connective)this.Symbol;
            switch (symbolConn.Type)
            {
                case ConnectiveType.And:
                    return $"%(%({firstPredicate},{secondPredicate}),%({firstPredicate},{secondPredicate}))";
                case ConnectiveType.Or:
                    return $"%(%({firstPredicate},{firstPredicate}),%({secondPredicate},{secondPredicate}))";
                case ConnectiveType.Implication:
                    return $"% ({firstPredicate},% ({secondPredicate}, {secondPredicate}))";
                case ConnectiveType.Not:
                    return $"%({firstPredicate},{firstPredicate})";
                case ConnectiveType.BiImplication:
                    return $"%(%(%({firstPredicate},{firstPredicate}),%({secondPredicate},{secondPredicate}))" +
                           $",%({firstPredicate},{secondPredicate}))";
                case ConnectiveType.Nandify:
                    return $"%({firstPredicate},{secondPredicate})";
                default:
                    throw new Exception($"Unknown connective type {symbolConn.Type} found.");
            }
        }

        /// <summary>
        /// Converts the given predicate into the its infix notation. If the predicate
        /// has a value of either '1' then "True" will be returned. Else if the predicate
        /// has a value of '0' then "False" will be returned. Else the predicate itself
        /// will be returned.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The infix notation for the predicate.</returns>
        private string GetInfixNotationForPredicate(string predicate) =>
            predicate == "1" ? "True" : predicate == "0" ? "False" : predicate;
    }
}