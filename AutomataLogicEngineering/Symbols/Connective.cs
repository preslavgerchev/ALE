﻿namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// A class, that represents a single connective.
    /// </summary>
    public class Connective : Symbol
    {
        /// <summary>
        /// Gets the connective type.
        /// </summary>
        public ConnectiveType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Connective"/> class.
        /// </summary>
        /// <param name="charSymbol">The char symbol.</param>
        /// <param name="id">The unique identifier of the symbol.</param>
        /// <param name="nodeGraphId">The node graph identifier of the symbol.</param>
        /// <param name="type">The connective type.</param>
        public Connective(char charSymbol, int id, int nodeGraphId, ConnectiveType type)
            : base(charSymbol, id, nodeGraphId)
        {
            this.Type = type;
        }
    }
}