using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IBlogService
    {
        Blog GetBlogById(int id);
        IEnumerable<Blog> GetAllBlogs();
        IEnumerable<Blog> FindBlogs(Func<Blog, bool> predicate);
        IEnumerable<Blog> SearchBlogs(string keyword);
        void CreateBlog(string title, string content, Author author, List<Tag> tags);
        void UpdateBlog(int id, string title, string content, Author author, List<Tag> tags);
        void DeleteBlog(int id);
    }
}
