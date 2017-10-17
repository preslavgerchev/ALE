namespace AutomataLogicEngineering.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Symbols;
    using static Common.IdGenerator;

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
        public static void ValidateInput(List<Symbol> symbols)
        {
            var allParenthesis = symbols
                .Where(x => x is Parenthesis)
                .Cast<Parenthesis>()
                .ToList();

            if (!symbols.Any())
            {
                throw new InvalidInputException();
            }

            if (symbols.Count == 1 && (symbols.First() is Connective))
            {
                throw new InvalidInputException();
            }

            if (symbols.Count == 1 && (symbols.First() is Predicate))
            {
                return;
            }

            if (allParenthesis.Count(x => x.Side == ParenthesisSide.Closing)
                != allParenthesis.Count(x => x.Side == ParenthesisSide.Opening) || allParenthesis.Count == 0)
            {
                throw new InvalidInputException();
            }
            try
            {
                var validatedList = Validate(symbols);
                while (validatedList.Count > 1)
                {
                    validatedList = Validate(validatedList);
                }
            }
            // If invalid input is provided it may lead to different exceptions, such as index out of range for example.
            // If so simply rethrow an InvalidInputException instance.
            catch (Exception ex) when (!(ex is InvalidInputException))
            {
                throw new InvalidInputException();
            }
        }

        /// <summary>
        /// Validates the given list of symbols by finding the first valid pair of connective and
        /// predicates in format C(P,P) or C(P), validating it and replacing it with a single predicate.
        /// </summary>
        /// <param name="symbols">The symbols to validate.</param>
        /// <returns>A new collection of symbols.</returns>
        private static List<Symbol> Validate(List<Symbol> symbols)
        {
            var newList = symbols;

            if (symbols.Count(x => x is Parenthesis) == 0)
            {
                throw new InvalidInputException();
            }

            var parenthesisStack = new Stack<int>();
            for (var i = 0; i < newList.Count(); i++)
            {
                var symbol = newList.ElementAt(i);
                if (symbol is Parenthesis paren)
                {
                    if (paren.Side == ParenthesisSide.Opening)
                    {
                        // -1 since we need to account for the connective in front of the parenthesis.
                        parenthesisStack.Push(i - 1);
                    }
                    else
                    {
                        // If there is no opening parenthesis, then it means that a closing
                        // one has been placed before it.
                        if (!parenthesisStack.Any())
                            throw new InvalidInputException();

                        var opening = parenthesisStack.Pop();
                        var closing = i + 1;
                        var symbolsToValidate = symbols.Skip(opening).Take(closing - opening).ToList();
                        ValidateSinglePair(symbolsToValidate);
                        // Remove the validated pair and replace it with a single predicate. Also break out of
                        // the for loop.
                        newList.RemoveRange(opening, closing - opening);
                        newList.Insert(opening, new Predicate('A', GetNextSymbolId(), GetNextNodeGraphId()));
                        break;
                    }
                }
            }

            return newList;
        }

        /// <summary>
        /// Validates a single pair of a connective and predicates. The pair should always be in
        /// C(P,P) format or C(P) incase the connective is negation.
        /// </summary>
        /// <param name="symbols">The symbols to validate.</param>
        private static void ValidateSinglePair(IList<Symbol> symbols)
        {
            var isNegation = false;
            // We either expect C(P) or C(P,P).
            if (symbols.Count != 4 && symbols.Count != 6)
            {
                throw new InvalidInputException();
            }
            for (var i = 0; i < symbols.Count; i++)
            {
                var symbol = symbols[i];
                switch (i)
                {
                    case 0:
                        if (!(symbol is Connective))
                            throw new InvalidInputException();

                        isNegation = (symbol as Connective).Type == ConnectiveType.Not;
                        break;
                    case 1:
                        {
                            if (!(symbol is Parenthesis p) || p.Side != ParenthesisSide.Opening)
                                throw new InvalidInputException();
                            break;
                        }
                    case 2:
                        if (!(symbol is Predicate))
                            throw new InvalidInputException();
                        break;
                    case 3:
                        {
                            if (isNegation && (!(symbol is Parenthesis p) || p.Side != ParenthesisSide.Closing))
                                throw new InvalidInputException();

                            else if (!isNegation && !(symbol is Separator))
                                throw new InvalidInputException();
                            break;
                        }
                    case 4 when !isNegation:
                        if (!(symbol is Predicate))
                            throw new InvalidInputException();
                        break;
                    case 5 when !isNegation:
                        {
                            if (!(symbol is Parenthesis p) || p.Side != ParenthesisSide.Closing)
                                throw new InvalidInputException();
                            break;
                        }
                    default:
                        throw new InvalidInputException();
                }
            }
        }
    }
}
