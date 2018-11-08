using dotnet_code_challenge.Utilities;
using System;

namespace dotnet_code_challenge.Menu
{
    public class MainMenu
    {

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


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nYou are already at the bottom of main menu.\n");
                    continue;
                }


                if (!int.TryParse(input, out var option) || !option.IsWithinRange(1, 3))
                {
                    Console.WriteLine("\nInvalid input.Please give another input!!!\n");
                    continue;
                }
                Console.WriteLine();


                switch (option)
                {
                    case 1:

                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Goodbye, see you next time!");
                        return;
                }
            }
        }
    }
}
