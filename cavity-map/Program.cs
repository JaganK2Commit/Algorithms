using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cavity_map
{
    class Program
    {
        //https://www.hackerrank.com/challenges/cavity-map
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] depths = InitializeDepths(n);

            char[,] cavities = BuildCavities(depths);

            PrintOutput(cavities);

            Console.ReadLine();
        }

        private static void PrintOutput(char[,] cavities)
        {
            for (int i = 0; i < cavities.GetLength(0); i++)
            {
                for (int j = 0; j < cavities.GetLength(1); j++)
                {
                    Console.Write(cavities[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] BuildCavities(int[,] depths)
        {
            char[,] cavities = new char[depths.GetLength(0), depths.GetLength(1)];
            bool[] visited = new bool[depths.GetLength(0) * depths.GetLength(1)];
            if (depths.GetLength(0) > 0 && depths.GetLength(1) > 0)
                cavities = isCavityAt(depths, cavities, 1, 1, visited);

            return FillDepths(cavities, depths);
        }

        private static char[,] FillDepths(char[,] cavities, int[,] depths)
        {
            for (int i = 0; i < cavities.GetLength(0); i++)
            {
                for (int j = 0; j < cavities.GetLength(1); j++)
                {
                    if (cavities[i, j] != 'X')
                        cavities[i, j] = Convert.ToChar(depths[i, j]);
                }

            }
            return cavities;
        }

        private static char[,] isCavityAt(int[,] depths, char[,] cavities, int v1, int v2, bool[] visited)
        {

            if (v1 >= depths.GetLength(0) - 1 || v2 >= depths.GetLength(1) - 1
                || visited[v1 * (depths.GetLength(0)) + v2])
                return cavities;

            visited[v1 * (depths.GetLength(0)) + v2] = true;

            if (depths[v1, v2] > depths[v1 - 1, v2] &&
                depths[v1, v2] > depths[v1, v2 - 1] &&
                depths[v1, v2] > depths[v1, v2 + 1] &&
                    depths[v1, v2] > depths[v1 + 1, v2])
                cavities[v1, v2] = 'X';

            cavities = isCavityAt(depths, cavities, v1 + 1, v2, visited);
            cavities = isCavityAt(depths, cavities, v1, v2 + 1, visited);
            return cavities;
        }

        private static int[,] InitializeDepths(int n)
        {
            int[,] depths = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] tmp = Console.ReadLine().ToArray().Select(c => Convert.ToInt32(c)).ToArray();
                for (int j = 0; j < tmp.Length; j++)
                {
                    depths[i, j] = tmp[j];
                }
            }
            return depths;
        }
    }
}
