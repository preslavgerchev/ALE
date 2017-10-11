namespace AutomataLogicEngineering.Symbols
{
    using System;

    /// <summary>
    /// A class, that represents a predicate, usually represented by a single letter.
    /// </summary>
    public class Predicate : Symbol
    {
        /// <summary>
        /// Gets or sets the value of the predicate.
        /// </summary>
        private bool value;

        /// <summary>
        /// Gets a value, indicating whether the predicate is a single digit.s
        /// </summary>
        public bool IsDigit { get; }

        /// <summary>
        /// Gets or sets the value of the predicate.
        /// </summary>
        public bool Value
        {
            get => this.value;
            set
            {
                if (this.IsDigit)
                {
                    throw new InvalidOperationException(
                        "Cannot set value for Predicate.Value since the char is a digit.");
                }
                this.value = value;
            }
        }

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
        public Predicate(char charSymbol, int id, int nodeGraphId)
            : base(charSymbol, id, nodeGraphId)
        {
            this.IsDigit = char.IsDigit(charSymbol);
            // Only if the char is a digit then directly assign it's value
            // since it's either 0 or 1.
            if (this.IsDigit)
            {
                this.value = this.CharSymbol == '1';
            }
        }
    }
}
