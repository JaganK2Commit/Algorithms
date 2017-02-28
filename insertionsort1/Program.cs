using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertionsort1
{
    class Program
    {
        //https://www.hackerrank.com/challenges/insertionsort1
        static void Main(string[] args)
        {
            int Size = Convert.ToInt32(Console.ReadLine());

            int[] Arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            PrintArrayAfterSort(Arr);

            Console.ReadLine();
        }

        private static void PrintArrayAfterSort(int[] arr)
        {
            int j = arr.Length - 1;
            int tmp = arr[j];

            for (int i = j - 1; i >= 0; i--)
            {
                if (arr[i] > tmp)
                {
                    arr[i + 1] = arr[i];
                    PrintArrayAfterShift(arr);
                }
                else
                {
                    arr[i + 1] = tmp;
                    PrintArrayAfterShift(arr);
                    break;
                }
            }

            if (arr[0] > tmp)
            {
                arr[0] = tmp;
                PrintArrayAfterShift(arr);
            }
        }

        private static void PrintArrayAfterShift(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
