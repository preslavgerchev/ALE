namespace AutomataLogicEngineering.Symbols
{
    using System;

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
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Symbol"/> class.
        /// </summary>
        /// <param name="charSymbol">The char symbol.</param>
        /// <param name="id">The identifier of the symbol.</param>
        protected Symbol(char charSymbol, Guid id)
        {
            this.CharSymbol = charSymbol;
            this.Id = id;
        }

        /// <summary>
        /// Returns a textual representation of the symbol.
        /// </summary>
        /// <returns>The char symbol.</returns>
        public override string ToString() => this.CharSymbol.ToString();
    }
}
