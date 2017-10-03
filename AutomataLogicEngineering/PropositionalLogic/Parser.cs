﻿namespace AutomataLogicEngineering.PropositionalLogic
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
        /// Gets the next unique identifier that can be assigned to a symbol.
        /// </summary>
        private static int symbolId = 0;

        /// <summary>
        /// A dictionary that stores the used identifiers for all predicates. If a duplicate predicate
        /// is found in the input then the same identifier can be reused and assiggned to the predicate.
        /// </summary>
        private static readonly IDictionary<char, int> IdDictionary = new Dictionary<char, int>();

        /// <summary>
        /// Parses the given string input to a list of <see cref="Symbol"/> instances.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>A list of <see cref="Symbol"/> instances.</returns>
        public static IList<Symbol> ParseToSymbols(string input)
        {
            var allChars = new Regex("\\s+").Replace(input, string.Empty).ToCharArray();
            return allChars.Select(ToSymbol).ToList();
        }

        /// <summary>
        /// Gets the next unique identifier that can be used to identify a symbol.
        /// </summary>
        /// <returns>An unique identifier.</returns>
        private static int GetNextSymbolId() => symbolId++;

        /// <summary>
        /// Parses a given char to its corresponding symbol.
        /// </summary>
        /// <param name="inputChar">The char to parse.</param>
        /// <returns>A symbol that corresponds to the given char.</returns>
        private static Symbol ToSymbol(char inputChar)
        {
            switch (inputChar)
            {
                case '(':
                    return new Parenthesis(inputChar, GetNextSymbolId(), ParenthesisSide.Opening);
                case ')':
                    return new Parenthesis(inputChar, GetNextSymbolId(), ParenthesisSide.Closing);
                case '~':
                    return new Connective(inputChar, GetNextSymbolId(), ConnectiveType.Not);
                case '&':
                    return new Connective(inputChar, GetNextSymbolId(), ConnectiveType.And);
                case '|':
                    return new Connective(inputChar, GetNextSymbolId(), ConnectiveType.Or);
                case '>':
                    return new Connective(inputChar, GetNextSymbolId(), ConnectiveType.Implication);
                case '=':
                    return new Connective(inputChar, GetNextSymbolId(), ConnectiveType.BiImplication);
                case ',':
                    return new Separator(inputChar, GetNextSymbolId());
                default:
                    // TODO PREGER for drawing node unique ids is needed. one Id and one Guid?
                    if (Regex.IsMatch(inputChar.ToString(), "[a-zA-Z]"))
                    {
                        if (!IdDictionary.TryGetValue(inputChar, out var id))
                        {
                            id = GetNextSymbolId();
                            IdDictionary.Add(inputChar, id);
                        }
                        return new Predicate(inputChar, id);
                    }
                    else
                    {
                        throw new InvalidInputException($"Invalid input found: '{inputChar}'.");
                    }
            }
        }
    }
}
