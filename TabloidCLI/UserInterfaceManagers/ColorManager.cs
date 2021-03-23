using System;
using System.Collections.Generic;
using System.Text;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorManager : IUserInterfaceManager
    {
        readonly IUserInterfaceManager _parentUI;
        ConsoleColor bgColor = new ConsoleColor();
        ConsoleColor fgColor = new ConsoleColor();
        private BGColorRepository _bgColorRepository;
        private string _connectionString;

        public ColorManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _bgColorRepository = new BGColorRepository(connectionString);
            _connectionString = connectionString;
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
            BGColor choice = new BGColor();
            choice.ColorOption = Console.ReadLine();

            switch (choice.ColorOption)
            { 
                case "1":
                    bgColor = ConsoleColor.White;
                    fgColor = ConsoleColor.Black;
                    Color(choice);
                    return this;
                case "2":
                    bgColor = ConsoleColor.DarkBlue;
                    fgColor = ConsoleColor.White;
                    Color(choice);
                    return this;
                case "3":
                    bgColor = ConsoleColor.DarkRed;
                    fgColor = ConsoleColor.White;
                    Color(choice);
                    return this;
                case "4":
                    bgColor = ConsoleColor.DarkGreen;
                    fgColor = ConsoleColor.White;
                    Color(choice);
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

        private void Color(BGColor option)
        {

            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            _bgColorRepository.Update(option);
            Console.Clear();

            // this is just to get the color to show.
            Console.WriteLine("");
            
        }
    }
}
