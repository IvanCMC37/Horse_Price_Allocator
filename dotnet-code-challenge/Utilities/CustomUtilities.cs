using dotnet_code_challenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge.Utilities
{
    public static class CustomUtilities
    {
        //function for checking if user input is within range
        public static bool IsWithinRange(this int value, int min, int max) => value >= min && value <= max;

        // function to print all details, and prepare json serialization
        public static void DisplayAll(String timeStamp, IEnumerable<Horse> Horses, int select)
        {
            // Order the list into a new list
            List<Horse> sortedHorseList = Horses.OrderBy(x => x.Price).ToList();

            // define the format of writeline later
            const string format = "{0,-10}{1,-30}{2,10:N1}";

            Console.WriteLine("Race DateTime : " + timeStamp);
            Console.WriteLine(format, "HorseID", "HorseName", "Price");
            foreach (var x in sortedHorseList)
            {
                Console.WriteLine(format, x.HorseID, x.HorseName, x.Price);
            }

            Console.WriteLine();
        }
    }
}
