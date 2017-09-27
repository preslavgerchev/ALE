﻿namespace AutomataLogicEngineering.PropositionalLogic
{
    using System;
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
        /// A dictionary that stores the used identifiers for all predicates. If a duplicate predicate
        /// is found in the input then the same identifier can be reused and assiggned to the predicate.
        /// </summary>
        private static readonly IDictionary<char, Guid> IdDictionary = new Dictionary<char, Guid>();

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
        /// Parses a given char to its corresponding symbol.
        /// </summary>
        /// <param name="inputChar">The char to parse.</param>
        /// <returns>A symbol that corresponds to the given char.</returns>
        private static Symbol ToSymbol(char inputChar)
        {
            switch (inputChar)
            {
                case '(':
                    return new Parenthesis(inputChar, Guid.NewGuid(), ParenthesisSide.Opening);
                case ')':
                    return new Parenthesis(inputChar, Guid.NewGuid(), ParenthesisSide.Closing);
                case '~':
                    return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.Not);
                case '&':
                    return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.And);
                case '|':
                    return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.Or);
                case '>':
                    return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.Implication);
                case '=':
                    return new Connective(inputChar, Guid.NewGuid(), ConnectiveType.BiImplication);
                case ',':
                    return new Separator(inputChar, Guid.NewGuid());
                default:
                    if (Regex.IsMatch(inputChar.ToString(), "[a-zA-Z]"))
                    {
                        if (!IdDictionary.TryGetValue(inputChar, out var guid))
                        {
                            guid = Guid.NewGuid();
                            IdDictionary.Add(inputChar, guid);
                        }
                        return new Predicate(inputChar, guid);
                    }
                    else
                    {
                        throw new InvalidInputException($"Invalid input found: {inputChar}");
                    }
            }
        }
    }
}
