using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace extra_long_factorials
{
    class Program
    {
        //https://www.hackerrank.com/challenges/extra-long-factorials
        static void Main(string[] args)
        {
            int N = Convert.ToInt16(Console.ReadLine());

            BigInteger factorialvalue = GetFactorialValue(N);
            Console.WriteLine(factorialvalue);
            Console.ReadLine();
        }

        private static BigInteger GetFactorialValue(BigInteger n)
        {
            if (n == 1) return 1;
            return n * GetFactorialValue(n - 1);
        }
    }
}
