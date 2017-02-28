using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_conversion
{
    class Program
    {
        //https://www.hackerrank.com/challenges/time-conversion
        static void Main(string[] args)
        {
            string tweleveHourFormat = Console.ReadLine();
            string[] timeElements = tweleveHourFormat.Split(':');
            string newHour = ConvertHours(timeElements[0], timeElements[2]);
            string newMinues = timeElements[1];
            string newSecs = timeElements[2].Substring(0, 2);

            Console.WriteLine("{0}:{1}:{2}", newHour, newMinues, newSecs);
            Console.ReadLine();
        }

        private static string ConvertHours(string hours,string secondsFormat )
        {
            int ihours = Convert.ToInt32(hours);
            string newHour = "00";

            if (ihours > 12) return newHour;

            if (secondsFormat.Contains("AM"))
            {
                return hours == "12" ? newHour : hours;
            }
            else if (secondsFormat.Contains("PM"))
            {
                return hours == "12" ? "24" : (ihours + 12).ToString();
            }
            else
                return newHour;
        }
    }
}
