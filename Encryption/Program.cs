using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        //https://www.hackerrank.com/challenges/encryption
        static void Main(string[] args)
        {
            string plainText = Console.ReadLine();
            int N = plainText.Length;

            int min = (int)Math.Floor(Math.Sqrt(N));
            int max = (int)Math.Ceiling(Math.Sqrt(N));

            int gridRows, gridColumns;
            SetGridDimentions(min, max, N, out gridRows, out gridColumns);

            char[,] encryptedGrid = PrepareGrid(plainText, gridRows, gridColumns);

            Console.WriteLine(GetEncryptedString(encryptedGrid));

            Console.ReadLine();
        }

        private static void SetGridDimentions(int min, int max, int n, out int gridRows, out int gridColumns)
        {
            int area = min * max;
            if (area < n)
            {
                gridRows = max;
                gridColumns = max;
            }
            else
            {
                gridRows = min;
                gridColumns = max;
            }
        }

        private static string GetEncryptedString(char[,] encryptedGrid)
        {
            StringBuilder encryptedText = new StringBuilder();
            for (int j = 0; j < encryptedGrid.GetLength(1); j++)
            {
                for (int i = 0; i < encryptedGrid.GetLength(0); i++)
                {
                    if (((j * encryptedGrid.GetLength(0)) + i) < encryptedGrid.Length)
                        encryptedText.Append(encryptedGrid[i, j]);
                }
                encryptedText.Append(" ");
            }

            return encryptedText.ToString().TrimEnd(' ');

        }

        private static char[,] PrepareGrid(string plainText, int gridRows, int gridColumns)
        {
            char[,] elements = new char[gridRows, gridColumns];

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridColumns; j++)
                {

                    if (((i * gridColumns) + j) < plainText.Length)
                        elements[i, j] = plainText[((i) * gridColumns) + j];
                }
            }

            return elements;
        }


    }
}
