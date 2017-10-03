namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// A class that represents a single symbol on a node.
    /// </summary>
    public abstract class Symbol
    {
        /// <summary>
        /// Gets the char symbol.
        /// </summary>
        public char CharSymbol { get; }

        /// <summary>
        /// Gets the unique identifier of the symbol.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the uniqie identifier to be used when drawing the node graph for this node.
        /// </summary>
        /// <remarks>
        /// Drawing the graph requires uniqie identifiers for all symbols. Since <see cref="Id"/>
        /// is equal for duplicate symbol, this identifier is needed.
        /// </remarks>
        public int NodeGraphId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Symbol"/> class.
        /// </summary>
        /// <param name="charSymbol">The char symbol.</param>
        /// <param name="id">The identifier of the symbol.</param>
        /// <param name="nodeGraphId">The node graph identifier of the symbol.</param>
        protected Symbol(char charSymbol, int id, int nodeGraphId)
        {
            this.CharSymbol = charSymbol;
            this.Id = id;
            this.NodeGraphId = nodeGraphId;
        }

        /// <summary>
        /// Returns a textual representation of the symbol.
        /// </summary>
        /// <returns>The char symbol.</returns>
        public override string ToString() => this.CharSymbol.ToString();
    }
}
