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
            string input = "&(>(A,B),~(C))";

            input.ParseToTree();

        }
    }
}
