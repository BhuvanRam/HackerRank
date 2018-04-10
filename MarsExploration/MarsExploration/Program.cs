using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsExploration
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "SOSSPSSQSSOR";
            int result = marsExploration(s);
            Console.WriteLine(result);
        }


        static int marsExploration(string s)
        {
            // Complete this function            
            int d = 0;
            for (int i = 0; i < s.Length; i = i + 3)
            {
                string subString = s.Substring(i, 3);
                if (!subString.Equals("SOS"))
                {
                    char[] cSplittedChars = subString.ToCharArray();
                    char[] actualChars = "SOS".ToCharArray();
                    var dCharacters = cSplittedChars.Except(actualChars);
                    d = d + dCharacters.Count();
                }
            }
            return d;

        }
    }
}
