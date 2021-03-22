using System;

namespace TabloidCLI.UserInterfaceManagers
{
    public class MainMenuManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING =
            @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        public IUserInterfaceManager Execute()
        {

            // Main menu header
            Console.WriteLine(@"
            ██╗  ██╗ ██████╗ ██╗    ██╗██████╗ ██╗   ██╗  ██╗         .~~~~`\~~\
            ██║  ██║██╔═══██╗██║    ██║██╔══██╗╚██╗ ██╔╝  ██║        ;       ~~ \
            ███████║██║   ██║██║ █╗ ██║██║  ██║ ╚████╔╝   ██║        |           ;
            ██╔══██║██║   ██║██║███╗██║██║  ██║  ╚██╔╝    ╚═╝    ,--------,______|---.
            ██║  ██║╚██████╔╝╚███╔███╔╝██████╔╝   ██║     ██╗   /          \-----`    \  
            ╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝ ╚═════╝    ╚═╝     ╚═╝   `.__________`-_______-'");

            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1) My Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 6) Search by Tag");
            Console.WriteLine(" *) Color Themes");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": Console.Clear(); return new JournalManager(this, CONNECTION_STRING);
                case "2": Console.Clear(); return new BlogManager(this, CONNECTION_STRING);
                case "3": Console.Clear(); return new AuthorManager(this, CONNECTION_STRING);
                case "4": Console.Clear(); return new PostManager(this, CONNECTION_STRING);
                case "5": Console.Clear(); return new TagManager(this, CONNECTION_STRING);
                case "6": Console.Clear(); return new SearchManager(this, CONNECTION_STRING);
                case "0":
                    Console.WriteLine("Good bye");
                    return null;
                case "*": Console.Clear(); return new ColorManager(this);
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
