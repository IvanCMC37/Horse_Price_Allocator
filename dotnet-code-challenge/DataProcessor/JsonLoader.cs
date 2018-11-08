using dotnet_code_challenge.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace dotnet_code_challenge.Utilities
{
    public class JsonLoader : IDataLoader
    {
        // Define file path
        private readonly string filePath = @"..\..\..\FeedData\Wolferhampton_Race1.json";

        // list object to use later
        private IList<Horse> Horses = new List<Horse>();

        // entry function of the loader
        public void processData()
        {
            // check if the file exist
            bool fileCheck = File.Exists(filePath);

            // only proceed if file exist
            if (fileCheck == false)
            {
                Console.WriteLine("Couldn't find the given json file!!!");
                return;
            }
            else
            {
                Deserialize();
            }
        }

        // function to deserialize data
        public void Deserialize()
        {
            // read file into a string and deserialize JSON
            var jsonString = File.ReadAllText(filePath);
            var SteamDetails = JsonConvert.DeserializeObject<dynamic>(jsonString);

            // perfrom json data checking eg. should have 2 horse details in 2 sections
            int numHorses_1 = ((JArray)SteamDetails["RawData"]["Markets"][0]["Selections"]).Count;
            int numHorses_2 = ((JArray)SteamDetails["RawData"]["Participants"]).Count;

            // only proceed if both number matches
            if (numHorses_1 == numHorses_2)
            {
                assignInfos(SteamDetails, numHorses_1);
            }
            else
            {
                Console.WriteLine("Xml data is having error");
                return;
            }
        }

        // function to assign data to object list
        private void assignInfos(dynamic SteamDetails, int numHorses)
        {
            // clear list every time to prevent dupulcation
            Horses.Clear();

            // variables to use later
            double price = 0.0;
            String horseName = "";
            int horseID = 0;

            // Use JArray Class to gets child JSON tokens
            var text = SteamDetails["RawData"]["Markets"][0]["Selections"];

            // get race start time from json
            String timeStamp = SteamDetails["RawData"]["StartTime"];

            // get horse name, number and price, then assign to list object 
            for (int i = 0; i < numHorses; i++)
            {
                horseID = text[i]["Tags"]["participant"];
                horseName = text[i]["Tags"]["name"];
                price = text[i]["Price"];
                Horses.Add(new Horse(horseID, horseName, price));
            }

            // print out list in order and output json
            CustomUtilities.DisplayAll(timeStamp, Horses, 2);
        }
    }
}
