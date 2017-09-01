namespace ALEConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Symbols;

    class Program
    {
        static void Main(string[] args)
        {
            var properOutput = "&(>(A,B),~(0))";
            var nodes = properOutput.ParseToSymbols();
            Console.WriteLine();

            var bla = GetParenthesisGroups(nodes);
            foreach (var grp in bla)
            {
                Console.WriteLine(string.Join(string.Empty, grp.Select(n => n.ToString())));
                Console.WriteLine(Environment.NewLine);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// TODO refactor this entire thing once algorithm works.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static IList<IList<Symbol>> GetParenthesisGroups(IList<Symbol> input)
        {
            var openingParenthesis = input
                .Where(x => x is Parenthesis)
                .Cast<Parenthesis>()
                .Count(y => y.Side == ParenthesisSide.Opening);

            var closingParenthesis = input
                .Where(x => x is Parenthesis)
                .Cast<Parenthesis>()
                .Count(y => y.Side == ParenthesisSide.Closing);


            if (openingParenthesis != closingParenthesis)
                // TODO custom exception, better message.
                throw new ArgumentException("invalid expression.");

            // TODO better algorithm for this. stack seems to work fine tho.
            var parenthesisStack = new Stack<Parenthesis>();
            var tupleList = new List<Tuple<Parenthesis, Parenthesis>>();
            foreach (var symbol in input)
            {
                if (symbol is Parenthesis)
                {
                    // TODO use c# 7.0  is sugar syntax.
                    var parenthesis = symbol as Parenthesis;
                    if (parenthesis.Side == ParenthesisSide.Opening)
                    {
                        parenthesisStack.Push(parenthesis);
                    }
                    else
                    {
                        var opening = parenthesisStack.Pop();
                        tupleList.Add(new Tuple<Parenthesis, Parenthesis>(opening, parenthesis));
                    }
                }
            }

            // IndexOf should be changed. store at stack. new class -> index + Parenthesis?
            var indexesCollection = tupleList.Select(x => new { openingIndex = input.IndexOf(x.Item1), closingIndex = input.IndexOf(x.Item2) });
            var groups = new List<IList<Symbol>>();
            foreach (var pair in indexesCollection)
            {
                // -1 to account for connective in front of the () pair. + 2 at take to account for the -1 in skip.
                // TODO verify if all inputs are in CONNECTIVE(PREDICATE,PREDICATE) format?
                var toBeAdded = input.Skip(pair.openingIndex - 1).Take(pair.closingIndex - pair.openingIndex + 2);
                groups.Add(toBeAdded.ToList());
            }

            return groups;
        }
    }
}
