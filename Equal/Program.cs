using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal
{
    class Program
    {
        //https://www.hackerrank.com/challenges/equal
        static void Main(string[] args)
        {
            // Number of Test Cases.
            int T = Convert.ToInt32(Console.ReadLine());

            // Repeat for each Test case
            for (int i = 0; i < T; i++)
            {
                // Number of collegues
                int N = Convert.ToInt32(Console.ReadLine());

                // Initial distribution of chocolates
                int[] distributions = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                Console.WriteLine(GetNumberOfOperationsForEquality(distributions));
            }

            Console.ReadLine();
        }

        private static int GetNumberOfOperationsForEquality(int[] distribution)
        {
            int difference = 0;
            int numberOfOperations = 0;

            //Array.Sort(distribution);
            for (int i = 0; i < distribution.Length - 1; i++)
            {
                int minDistributionindex = GetMinimumDistributionIndex(distribution);
                int localMaxDistributionIndex = GetNextMinimumDistributionIndex(distribution, minDistributionindex);

                if (localMaxDistributionIndex == -1) break;

                difference = Math.Abs(distribution[minDistributionindex] - distribution[localMaxDistributionIndex]);

                if (difference == 0) continue;

                if (difference > 0)
                {
                    numberOfOperations += DistributeChocolate(distribution, localMaxDistributionIndex, difference);
                }

            }
            return numberOfOperations;

        }

        private static int GetMinimumDistributionIndex(int[] distributions)
        {
            int minIndex = -1;
            int tmp = int.MaxValue;

            for (int i = 0; i < distributions.Length; i++)
            {
                if (distributions[i] < tmp)
                {
                    tmp = distributions[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        private static int GetNextMinimumDistributionIndex(int[] distributions, int v)
        {
            int minIndex = v;
            int nextMinIndex = -1;
            int tmp = int.MaxValue;

            for (int i = 0; i < distributions.Length; i++)
            {
                if (distributions[i] > distributions[minIndex]
                    && distributions[i] < tmp)
                {
                    tmp = distributions[i];
                    nextMinIndex = i;
                }
            }
            return nextMinIndex;
        }

        private static int DistributeChocolate(int[] distribution, int localMax, int difference)
        {
            int chocolatesToDistribute = 0;
            int numberOfOperations = 0;
            while (difference > 0)
            {
                if (difference == 1) chocolatesToDistribute = 1;
                else if (difference < 5) chocolatesToDistribute = 2;
                else chocolatesToDistribute = 5;

                difference = difference - chocolatesToDistribute;

                for (int i = 0; i < distribution.Length; i++)
                {
                    if (i != localMax)
                        distribution[i] = distribution[i] + chocolatesToDistribute;
                }
                numberOfOperations++;
            }
            return numberOfOperations;

        }
    }
}
