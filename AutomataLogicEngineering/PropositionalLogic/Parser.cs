namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;
    using Exceptions;
    using Symbols;

    public static class Parser
    {
        public static IList<Symbol> ParseToSymbols(string input)
        {
            var allChars = input.RemoveWhiteSpaces().ToCharArray();
            return allChars.Select(ToSymbol).ToList();
        }
        private static string RemoveWhiteSpaces(this string input) => new Regex("\\s+").Replace(input, "");

        private static Symbol ToSymbol(char inputChar)
        {
            if (inputChar == '(')
            {
                return new Parenthesis(inputChar, ParenthesisSide.Opening);
            }
            else if (inputChar == ')')
            {
                return new Parenthesis(inputChar, ParenthesisSide.Closing);
            }
            else if (inputChar == '~')
            {
                return new Connective(inputChar, ConnectiveType.Not);
            }
            else if (inputChar == '&')
            {
                return new Connective(inputChar, ConnectiveType.And);
            }
            else if (inputChar == '|')
            {
                return new Connective(inputChar, ConnectiveType.Or);
            }
            else if (inputChar == '>')
            {
                return new Connective(inputChar, ConnectiveType.Implication);
            }
            else if (inputChar == '=')
            {
                return new Connective(inputChar, ConnectiveType.BiImplication);
            }
            else if (inputChar == ',')
            {
                return new Separator(inputChar);
            }
            else if (Regex.IsMatch(inputChar.ToString(), "[a-zA-Z01]"))
            {
                return new Predicate(inputChar);
            }
            else
            {
                throw new InvalidInputException($"Invalid input found: {inputChar}");
            }
        }
    }
}
