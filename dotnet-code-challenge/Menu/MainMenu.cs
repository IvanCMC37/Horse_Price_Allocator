using dotnet_code_challenge.DataProcessor;
using dotnet_code_challenge.Utilities;
using System;

namespace dotnet_code_challenge.Menu
{
    public class MainMenu
    {
        private JsonLoader JsonLoader = new JsonLoader();
        private XmlLoader XmlLoader = new XmlLoader();

        public void run()
        {

            while (true)
            {
                Console.Write(
@"Welcome to beteasy data parser
==========================
1.  Caulfield race details
2   Wolferhampton race details
3.  Quit
Enter an option: ");

                var input = Console.ReadLine();

                //if user input an empty input, program will show that user is already at the bottom sub menu
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nYou are already at the bottom of main menu.\n");
                    continue;
                }

                //we only want the user to input a number that is within range of 1 to 3
                //if user failed, we will ask the user to give another input
                if (!int.TryParse(input, out var option) || !option.IsWithinRange(1, 3))
                {
                    Console.WriteLine("\nInvalid input.Please give another input!!!\n");
                    continue;
                }
                Console.WriteLine();

                //different options lead to different functions
                switch (option)
                {
                    case 1:
                        XmlLoader.processData();
                        break;
                    case 2:
                        JsonLoader.processData();
                        break;
                    case 3:
                        Console.WriteLine("Goodbye, see you next time!");
                        return;
                }
            }
        }
    }
}
