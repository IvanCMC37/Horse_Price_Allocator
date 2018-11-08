using dotnet_code_challenge.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            // preparation for json serialization
            var Serialize = new Serialize();
            Serialize.TimeStamp = timeStamp;
            Serialize.Horses = new List<Horse>();

            // Order the list into a new list
            List<Horse> sortedHorseList = Horses.OrderBy(x => x.Price).ToList();

            // define the format of writeline later
            const string format = "{0,-10}{1,-30}{2,10:N1}";

            Console.WriteLine("Race DateTime : " + timeStamp);
            Console.WriteLine(format, "HorseID", "HorseName", "Price");
            foreach (var x in sortedHorseList)
            {
                Console.WriteLine(format, x.HorseID, x.HorseName, x.Price);
                Serialize.Horses.Add(new Horse(x.HorseID, x.HorseName, x.Price));
            }

            //serialize JSON directly to a file
            if (select == 1)
            {
                using (StreamWriter file = File.CreateText(@"..\..\..\Output\Caulfield_Race.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, Serialize);
                }
            }
            else
            {
                using (StreamWriter file = File.CreateText(@"..\..\..\Output\Wolferhampton_Race.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, Serialize);
                }
            }

            Console.WriteLine("JSON output saved to ../Output");
            Console.WriteLine();
        }
    }
}
