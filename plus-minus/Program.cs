using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plus_minus
{
    class Program
    {
        //https://www.hackerrank.com/challenges/plus-minus
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[] numbers = InitializeNumbers(N);

            Console.WriteLine(string.Format("{0:0.000000}", FractionOfPositives(numbers)));
            Console.WriteLine(string.Format("{0:0.000000}", FractionOfNegatives(numbers)));
            Console.WriteLine(string.Format("{0:0.000000}", FractionOfZeroes(numbers)));

            Console.ReadLine();
        }

        private static decimal FractionOfPositives(int[] numbers)
        {
            int countOfPositives = 0;

            foreach (var item in numbers)
            {
                if (item > 0)
                    countOfPositives++;
            }

            return decimal.Round((decimal)countOfPositives / numbers.Length, 6);
        }

        private static decimal FractionOfZeroes(int[] numbers)
        {
            int countOfZeros = 0;

            foreach (var item in numbers)
            {
                if (item == 0)
                    countOfZeros++;
            }

            return decimal.Round((decimal)countOfZeros / numbers.Length, 6);
        }

        private static decimal FractionOfNegatives(int[] numbers)
        {
            int countOfNegatives = 0;

            foreach (var item in numbers)
            {
                if (item < 0)
                    countOfNegatives++;
            }

            return decimal.Round((decimal)countOfNegatives / numbers.Length, 6);
        }

        private static int[] InitializeNumbers(int n)
        {
            string[] secondLine = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Convert.ToInt32(secondLine[i]);
            }

            return numbers;
        }
    }
}
