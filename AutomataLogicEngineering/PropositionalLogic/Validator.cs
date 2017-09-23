namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Symbols;

    /// <summary>
    /// A static class, responsible for validating the list of symbols provided.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates whether the provided <paramref name="symbols"/> of <see cref="Symbol"/> instances
        /// is valid.
        /// </summary>
        /// <param name="symbols">The list of symbols to validate.</param>
        public static void Validate(IList<Symbol> symbols)
        {
            var allParenthesis = symbols
                .Where(x => x is Parenthesis)
                .Cast<Parenthesis>()
                .ToList();

            if (!symbols.Any())
            {
                throw new InvalidInputException("Input cannot be empty.");
            }

            if (allParenthesis.Count(x => x.Side == ParenthesisSide.Closing)
                != allParenthesis.Count(x => x.Side == ParenthesisSide.Opening))
            {
                throw new InvalidInputException("Amount of opening and closing parenthesis must match.");
            }

            var isConnectiveNegation = false;
            var predicatesInside = 0;
            Symbol previous = null;
            for (var i = 0; i < symbols.Count; i++)
            {
                if (i == 0)
                {
                    previous = symbols[i];
                    if (symbols.Count == 1 && !(previous is Predicate))
                    {
                        throw new InvalidInputException("The input is a single char and mus be a predicate.");
                    }
                    if (symbols.Count > 1 && !(previous is Connective))
                    {
                        throw new InvalidInputException("The input must always start with a connective.");
                    }
                    isConnectiveNegation = previous is Connective c && c.Type == ConnectiveType.Not;
                }
                else
                {
                    if (i != 1)
                    {
                        previous = symbols[i - 1];
                    }
                    var current = symbols[i];
                    if (current is Predicate)
                    {
                        if (!((previous is Parenthesis p && p.Side == ParenthesisSide.Opening)
                              || previous is Separator))
                        {
                            throw new InvalidInputException(
                                "A predicate must always be preceded by either an opening parenthesis or a comma.");
                        }
                        predicatesInside++;
                    }
                    if (current is Connective conn)
                    {
                        isConnectiveNegation = conn.Type == ConnectiveType.Not;
                        if (!((previous is Parenthesis p && p.Side == ParenthesisSide.Opening)
                              || previous is Separator))
                        {
                            throw new InvalidInputException(
                                "A connective must always be preceded by either an opening parenthesis or a comma.");
                        }
                    }
                    if (current is Parenthesis paren)
                    {
                        if (paren.Side == ParenthesisSide.Opening)
                        {
                            if (!(previous is Connective))
                            {
                                throw new InvalidInputException(
                                    "An opening parenthesis must always be preceded by a connective.");
                            }
                            predicatesInside = 0;
                        }
                        else
                        {
                            if (previous is Parenthesis pare && pare.Side == ParenthesisSide.Closing)
                            {
                                continue;
                            }
                            if (isConnectiveNegation && predicatesInside > 1)
                            {
                                throw new InvalidInputException("A negation must be applied for only one predicate.");
                            }
                            if (!isConnectiveNegation && predicatesInside < 2)
                            {
                                throw new InvalidInputException(
                                    "A connective that is not a negation must be applied for exactly two predicates.");
                            }
                            if (predicatesInside > 2)
                            {
                                throw new InvalidInputException("No connective can have more than two predicates.");
                            }
                            if (!((previous is Parenthesis p && p.Side == ParenthesisSide.Closing)
                                  || previous is Predicate))
                            {
                                throw new InvalidInputException(
                                    "A closing parenthesis must always be preceded by either another closing parenthesis or a predicate.");
                            }
                            isConnectiveNegation = false;
                        }
                    }
                    if (current is Separator)
                    {
                        if (!((previous is Parenthesis p && p.Side == ParenthesisSide.Closing)
                              || previous is Predicate))
                        {
                            throw new InvalidInputException(
                                "A comma must always be preceded by either another closing parenthesis or a predicate.");
                        }
                    }
                }
            }
        }
    }
}
