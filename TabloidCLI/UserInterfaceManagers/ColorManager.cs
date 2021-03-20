using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorManager : IUserInterfaceManager
    {
        readonly IUserInterfaceManager _parentUI;

        public ColorManager(IUserInterfaceManager parentUI)
        {
            _parentUI = parentUI;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Background Color Menu");
            Console.WriteLine(" 1) ");
            Console.WriteLine(" 2) ");
            Console.WriteLine(" 3) ");
            Console.WriteLine(" 4) ");
            Console.WriteLine(" 5) Reset to Default");
            Console.WriteLine(" 0) Go Back without making changes");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            { 
                case "1":
                    Color();
                    return this;
                case "2":
                    Color();
                    return this;
                case "3":
                    Color();
                    return this;
                case "4":
                    Color();
                    return this;
                case "5":
                    Color();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void Color()
        {


            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Clear();

            // this is just to get the color to show.
            Console.WriteLine("");
            
        }
    }
}
