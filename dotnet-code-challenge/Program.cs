using System;

namespace dotnet_code_challenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //setup in order to use menu functions
            var mainMenu = new Menu.MainMenu();
            mainMenu.run();
        }
    }
}

