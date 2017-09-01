using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALEConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var properOutput = "&(>(A,B),~(0))";
            var nodes = properOutput.ParseToSymbols();
            Console.WriteLine(string.Join(string.Empty, nodes.Select(n => n.ToString())));
            Console.WriteLine(string.Join("\n", nodes.Select(n => n.GetType())));
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
