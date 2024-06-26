using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{

    public class BlogService : IBlogService
    {
        private readonly BlogRepository _blogRepository;

        public BlogService()
        {
            _blogRepository = new BlogRepository();
        }

        public Blog GetBlogById(int id)
        {
            return _blogRepository.GetById(id);
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _blogRepository.GetAll();
        }

        public IEnumerable<Blog> FindBlogs(Func<Blog, bool> predicate)
        {
            return _blogRepository.Find(predicate);
        }

        public void CreateBlog(string title, string content, Author author, List<Tag> tags)
        {
            ValidateBlogInput(title, content, author, tags);

            var blog = new Blog
            {
                Title = title.Trim(),
                Content = content.Trim(),
                Author = author,
                Tags = tags
            };

            _blogRepository.Add(blog);
        }

        public void UpdateBlog(int id, string title, string content, Author author, List<Tag> tags)
        {
            var existingBlog = _blogRepository.GetById(id);
            if (existingBlog == null)
            {
                throw new NotFoundException($"Blog with id {id} not found");
            }

            existingBlog.Title = string.IsNullOrWhiteSpace(title) ? existingBlog.Title : title.Trim();
            existingBlog.Content = string.IsNullOrWhiteSpace(content) ? existingBlog.Content : content.Trim();
            existingBlog.Author = author ?? existingBlog.Author;
            existingBlog.Tags = tags != null && tags.Any() ? tags : existingBlog.Tags;

            _blogRepository.Update(existingBlog);
        }



        public void DeleteBlog(int id)
        {
            var existingBlog = _blogRepository.GetById(id);
            if (existingBlog == null)
            {
                throw new NotFoundException($"Blog with id {id} not found");
            }

            _blogRepository.Remove(existingBlog);
        }

        public IEnumerable<Blog> SearchBlogs(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Keyword cannot be null or empty", nameof(keyword));


            Func<Blog, bool> predicate = b =>
                b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            return _blogRepository.Find(predicate);
        }


        private void ValidateBlogInput(string title, string content, Author author, List<Tag> tags)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Blog title cannot be empty", nameof(title));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Blog content cannot be empty", nameof(content));

            if (author == null)
                throw new ArgumentNullException(nameof(author));

            if (tags == null || !tags.Any())
                throw new ArgumentException("Blog must have at least one tag", nameof(tags));
        }


    }

}
