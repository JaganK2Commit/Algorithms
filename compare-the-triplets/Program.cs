using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compare_the_triplets
{
    class Program
    {
        //https://www.hackerrank.com/challenges/compare-the-triplets
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            ratings A = new ratings(
                Convert.ToInt32(firstLine[0]),
                Convert.ToInt32(firstLine[1]),
                Convert.ToInt32(firstLine[2]));

            string[] secondLine = Console.ReadLine().Split(' ');
            ratings B = new ratings(
                Convert.ToInt32(secondLine[0]),
                Convert.ToInt32(secondLine[1]),
                Convert.ToInt32(secondLine[2]));

            int scoreOfA = compareRatings(A, B);
            int scoreOfB = compareRatings(B, A);

            Console.WriteLine(scoreOfA.ToString() + " " + scoreOfB.ToString());
            Console.ReadLine();
        }

        private static int compareRatings(ratings a, ratings b)
        {
            int score = 0;
            if (a.clarity > b.clarity) score++;
            if (a.difficulty > b.difficulty) score++;
            if (a.originality > b.originality) score++;

            return score;
        }
    }

    public struct ratings
    {
        public int clarity;
        public int originality;
        public int difficulty;

        public ratings(int p0, int p1, int p2)
        {
            clarity = p0;
            originality = p1;
            difficulty = p2;
        }
    }
}
