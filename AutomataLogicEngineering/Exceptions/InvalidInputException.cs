namespace AutomataLogicEngineering.Exceptions
{
    using System;

    /// <summary>
    /// An exception, indicating that the propositional logic input is invalid.
    /// </summary>
    public class InvalidInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCastException"/> class.
        /// </summary>
        public InvalidInputException()
            : base("Invalid input")
        {
        }
    }
}
