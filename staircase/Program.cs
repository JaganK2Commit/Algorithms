using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staircase
{
    class Program
    {
        //https://www.hackerrank.com/challenges/staircase
        static void Main(string[] args)
        {
            int size = Convert.ToInt16(Console.ReadLine());
            char symbole1 = '#';
            char symbole2 = ' ';

            for (int i = 0; i < size; i++)
            {
                for (int j = size - 1; j >= 0; j--)
                {
                    if (j <= i)
                        Console.Write(symbole1);
                    else
                        Console.Write(symbole2);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
