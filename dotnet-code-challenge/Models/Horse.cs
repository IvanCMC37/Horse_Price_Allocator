using System;

namespace dotnet_code_challenge.Model
{
    public class Horse
    {
        public int HorseID { get; }
        public string HorseName { get; }
        public double Price { get; }

        public Horse(int horseID, String horseName, double price)
        {
            HorseID = horseID;
            HorseName = horseName;
            Price = price;
        }
    }
}
