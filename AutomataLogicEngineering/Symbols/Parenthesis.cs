﻿namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// A class that represents a single opening or a closing parenthesis.
    /// </summary>
    public class Parenthesis : Symbol
    {
        public ParenthesisSide Side { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parenthesis"/> class.
        /// </summary>
        /// <param name="charSymbol">The char symbol.</param>
        /// <param name="id">The unique identifier of the symbol.</param>
        /// <param name="nodeGraphId">The node graph identifier of the symbol.</param>
        /// <param name="side">The parenthesis side.</param>
        public Parenthesis(char charSymbol, int id, int nodeGraphId, ParenthesisSide side)
            : base(charSymbol, id, nodeGraphId)
        {
            this.Side = side;
        }
    }
}
