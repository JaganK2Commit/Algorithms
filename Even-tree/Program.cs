using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_tree
{
    class Program
    {
        //https://www.hackerrank.com/challenges/even-tree
        static void Main(string[] args)
        {
            string[] t_inputs = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(t_inputs[0]);
            int M = Convert.ToInt32(t_inputs[1]);

            Dictionary<int, Tuple<int, int, List<int>>> tree = InitializeTree(N, M);

            Console.WriteLine(GetCountOfAdjacentsToRemove(tree));

            Console.ReadLine();
        }

        private static int GetCountOfAdjacentsToRemove(Dictionary<int, Tuple<int, int, List<int>>> tree)
        {
            return RemoveAdjacent(tree, 1, tree[1].Item3.FirstOrDefault(), 0);
        }

        private static int RemoveAdjacent(Dictionary<int, Tuple<int, int, List<int>>> tree,
            int currentVertex, int parentVertex, int countRemoveAdjacents)
        {
            if (tree[currentVertex].Item3.Count == 0)
                return countRemoveAdjacents;

            // If number of vertices is even, the vertex can be considered as independent tree
            if (tree[currentVertex].Item1 % 2 == 0 && tree[currentVertex].Item2 != 0)
                countRemoveAdjacents++;

            foreach (var v in tree[currentVertex].Item3)
            {
                countRemoveAdjacents = RemoveAdjacent(tree, v, currentVertex, countRemoveAdjacents);
            }

            return countRemoveAdjacents;
        }

        private static Dictionary<int, Tuple<int, int, List<int>>> InitializeTree(int n, int m)
        {
            Dictionary<int, Tuple<int, int, List<int>>> tree = new Dictionary<int, Tuple<int, int, List<int>>>();

            InitializeVertices(tree, n);
            InitializeEdges(tree, m);

            return tree;
        }

        private static void InitializeEdges(Dictionary<int, Tuple<int, int, List<int>>> tree, int m)
        {
            for (int i = 0; i < m; i++)
            {
                string[] tmp = Console.ReadLine().Split(' ');
                int vertex2 = Convert.ToInt32(tmp[0]);
                int vertex1 = Convert.ToInt32(tmp[1]);

                List<int> adjacents = tree[vertex1].Item3;
                adjacents.Add(vertex2);

                tree[vertex1] = new Tuple<int, int, List<int>>(tree[vertex1].Item1, tree[vertex1].Item2, adjacents);
                tree[vertex2] = new Tuple<int, int, List<int>>(tree[vertex2].Item1, vertex1, tree[vertex2].Item3);

                BubbleVerticesCountToRoot(tree, vertex1);
            }
        }

        private static void BubbleVerticesCountToRoot(Dictionary<int, Tuple<int, int, List<int>>> tree, int vertex1)
        {
            int parentVertex = vertex1;
            do
            {
                int childCount = tree[parentVertex].Item1;
                List<int> children = tree[parentVertex].Item3;
                tree[parentVertex] = new Tuple<int, int, List<int>>(childCount + 1,
                    tree[parentVertex].Item2, tree[parentVertex].Item3);
                parentVertex = tree[parentVertex].Item2;
            }
            while (tree.ContainsKey(parentVertex));

        }

        private static void InitializeVertices(Dictionary<int, Tuple<int, int, List<int>>> tree, int n)
        {
            for (int i = 0; i < n; i++)
            {
                tree.Add(i + 1, new Tuple<int, int, List<int>>(1, 0, new List<int>()));
            }
        }
    }
}
