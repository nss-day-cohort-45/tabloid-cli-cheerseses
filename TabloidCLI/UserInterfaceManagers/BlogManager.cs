using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.UserInterfaceManagers
{
    public class BlogManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private BlogRepository _blogRepository;
        private string _connectionString;

        public BlogManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _blogRepository = new BlogRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Blog Menu");
            Console.WriteLine(" 1) List Blogs");
            Console.WriteLine(" 2) Add Blog");
            Console.WriteLine(" 3) Edit Blog");
            Console.WriteLine(" 4) Remove Blog");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
        }
    }
}
