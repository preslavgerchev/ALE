namespace AutomataLogicEngineering.Common
{
    using Symbols;
    
    /// <summary>
    /// A static class, responsible for generating Ids for the <see cref="Symbol"/> instances.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Gets the next unique identifier that can be assigned to a symbol.
        /// </summary>
        private static int symbolId = 0;

        /// <summary>
        /// Gets the next unique identifier that can be assigned to a symbol, to be used in 
        /// drawing the node graph.
        /// </summary>
        private static int nodeGraphId = 0;

        /// <summary>
        /// Gets the next unique identifier that can be used to identify a symbol.
        /// </summary>
        /// <returns>An unique symbol identifier.</returns>
        public static int GetNextSymbolId() => symbolId++;

        /// <summary>
        /// Gets the next unique identifier that can be assigned to a symbol, to be used in 
        /// drawing the node graph.
        /// </summary>
        /// <returns>An unique node graph identifier.</returns>
        public static int GetNextNodeGraphId() => nodeGraphId++;
    }
}
