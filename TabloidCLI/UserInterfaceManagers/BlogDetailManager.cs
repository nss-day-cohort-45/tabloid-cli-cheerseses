using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class BlogDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private TagRepository _tagRepository;
        private int _blogId;

        public BlogDetailManager(IUserInterfaceManager parentUI, string connectionString, int blogId)
        {
            _parentUI = parentUI;
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _blogId = blogId;
        }

        public IUserInterfaceManager Execute()
        {
            Blog blog = _blogRepository.Get(_blogId);
            Console.WriteLine($"\"{blog.Title}\" details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Remove Tag");
            Console.WriteLine(" 4) View Posts");
            Console.WriteLine(" 0) Return");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;
                case "2":
                    //AddTag();
                    return this;
                case "3":
                    //RemoveTag();
                    return this;
                case "4":
                    //Add View Posts method here
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void View()
        {
            Blog blog = _blogRepository.Get(_blogId);
            Console.WriteLine($"Title: {blog.Title}");
            Console.WriteLine($"Url: {blog.Url}");
            Console.WriteLine();
        }

        private void ViewPosts()
        {
            List<Post> posts = _postRepository.GetByAuthor(_authorId);
            foreach (Post post in posts)
            {
                Console.WriteLine($"{post.Blog.Title} - {post.Blog.Url}");
            }
            Console.WriteLine("");

        }

        //private void AddTag()
        //{
        //    Post post = _postRepository.Get(_postId);

        //    Console.WriteLine($"Which tag would you like to add to {post.Title}?");
        //    List<Tag> tags = _tagRepository.GetAll();

        //    for (int i = 0; i < tags.Count; i++)
        //    {
        //        Tag tag = tags[i];
        //        Console.WriteLine($" {i + 1}) {tag.Name}");
        //    }
        //    Console.Write("> ");

        //    string input = Console.ReadLine();
        //    try
        //    {
        //        int choice = int.Parse(input);
        //        Tag tag = tags[choice - 1];
        //        _postRepository.InsertTag(post, tag);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Invalid Selection. Won't add any tags.");
        //    }
        //}

        //private void RemoveTag()
        //{
        //    Post post = _postRepository.Get(_postId);

        //    Console.WriteLine($"Which tag would you like to remove from {post.Title}?");
        //    List<Tag> tags = post.Tags;

        //    for (int i = 0; i < tags.Count; i++)
        //    {
        //        Tag tag = tags[i];
        //        Console.WriteLine($" {i + 1}) {tag.Name}");
        //    }
        //    Console.Write("> ");

        //    string input = Console.ReadLine();
        //    try
        //    {
        //        int choice = int.Parse(input);
        //        Tag tag = tags[choice - 1];
        //        _postRepository.DeleteTag(post.Id, tag.Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Invalid Selection. Won't remove any tags.");
        //    }
        //}
    }
}