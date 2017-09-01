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
            foreach(var grp in bla)
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
                .Where(y => y.Side == ParenthesisSide.Opening)
                .Select(x => new { parenthesis = x, place = input.IndexOf(x) });

            var closingParenthesis = input
                .Where(x => x is Parenthesis)
                .Cast<Parenthesis>()
                .Where(y => y.Side == ParenthesisSide.Closing)
                .Select(x => new { parenthesis = x, place = input.IndexOf(x) });


            if (openingParenthesis.Count() != closingParenthesis.Count())
                // TODO custom exception, better message.
                throw new ArgumentException("invalid expression.");

            // TODO - should be taken into account that next ) is not always the proper one.
            var reversedClosing = closingParenthesis.Reverse();
            foreach (var item in openingParenthesis)
            {
                Console.WriteLine(item.parenthesis.Side);
                Console.WriteLine(item.place);
            }

            foreach (var item in reversedClosing)
            {
                Console.WriteLine(item.parenthesis.Side);
                Console.WriteLine(item.place);
            }

            var groups = new List<IList<Symbol>>();
            for (int i = 0; i < openingParenthesis.Count(); i++)
            {
                var opening = openingParenthesis.ElementAt(i);
                var closing = reversedClosing.ElementAt(i);
              

                var innerList = new List<Symbol>();
                var toBeAdded = input.Skip(opening.place - 1).Take(closing.place - opening.place + 2);
                innerList.AddRange(toBeAdded);
                groups.Add(innerList);
            }
            

            return groups;
        }
    }
}
