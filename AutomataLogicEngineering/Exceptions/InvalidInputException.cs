﻿namespace AutomataLogicEngineering.Exceptions
{
    using System;

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }

        public InvalidInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
