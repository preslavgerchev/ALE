﻿namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// A class, that represents a separator (a comma).
    /// </summary>
    public class Separator : Symbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Separator"/> class.
        /// </summary>
        /// <param name="charSymbol">The char symbol.</param>
        /// <param name="id">The unique identifier of the symbol.</param>
        /// <param name="nodeGraphId">The node graph identifier of the symbol.</param>
        public Separator(char charSymbol, int id, int nodeGraphId)
            : base(charSymbol, id, nodeGraphId)
        {
        }
    }
}
    