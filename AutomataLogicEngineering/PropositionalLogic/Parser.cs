using System;

namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;
    using Exceptions;
    using Symbols;

    /// <summary>
    /// A static class, responsible for parsing a given string input in a list of symbols.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Parses the given string input to a list of <see cref="Symbol"/> instances.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>A list of <see cref="Symbol"/> instances.</returns>
        public static IList<Symbol> ParseToSymbols(string input)
        {
            var allChars = new Regex("\\s+").Replace(input, "").ToCharArray();
            return allChars.Select(ToSymbol).ToList();
        }

        /// <summary>
        /// Parses a given char to its corresponding symbol.
        /// </summary>
        /// <param name="inputChar">The char to parse.</param>
        /// <returns>A symbol that corresponds to the given char.</returns>
        private static Symbol ToSymbol(char inputChar)
        {
            if (inputChar == '(')
            {
                return new Parenthesis(inputChar, Guid.NewGuid(), ParenthesisSide.Opening);
            }
            else if (inputChar == ')')
            {
                return new Parenthesis(inputChar, Guid.NewGuid(), ParenthesisSide.Closing);
            }
            else if (inputChar == '~')
            {
                return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.Not);
            }
            else if (inputChar == '&')
            {
                return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.And);
            }
            else if (inputChar == '|')
            {
                return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.Or);
            }
            else if (inputChar == '>')
            {
                return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.Implication);
            }
            else if (inputChar == '=')
            {
                return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.BiImplication);
            }
            else if (inputChar == ',')
            {
                return new Separator(inputChar, Guid.NewGuid());
            }
            // TODO PREGER extend with also numbers?
            else if (Regex.IsMatch(inputChar.ToString(), "[a-zA-Z]"))
            {
                return new Predicate(inputChar, Guid.NewGuid());
            }
            else
            {
                throw new InvalidInputException($"Invalid input found: {inputChar}");
            }
        }
    }
}
