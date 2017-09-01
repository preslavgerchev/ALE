using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALEConsole
{
    public static class Parser
    {
        public static string RemoveWhiteSpaces(this string input)
        {
            string pattern = "\\s+";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(input, replacement);
        }

        public static void ParseToTree(this string input)
        {
            
        }
    }
}
