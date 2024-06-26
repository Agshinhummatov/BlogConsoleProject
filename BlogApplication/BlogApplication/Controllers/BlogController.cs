using DomainLayer.Entities;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Constants;

namespace BlogApplication.Controllers
{

    public class BlogController
    {
        private readonly IBlogService _blogService;
        private readonly IAuthorService _authorService;
        private readonly ITagService _tagService;

        public BlogController()
        {
            _blogService = new BlogService();
            _authorService = new AuthorService();
            _tagService = new TagService();
        }


        public void CreateBlog()
        {
            ConsoleHelper.WriteInfo(ResponseMessages.AddBlogTitle);
            string blogTitle = Console.ReadLine().Trim();

            ConsoleHelper.WriteInfo(ResponseMessages.AddBlogContent);
            string blogContent = Console.ReadLine().Trim();

            Author author = SelectOrCreateAuthor();

            List<Tag> tags = SelectOrCreateTags();

            try
            {
                _blogService.CreateBlog(blogTitle, blogContent, author, tags);
                ConsoleHelper.WriteSuccess(ResponseMessages.BlogCreated);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError($"{ex.Message}. {ResponseMessages.TryAgainMessage}");
            }
        }

        public void GetAllBlogs()
        {
            try
            {
                var blogs = _blogService.GetAllBlogs();

                if (blogs.Any())
                {
                    foreach (var blog in blogs)
                    {
                        DisplayBlogDetails(blog);
                    }
                }
                else
                {
                    ConsoleHelper.WriteWarning(ResponseMessages.NoBlogsFound);
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError($"{ex.Message}. {ResponseMessages.TryAgainMessage}");
            }
        }

        public void GetBlogById()
        {
            ConsoleHelper.WriteInfo(ResponseMessages.EnterBlogId);
            int id = GetValidId();

            try
            {
                var blog = _blogService.GetBlogById(id);

                if (blog != null)
                {
                    DisplayBlogDetails(blog);
                }
                else
                {
                    ConsoleHelper.WriteError(ResponseMessages.BlogNotFound);
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError($"{ex.Message}. {ResponseMessages.TryAgainMessage}");
            }
        }

        public void DeleteBlog()
        {
            ConsoleHelper.WriteInfo(ResponseMessages.SelectBlogToDelete);

            var blogs = _blogService.GetAllBlogs();

            if (blogs.Any())
            {
                foreach (var blog in blogs)
                {
                    ConsoleHelper.WriteSuccess($"Id: {blog.Id}, Title: {blog.Title}");
                }

                ConsoleHelper.WriteInfo(ResponseMessages.EnterBlogIdToDelete);
                int id = GetValidId();

                try
                {
                    _blogService.DeleteBlog(id);
                    ConsoleHelper.WriteSuccess(ResponseMessages.DeleteSuccessMessage);
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteError($"{ex.Message}. {ResponseMessages.TryAgainMessage}");
                }
            }
            else
            {
                ConsoleHelper.WriteWarning(ResponseMessages.NoBlogsAvailable);
            }
        }

        public void SearchBlog()
        {
            ConsoleHelper.WriteInfo(ResponseMessages.EnterSearchText);
            string searchText = Console.ReadLine().Trim();

            try
            {
                var result = _blogService.SearchBlogs(searchText);

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        DisplayBlogDetails(item);
                    }
                }
                else
                {
                    ConsoleHelper.WriteWarning(ResponseMessages.NoBlogsMatchingSearch);
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError($"{ex.Message}. {ResponseMessages.TryAgainMessage}");
            }
        }

        public void UpdateBlog()
        {
            var blogs = _blogService.GetAllBlogs();
            if (blogs == null || !blogs.Any())
            {
                ConsoleHelper.WriteWarning(ResponseMessages.NoBlogsToUpdate);
                return;
            }

            ConsoleHelper.WriteInfo(ResponseMessages.SelectBlogToUpdate);
            foreach (var blog in blogs)
            {
                ConsoleHelper.WriteInfo($"Id: {blog.Id}, Title: {blog.Title}");
            }

            ConsoleHelper.WriteInfo(ResponseMessages.EnterBlogIdToUpdate);
            if (!int.TryParse(Console.ReadLine(), out int blogId))
            {
                ConsoleHelper.WriteError(ResponseMessages.InvalidBlogIdFormat);
                return;
            }

            ConsoleHelper.WriteInfo(ResponseMessages.AddBlogTitleToUpdate);
            string title = Console.ReadLine();

            ConsoleHelper.WriteInfo(ResponseMessages.AddBlogContentToUpdate);
            string content = Console.ReadLine();

            Author selectedAuthor = SelectOrCreateAuthor();

            List<Tag> tags = SelectOrCreateTags();

            try
            {
                _blogService.UpdateBlog(blogId, title, content, selectedAuthor, tags);
                ConsoleHelper.WriteSuccess(ResponseMessages.BlogUpdated);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError($"{ex.Message}. {ResponseMessages.TryAgainMessage}");
            }
        }

        private int GetValidId()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id))
                {
                    return id;
                }
                else
                {
                    ConsoleHelper.WriteError(ResponseMessages.InvalidBlogIdFormat);
                }
            }
        }

        private Author SelectOrCreateAuthor()
        {
            ConsoleHelper.WriteInfo(ResponseMessages.SelectOrCreateAuthorToUpdate);
            var authors = _authorService.GetAllAuthors().ToList();

            if (authors.Any())
            {
                for (int i = 0; i < authors.Count; i++)
                {
                    ConsoleHelper.WriteSuccess($"{i + 1}. {authors[i].Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteWarning("No authors found. You can create new authors.");
            }

            while (true)
            {
                ConsoleHelper.WriteInfo(ResponseMessages.SelectOrCreateAuthorChoice);
                string authorInput = Console.ReadLine().Trim();

                if (authorInput.ToLower() == "create")
                {
                    ConsoleHelper.WriteInfo(ResponseMessages.EnterNewAuthorName);
                    string authorName = Console.ReadLine().Trim();

                    Author newAuthor = new Author { Name = authorName };
                    try
                    {
                        return _authorService.CreateAuthor(newAuthor);
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.WriteError($"Error creating author: {ex.Message}. {ResponseMessages.TryAgainMessage}");
                    }
                }
                else
                {
                    if (int.TryParse(authorInput, out int authorIndex) && authorIndex > 0 && authorIndex <= authors.Count)
                    {
                        return authors[authorIndex - 1];
                    }
                    else
                    {
                        ConsoleHelper.WriteError(ResponseMessages.InvalidAuthorSelection);
                    }
                }
            }
        }

        private List<Tag> SelectOrCreateTags()
        {
            List<Tag> selectedTags = new List<Tag>();

            ConsoleHelper.WriteInfo(ResponseMessages.SelectOrCreateTagsToUpdate);
            var tags = _tagService.GetAllTags().ToList();

            if (tags.Any())
            {
                for (int i = 0; i < tags.Count; i++)
                {
                    ConsoleHelper.WriteSuccess($"{i + 1}. {tags[i].Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteWarning("No tags found. You can create new tags.");
            }

            while (true)
            {
                ConsoleHelper.WriteInfo(ResponseMessages.SelectOrCreateTagChoiceToUpdate);
                string tagInput = Console.ReadLine().Trim();

                if (tagInput.ToLower() == "done")
                {
                    break;
                }
                else if (tagInput.ToLower() == "create")
                {
                    ConsoleHelper.WriteInfo(ResponseMessages.EnterNewTagName);
                    string tagName = Console.ReadLine().Trim();

                    if (string.IsNullOrWhiteSpace(tagName))
                    {
                        ConsoleHelper.WriteError(ResponseMessages.TagNameEmpty);
                        continue;
                    }

                    Tag newTag = new Tag { Name = tagName };
                    try
                    {
                        Tag createdTag = _tagService.CreateTag(newTag);
                        selectedTags.Add(createdTag);
                        ConsoleHelper.WriteSuccess($"Tag '{createdTag.Name}' {ResponseMessages.SuccessMessage}");
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.WriteError($"Error creating tag: {ex.Message}. {ResponseMessages.TryAgainMessage}");
                    }
                }
                else
                {
                    if (int.TryParse(tagInput, out int tagIndex) && tagIndex > 0 && tagIndex <= tags.Count)
                    {
                        selectedTags.Add(tags[tagIndex - 1]);
                        ConsoleHelper.WriteSuccess($"Tag '{tags[tagIndex - 1].Name}' {ResponseMessages.SuccessMessage}");
                    }
                    else
                    {
                        ConsoleHelper.WriteError(ResponseMessages.InvalidTagSelection);
                    }
                }
            }

            return selectedTags;
        }

        private void DisplayBlogDetails(Blog blog)
        {
            ConsoleHelper.WriteSuccess($"Id: {blog.Id}, Title: {blog.Title}, Content: {blog.Content}, Author: {blog.Author.Name}, Tags: {string.Join(", ", blog.Tags.Select(t => t.Name))}");
        }
    }
}
