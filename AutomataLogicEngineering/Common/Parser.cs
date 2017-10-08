namespace AutomataLogicEngineering.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
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
        private static readonly IDictionary<char, int> IdDictionary = new Dictionary<char, int>();

        /// <summary>
        /// Parses the given string input to a list of <see cref="Symbol"/> instances.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>A list of <see cref="Symbol"/> instances.</returns>
        public static List<Symbol> ParseToSymbols(string input)
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
                    return new Parenthesis(inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ParenthesisSide.Opening);
                case ')':
                    return new Parenthesis(inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ParenthesisSide.Closing);
                case '~':
                    return new Connective(inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ConnectiveType.Not);
                case '&':
                    return new Connective(inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ConnectiveType.And);
                case '|':
                    return new Connective(inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ConnectiveType.Or);
                case '>':
                    return new Connective(
                        inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ConnectiveType.Implication);
                case '=':
                    return new Connective(
                        inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId(), ConnectiveType.BiImplication);
                case ',':
                    return new Separator(inputChar, IdGenerator.GetNextSymbolId(), IdGenerator.GetNextNodeGraphId());
                default:
                    if (Regex.IsMatch(inputChar.ToString(), "[a-zA-Z]"))
                    {
                        if (!IdDictionary.TryGetValue(inputChar, out var id))
                        {
                            id = IdGenerator.GetNextSymbolId();
                            IdDictionary.Add(inputChar, id);
                        }
                        return new Predicate(inputChar, id, IdGenerator.GetNextNodeGraphId());
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }
            }
        }
    }
}
