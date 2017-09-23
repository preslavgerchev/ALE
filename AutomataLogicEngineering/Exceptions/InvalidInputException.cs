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
        /// <param name="message">The exception message.</param>
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}
