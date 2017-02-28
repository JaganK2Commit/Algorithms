using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_in_words
{
    class Program
    {
        //https://www.hackerrank.com/challenges/the-time-in-words
        static void Main(string[] args)
        {
            // inputs
            int hours = Convert.ToInt32(Console.ReadLine());
            int mins = Convert.ToInt32(Console.ReadLine());

            // initializations

            string timeInWords = GetTimeInWords(hours, mins);
            Console.WriteLine(timeInWords);
            Console.ReadLine();
        }

        private static string GetTimeInWords(int hours, int mins)
        {
            StringBuilder timeInWords = new StringBuilder();
            if (mins == 0)
            {
                timeInWords.Append(GetHoursInWords(hours));
                timeInWords.Append(" o' clock");
                return timeInWords.ToString();
            }
            if (mins <= 30)
            {
                timeInWords.Append(GetMinsInWords(mins));
                timeInWords.Append(" past ");
                timeInWords.Append(GetHoursInWords(hours));
                return timeInWords.ToString();
            }
            else
            {
                timeInWords.Append(GetMinsInWords(mins));
                timeInWords.Append(" to ");
                timeInWords.Append(GetHoursInWords(hours + 1));
                return timeInWords.ToString();
            }
        }

        private static string GetMinsInWords(int mins)
        {
            mins = mins > 30 ? 60 - mins : mins;
            if (mins % 15 != 0)
            {
                if (mins <= 20)
                    return InitializeWords(mins) + (mins == 1 ? " minute" : " minutes");
                else
                {
                    return GetMinsInWords_GreaterThan20(mins) + " minutes";
                }
            }
            else
            {
                switch (mins)
                {
                    case 15:
                    case 45: return "quarter";
                    case 30: return "half";
                    default: return "";
                }
            }
        }

        private static string GetMinsInWords_GreaterThan20(int mins)
        {
            return mins == 30 ? InitializeWords(21) :
                InitializeWords(20) + " " + InitializeWords(mins - 20);
        }

        private static string GetHoursInWords(int hours)
        {
            return InitializeWords(hours);
        }

        private static string InitializeWords(int n)
        {
            string[] lookUpWords = {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "ten",
                "eleven",
                "twelve",
                "thirteen",
                "fourteen",
                "fifteen",
                "sixteen",
                "seventeen",
                "eighteen",
                "nineteen",
                "twenty",
                "thirty"
            };
            return lookUpWords[n];
        }


    }
}
