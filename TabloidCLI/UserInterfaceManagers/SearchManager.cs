using System;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class SearchManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private TagRepository _tagRepository;

        public SearchManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Search Menu");
            Console.WriteLine(" 1) Search Blogs");
            Console.WriteLine(" 2) Search Authors");
            Console.WriteLine(" 3) Search Posts");
            Console.WriteLine(" 4) Search All");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchBlogs();
                    ContinueRunning();
                    return this;
                case "2":
                    SearchAuthors();
                    ContinueRunning();
                    return this;
                case "3":
                    SearchPosts();
                    ContinueRunning();
                    return this;
                case "4":
                    SearchAll();
                    ContinueRunning();
                    return this;
                case "0":
                    Console.Clear();
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void SearchAuthors()
        {
            Console.Write("Tag> ");
            string tagName = Console.ReadLine();
            Console.WriteLine("");

            SearchResults<Author> results = _tagRepository.SearchAuthors(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchBlogs()
        {
            Console.Write("Tag> ");
            string tagName = Console.ReadLine();
            Console.WriteLine("");

            SearchResults<Blog> results = _tagRepository.SearchBlogs(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchPosts()
        {
            Console.Write("Tag> ");
            string tagName = Console.ReadLine();
            Console.WriteLine("");

            SearchResults<Post> results = _tagRepository.SearchPosts(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchAll()
        {
            Console.Write("Tag> ");
            string tagName = Console.ReadLine();
            Console.WriteLine("");

            SearchResults<Blog> resultsBlog = _tagRepository.SearchBlogs(tagName);
            SearchResults<Author> resultsAuthor = _tagRepository.SearchAuthors(tagName);
            SearchResults<Post> resultsPost = _tagRepository.SearchPosts(tagName);

            Console.WriteLine("Blogs");
            if (resultsBlog.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
                Console.WriteLine();
            }
            else
            {
                resultsBlog.Display();
            }

            Console.WriteLine("Authors");
            if (resultsAuthor.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
                Console.WriteLine();
            }
            else
            {
                resultsAuthor.Display();
            }

            Console.WriteLine("Posts");
            if (resultsPost.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
                Console.WriteLine();
            }
            else
            {
                resultsPost.Display();
            }
        }

        private void ContinueRunning()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}