using DomainLayer.Entities;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Helpers;

namespace BlogApplication.Controllers
{
    
    public class BlogController
    {
        private readonly IBlogService _blogService;

        public BlogController()
        {
            _blogService = new BlogService();
        }


        public void Create()
        {
            ConsoleColor.DarkGreen.WriteConsole("Please add blog title:");
        BlogTitle: string blogTitle = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(blogTitle))
            {
                ConsoleColor.Red.WriteConsole("Please don't leave the blog title empty");
                goto BlogTitle;
            }

            ConsoleColor.DarkGreen.WriteConsole("Please add blog content:");
        BlogContent: string blogContent = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(blogContent))
            {
                ConsoleColor.Red.WriteConsole("Please don't leave the blog content empty");
                goto BlogContent;
            }

            ConsoleColor.DarkGreen.WriteConsole("Please add author name:");
        AuthorName: string authorName = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(authorName))
            {
                ConsoleColor.Red.WriteConsole("Please don't leave the author name empty");
                goto AuthorName;
            }

            try
            {
                Blog blog = new Blog
                {
                    Title = blogTitle,
                    Content = blogContent,
                    Author = new Author { Name = authorName }
                };

                var response = _blogService.Create(blog);

                ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Title: {response.Title}, Content: {response.Content}, Author: {response.Author.Name}");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + " Please try again");
                goto BlogTitle;
            }
        }

        public void GetAll()
        {
            var result = _blogService.GetAll();

            if (result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Title: {item.Title}, Content: {item.Content}, Author: {item.Author.Name}");
                }
            }
        }

    }
}
