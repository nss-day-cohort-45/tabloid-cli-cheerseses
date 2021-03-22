using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorManager : IUserInterfaceManager
    {
        readonly IUserInterfaceManager _parentUI;
        ConsoleColor bgColor = new ConsoleColor();
        ConsoleColor fgColor = new ConsoleColor();

        public ColorManager(IUserInterfaceManager parentUI)
        {
            _parentUI = parentUI;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Background Color Menu");
            Console.WriteLine(" 1) White");
            Console.WriteLine(" 2) Blue");
            Console.WriteLine(" 3) Red");
            Console.WriteLine(" 4) Green");
            Console.WriteLine(" 5) Reset to Default");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            { 
                case "1":
                    bgColor = ConsoleColor.White;
                    fgColor = ConsoleColor.Black;
                    Color();
                    return this;
                case "2":
                    bgColor = ConsoleColor.DarkBlue;
                    fgColor = ConsoleColor.White;
                    Color();
                    return this;
                case "3":
                    bgColor = ConsoleColor.DarkRed;
                    fgColor = ConsoleColor.White;
                    Color();
                    return this;
                case "4":
                    bgColor = ConsoleColor.DarkGreen;
                    fgColor = ConsoleColor.White;
                    Color();
                    return this;
                case "5":
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("");
                    return this;
                case "0":
                    Console.Clear();
                    return _parentUI;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void Color()
        {

            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;

            Console.Clear();

            // this is just to get the color to show.
            Console.WriteLine("");
            
        }
    }
}
