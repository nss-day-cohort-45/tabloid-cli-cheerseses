using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private string _connectionString;

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Post Menu");
            Console.WriteLine(" 1) List Posts");
            Console.WriteLine(" 2) Add Post");
            Console.WriteLine(" 3) Edit Post");
            Console.WriteLine(" 4) Remove Post");
            Console.WriteLine(" 5) Note Management");
            Console.WriteLine(" 6) Post Details");
            Console.WriteLine(" 0) Return to Main Menu");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
                    //Edit();
                    return this;
                case "4":
                    Remove();
                    return this;
                case "5":
                   
                    return this;
                case "6":
                    Post post = Choose();
                    if (post == null)
                    {
                        return this;
                    }
                    else
                    {
                        return new PostDetailManager(this, _connectionString, post.Id);
                    }
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            List<Post> posts = _postRepository.GetAll();
            foreach (Post post in posts)
            {
                Console.WriteLine($"Title: {post.Title} - Url: {post.Url}");
            }
        }

        private Post Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a post:";
            }

            Console.WriteLine(prompt);

            List<Post> posts = _postRepository.GetAll();

            for (int i = 0; i < posts.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($" {i + 1}) {post.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return posts[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("New Post");
            Post post = new Post();

            Console.Write("Title: ");
            post.Title = Console.ReadLine();

            Console.Write("Url: ");
            post.Url = Console.ReadLine();

            Console.Write("Publish Date Time: ");
            post.PublishDateTime = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please Choose An Author:");
            List<Author> authors = _authorRepository.GetAll();

            foreach (Author a in authors)
            {
                Console.WriteLine($"{a.Id}) {a.FullName}");
            }
            Console.Write("> ");

            int choice = int.Parse(Console.ReadLine());
            Author author = authors[choice - 1];

            post.Author = author;


            List<Blog> blogs = _blogRepository.GetAll();
            foreach (Blog b in blogs)
            {
                Console.WriteLine($"{b.Id}) {b.Title}");
            }
            Console.Write("> ");

            int bChoice = int.Parse(Console.ReadLine());
            Blog blog = blogs[bChoice - 1];

            post.Blog = blog;

            _postRepository.Insert(post);
        }

        private void View()
        {
            Post postToView = Choose("Which post would you like to view?");
            if (postToView != null)
            {
                _postRepository.Get(postToView.Id);
            }

            Console.WriteLine($"Title: {postToView.Title} - Url: {postToView.Url}");
        }

        //    private void Edit()
        //    {
        //        Post postToEdit = Choose("Which author would you like to edit?");
        //        if (postToEdit == null)
        //        {
        //            return;
        //        }

        //        Console.WriteLine();
        //        Console.Write("New first name (blank to leave unchanged: ");
        //        string firstName = Console.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(firstName))
        //        {
        //            authorToEdit.FirstName = firstName;
        //        }
        //        Console.Write("New last name (blank to leave unchanged: ");
        //        string lastName = Console.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(lastName))
        //        {
        //            authorToEdit.LastName = lastName;
        //        }
        //        Console.Write("New bio (blank to leave unchanged: ");
        //        string bio = Console.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(bio))
        //        {
        //            authorToEdit.Bio = bio;
        //        }

        //        _authorRepository.Update(authorToEdit);
        //    }

        private void Remove()
        {
            Post postToDelete = Choose("Which post would you like to remove?");
            if (postToDelete != null)
            {
                _postRepository.Delete(postToDelete.Id);
            }
        }
    }
 }



