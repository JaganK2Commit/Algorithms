using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_very_big_sum
{
    class Program
    {
        //https://www.hackerrank.com/challenges/a-very-big-sum?h_r=next-challenge&h_v=zen
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            string[] array = InitializeIntegers(N);

            Console.WriteLine(CalculateSumOfIntegers(array));
            Console.ReadLine();
        }

        private static string CalculateSumOfIntegers(string[] array)
        {
            string summedValue = string.Empty;
            foreach (var item in array)
            {
                summedValue = DoSum(item, summedValue);
            }

            return summedValue;
        }

        private static string DoSum(string item, string summedValue)
        {
            int carryFwd = 0;

            if (summedValue.Equals(string.Empty)) return item;
            int length = item.Length > summedValue.Length ? item.Length : summedValue.Length;

            item = BalanceStringWithZeros(item, length);
            summedValue = BalanceStringWithZeros(summedValue, length);

            StringBuilder newSummedValue = new StringBuilder();
            for (int i = length - 1; i >= 0; i--)
            {
                int itemValueAtIndex = i < item.Length ? int.Parse(item[i].ToString()) : 0;
                int summedValueAtIndex = i < summedValue.Length ? int.Parse(summedValue[i].ToString()) : 0;
                int newSumValueAtIndex = (itemValueAtIndex + summedValueAtIndex + carryFwd) % 10;
                carryFwd = (itemValueAtIndex + summedValueAtIndex + carryFwd) / 10;

                newSummedValue.Insert(0, newSumValueAtIndex.ToString());
            }

            if (carryFwd != 0)
                newSummedValue.Insert(0, carryFwd.ToString());

            return newSummedValue.ToString();
        }

        private static string BalanceStringWithZeros(string item, int length)
        {
            if (item.Length == length) return item;

            StringBuilder newItem = new StringBuilder();

            int index = 0;
            while (index < Math.Abs(length - item.Length))
            { newItem.Append("0"); index++; }

            return newItem.Append(item).ToString();
        }

        private static string[] InitializeIntegers(int n)
        {
            string[] integers = new string[n];
            string[] consoleLine = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                integers[i] = consoleLine[i];
            }

            return integers;
        }
    }
}
