namespace ALEConsole
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Symbols;

    public static class Parser
    {
        public static string RemoveWhiteSpaces(this string input)
        {
            string pattern = "\\s+";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(input, replacement);
        }

        public static IList<Symbol> ParseToSymbols(this string input)
        {
            var allChars = input.ToCharArray();
            return allChars.Select(c => ToSymbol(c)).ToList();
        }

        private static Symbol ToSymbol(char inputChar)
        {
            switch (inputChar)
            {
                case '(':
                    return new Parenthesis(inputChar, ParenthesisSide.Opening);
                case ')':
                    return new Parenthesis(inputChar, ParenthesisSide.Closing);
                case '~':
                    return new Connective(inputChar, ConnectiveType.Not);
                case '&':
                    return new Connective(inputChar, ConnectiveType.And);
                case '|':
                    return new Connective(inputChar, ConnectiveType.Or);
                case '>':
                    return new Connective(inputChar, ConnectiveType.Implication);
                case '=':
                    return new Connective(inputChar, ConnectiveType.BiImplication);
                case ',':
                    return new Separator(inputChar);
                default:
                    return new Predicate(inputChar);
            }
        }
    }
}
