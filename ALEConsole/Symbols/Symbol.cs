namespace ALEConsole.Nodes
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charSymbol"></param>
        public Symbol(char charSymbol)
        {
            this.CharSymbol = charSymbol;
        }

        /// <summary>
        /// Returns a textual representation of the symbol.
        /// </summary>
        /// <returns>The char symbol.</returns>
        public override string ToString() => this.CharSymbol.ToString();
    }
}
