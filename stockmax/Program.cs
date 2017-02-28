using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockmax
{
    class Program
    {
        //https://www.hackerrank.com/challenges/stockmax
        static void Main(string[] args)
        {
            // Number of Test Cases.
            long T = Convert.ToInt64(Console.ReadLine());

            string[] inputs = new string[T];
            // Repeat for each Test case
            for (long i = 0; i < T; i++)
            {
                // Number of stock days
                long N = Convert.ToInt64(Console.ReadLine());

                // Initial distribution of stocks
                string t_inputStocks = Console.ReadLine();

                inputs[i] = t_inputStocks;
               
            }

            for (long i = 0; i < T; i++)
            {
                long[] stocks = Array.ConvertAll(inputs[i].Split(' '), Int64.Parse);
                Console.WriteLine(GetMaximumProfit(stocks));
            }

            Console.ReadLine();
        }

        private static long GetMaximumProfit(long[] stocks)
        {
            if (stocks.Length <= 1) return 0;
            long[] localStocks = InitializeLocalMaxStocks(stocks);

            long profit = 0;
            for (long i = 0; i < stocks.Length; i++)
            {
                profit += localStocks[i] - stocks[i]; 
            }

            return profit;
        }

        private static long[] InitializeLocalMaxStocks(long[] stocks)
        {

            // Calculate local maximum stock value of each day.
            long[] localMaxStocks = new long[stocks.Length];
            long tmp = stocks[stocks.Length - 1];

            for (long i = stocks.Length - 1; i >= 0; i--)
            {
                if (stocks[i] > tmp)
                    tmp = stocks[i];

                localMaxStocks[i] = tmp;
            }
            return localMaxStocks;
        }
    }
}
