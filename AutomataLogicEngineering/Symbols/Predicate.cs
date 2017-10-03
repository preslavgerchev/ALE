namespace AutomataLogicEngineering.Symbols
{
    /// <summary>
    /// A class, that represents a predicate, usually represented by a single letter.
    /// </summary>
    public class Predicate : Symbol
    {
        /// <summary>
        /// The value of the predicate.
        /// </summary>
        public bool Value { get; set; }

        /// <summary>
        /// The representation of the predicate's value. 1 if the value is true,
        /// 0 if the value is false.
        /// </summary>
        public int ValueRepresentation => this.Value ? 1 : 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Predicate"/> class.
        /// </summary>
        /// <param name="charSymbol">The char symbol.</param>
        /// <param name="id">The unique identifier of the symbol.</param>
        /// <param name="nodeGraphId">The node graph identifier of the symbol.</param>
        /// <param name="value">The value of the predicate.</param>
        public Predicate(char charSymbol, int id, int nodeGraphId, bool value = false)
            : base(charSymbol, id, nodeGraphId)
        {
            this.Value = value;
        }
    }
}
