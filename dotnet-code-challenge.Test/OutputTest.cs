using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Xunit;
using dotnet_code_challenge.DataProcessor;
using dotnet_code_challenge.Utilities;

namespace dotnet_code_challenge.Test
{
    public class OutputTest
    {
        // determine output of each loader
        [Fact]
        public void xmlLoader_Output_Test()
        {
            int expectedNumberOfHorse = 2;

            XmlLoader xmlLoader = new dotnet_code_challenge.DataProcessor.XmlLoader();
            xmlLoader.Deserialize();
            string filePath = @"..\..\..\Output\Wolferhampton_Race.json";
            var jsonString = File.ReadAllText(filePath);
            var SteamDetails = JsonConvert.DeserializeObject<dynamic>(jsonString);
            int actualNumberOfHorse = ((JArray)SteamDetails["Horses"]).Count;

            Assert.Equal(expectedNumberOfHorse, actualNumberOfHorse);
        }

        [Fact]
        public void jsonLoader_Output_Test()
        {
            int expectedNumberOfHorse = 2;

            JsonLoader JsonLoader = new dotnet_code_challenge.DataProcessor.JsonLoader();
            JsonLoader.Deserialize();
            string filePath = @"..\..\..\Output\Caulfield_Race.json";
            var jsonString = File.ReadAllText(filePath);
            var SteamDetails = JsonConvert.DeserializeObject<dynamic>(jsonString);
            int actualNumberOfHorse = ((JArray)SteamDetails["Horses"]).Count;

            Assert.Equal(expectedNumberOfHorse, actualNumberOfHorse);
        }
    }
}
