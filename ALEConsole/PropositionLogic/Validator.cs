namespace ALEConsole.PropositionLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Symbols;

    public static class Validator
    {

        public static void Validate(IList<Symbol> symbols)
        {
            var allParenthesis = symbols
                .Where(x => x is Parenthesis)
                .Cast<Parenthesis>()
                .ToList();

            if (allParenthesis.Count(x => x.Side == ParenthesisSide.Closing)
                != allParenthesis.Count(x => x.Side == ParenthesisSide.Opening))
            {
                throw new Exception("Amount of opening and closing parenthesis must match.");
            }

            for (var i = 0; i < symbols.Count; i++)
            {
                if (i == 0)
                {
                    var symbol = symbols[i];
                    if (symbols.Count == 1 && !(symbol is Predicate))
                    {
                        throw new Exception("The input is a single char and mus be a predicate");
                    }
                    if (symbols.Count > 1 && !(symbol is Connective))
                    {
                        throw new Exception("The input must always start with a connective");
                    }
                }
                else
                {
                    var previous = symbols[i - 1];
                    var current = symbols[i];
                    if (previous is Connective)
                    {
                        if (!(current is Parenthesis))
                            throw new Exception("A connective must always be followed by a parenthesis.");
                    }
                    if (previous is Predicate)
                    {
                        if (!((current is Parenthesis) || current is Separator))
                        {
                            throw new Exception(
                                "A predicate must always be followed either by a comma or a parenthesis of the previous connective is a negation.");
                        }
                    }
                    if (previous is Parenthesis parenthesis)
                    {
                        if (parenthesis.Side == ParenthesisSide.Opening)
                        {
                            if (!(current is Predicate || current is Connective))
                            {
                                throw new Exception(
                                    "An opening parenthesis must always be followed by either a predicate or a connective.");
                            }
                        }
                        else
                        {
                            if (!(current is Separator ||
                                  (current is Parenthesis p && p.Side == ParenthesisSide.Closing)))
                            {
                                throw new Exception(
                                    "A closing parenthesis must always be followed by either a comma or another closing parenthesis.");
                            }
                        }
                    }
                    if (previous is Separator)
                    {
                        if (!(current is Predicate || current is Connective))
                        {
                            throw new Exception("A comma must always be followed by either a predicate or a connective.");
                        }
                    }
                }
            }
        }
    }
}
