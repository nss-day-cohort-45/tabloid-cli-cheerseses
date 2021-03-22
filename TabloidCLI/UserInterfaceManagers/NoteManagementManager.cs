using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class NoteManagementManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private AuthorRepository _authorRepository;
        private PostRepository _postRepository;
        private NoteRepository _noteRepository;
        private TagRepository _tagRepository;
        private int _noteId;

        public NoteManagementManager(IUserInterfaceManager parentUI, string connectionString, int noteId)
        {
            _parentUI = parentUI;
            _authorRepository = new AuthorRepository(connectionString);
            _postRepository = new PostRepository(connectionString);
            _noteRepository = new NoteRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _noteId = noteId;
        }

        public IUserInterfaceManager Execute()
        {
            Note note = _noteRepository.Get(_noteId);
            Console.WriteLine(" 1) List Notes");
            Console.WriteLine(" 2) Add Note");
            Console.WriteLine(" 3) Remove Note");
            Console.WriteLine(" 0) Return");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ListNotes();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
                    //RemoveTag();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void ListNotes()
        {
            List<Note> notes = _noteRepository.GetAll();
            foreach (Note note in notes)
            {
                Console.WriteLine($"{note.Title} -- {note.Content} ({note.CreateDateTime})");
                
            }
            Console.WriteLine("");

        }

        private void Add()
        {
            Console.WriteLine("New Note");
            Note note = new Note();

            Console.Write("Title: ");
            note.Title = Console.ReadLine();

            Console.Write("Content: ");
            note.Content = Console.ReadLine();

            Console.Write("Creation Date and Time: ");
            note.CreateDateTime = Convert.ToDateTime((Console.ReadLine()));

            Console.Write("Related Posts: \n");
            List<Post> posts = _postRepository.GetAll();
            int count = 1;
            foreach (Post p in posts)
            {
                Console.WriteLine($"{count} - {p.Title}");
                count++;
            }

            int choice = int.Parse(Console.ReadLine());
            Post post = posts[choice - 1];

            note.Post = post;

            _noteRepository.Insert(note);
        }

        //private void View()
        //{
        //    Note note = _noteRepository.Get(_noteId);
        //    Console.WriteLine($"Title: {note.Title}");
        //    Console.WriteLine($"Content: {note.Content}");
        //    Console.WriteLine($"Date Note Created: {note.CreateDateTime}");
        //    Console.WriteLine();
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