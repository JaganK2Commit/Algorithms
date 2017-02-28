using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigger_is_greater
{
    class Program
    {
        //https://www.hackerrank.com/challenges/bigger-is-greater
        static void Main(string[] args)
        {
            //input

            int n = Convert.ToInt32(Console.ReadLine());

            string[] words = new string[n];
            for (int i = 0; i < n; i++)
            {
                words[i] = Console.ReadLine();
            }

            foreach (var w in words)
            {
                Console.WriteLine(GetGreaterLexigraphically(w));
            }

            Console.ReadLine();
        }

        private static string GetGreaterLexigraphically(string w)
        {
            int end = w.Length - 1;
            int start = 0;
            int iterationCount = w.Length;
            StringBuilder newString = new StringBuilder();
            bool isReordered = false;

            for (int j = end; j > start; j--)
            {
                if (!isReordered && (int)w[j] > (int)w[j - 1])
                {
                    string firstPart = w.Substring(0, j - 1);
                    string secondPart = w.Substring(j);
                    char localMin = w[j - 1];
                    string tmp_sortedSecondPart = getLexicalOrder(secondPart + localMin);
                    int localMaxIndex = tmp_sortedSecondPart.IndexOf(localMin) + 1;
                    char localMax = tmp_sortedSecondPart[localMaxIndex];

                    string secondPartOrdered = getLexicalOrder(secondPart + localMin, localMax.ToString());

                    newString.Append(firstPart);
                    newString.Append(localMax);
                    newString.Append(secondPartOrdered);
                    isReordered = true;
                    break;
                }
            }

            if (newString.Length == 0) newString.Append("no answer");
            return newString.ToString();
        }

        private static string getLexicalOrder(string secondPart, string ignore = "")
        {

            char[] elements = secondPart.ToArray();
            if (!string.IsNullOrEmpty(ignore))
                elements = elements.Where(c => c != ignore[0]).ToArray();
            Array.Sort(elements);
            return new string(elements);
        }
    }
}
