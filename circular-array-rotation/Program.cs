using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circular_array_rotation
{
    class Program
    {
        //https://www.hackerrank.com/challenges/circular-array-rotation
        static void Main(string[] args)
        {
            string[] inputFirstLine = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(inputFirstLine[0]);
            int k = Convert.ToInt32(inputFirstLine[1]);
            int q = Convert.ToInt32(inputFirstLine[2]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] integers = Array.ConvertAll(a_temp, Int32.Parse);
            int[] queries = new int[q];

            for (int i = 0; i < q; i++)
            {
                queries[i] = Convert.ToInt32(Console.ReadLine());
            }

            integers = RotateArray(integers, k);

            foreach (var item in queries)
            {
                Console.WriteLine(integers[item]);
            }
            Console.ReadLine();
        }

        private static int[] RotateArray(int[] integers, int k)
        {
            integers = RotateSubAray(integers, 0,(integers.Length - k - 1));
            integers = RotateSubAray(integers, (integers.Length - k), integers.Length - 1);
            integers = RotateSubAray(integers, 0, integers.Length - 1);
            return integers;
        }

        private static int[] RotateSubAray(int[] integers, int v1, int v2)
        {
            while (v1 <= v2)
            {
                int temp = integers[v1];
                integers[v1] = integers[v2];
                integers[v2] = temp;
                v1++;
                v2--;
            }
            return integers;
        }
    }
}
