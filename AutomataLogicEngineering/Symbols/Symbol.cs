using System;

namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// TODO 
    /// </summary>
    public abstract class Symbol
    {

        /// <summary>
        /// TODO
        /// </summary>
        public char CharSymbol { get; }

        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charSymbol"></param>
        protected Symbol(char charSymbol)
        {
            this.CharSymbol = charSymbol;
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Returns a textual representation of the symbol.
        /// </summary>
        /// <returns>The char symbol.</returns>
        public override string ToString() => this.CharSymbol.ToString();
    }
}
