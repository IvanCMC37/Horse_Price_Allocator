using dotnet_code_challenge.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace dotnet_code_challenge.Utilities
{
    public class XmlLoader : IDataLoader
    {
        // Define file path
        private readonly string filePath = @"..\..\..\FeedData\Caulfield_Race1.xml";

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
                Console.WriteLine("Couldn't find the given xml file!!!");
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
            // xml object to use later
            XElement root = XElement.Load(filePath);

            // perfrom xml data checking eg. should have 2 horse details in 2 sections
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList list_1 = doc.SelectNodes("meeting/races/race/horses/*");
            int numHorses_1 = list_1.Count;

            XmlNodeList list_2 = doc.SelectNodes("meeting/races/race/prices/price/horses/horse");
            int numHorses_2 = list_2.Count;

            // only proceed if both number matches
            if (numHorses_1 == numHorses_2)
            {
                assignInfos(root);
            }
            else
            {
                Console.WriteLine("Xml data is having error");
                return;
            }
        }

        // function to get price of certain horse number 
        private double getPrice(XElement root, int id)
        {
            // get all price in given xml file
            var horsePrices = root.Element("races").Element("race").Element("prices").Element("price").Element("horses").Elements("horse");

            // find the price related to horseid
            foreach (var horsePrice in horsePrices)
            {
                if (Convert.ToInt32(horsePrice.Attribute("number").Value) == id)
                {
                    return Convert.ToDouble(horsePrice.Attribute("Price").Value);
                }
            }

            // return 0 if not found
            return 0;
        }

        // function to assign data to object list
        private void assignInfos(XElement root)
        {
            // clear list every time to prevent dupulcation
            Horses.Clear();

            // variables to use later
            double price = 0.0;
            String horseName = "";
            int horseID = 0;

            // get race start time from xml
            String timeStamp = root.Element("races").Element("race").Element("start_time").Value;

            // get all participants details from xml
            var horseInfos = root.Element("races").Element("race").Element("horses").Elements("horse");

            // get horse name, number and price, then assign to list object 
            foreach (var horseInfo in horseInfos)
            {
                horseID = Convert.ToInt32(horseInfo.Element("number").Value);
                horseName = horseInfo.Attribute("name").Value;
                price = getPrice(root, horseID);

                if (price == 0)
                {
                    Console.WriteLine("Price data didn't match with given horseID\n");
                    return;
                }

                Horses.Add(new Horse(horseID, horseName, price));
            }

            // print out list in order and output json
            CustomUtilities.DisplayAll(timeStamp, Horses, 1);
        }
    }
}
