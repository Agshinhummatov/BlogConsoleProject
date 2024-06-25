using DomainLayer.Entities;
using RepositoryLayer.Repositories;
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
        private readonly BlogRepository _repo;
        private int _count = 1;

        public BlogService()
        {
            _repo = new BlogRepository();
        }


        public Blog Create(Blog blog)
        {
            blog.Id = _count;
            _repo.Create(blog);
            _count++;
            return blog;
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            return _repo.GetAll();
        }

        public Blog GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Blog Update(int? id, Blog teacher)
        {
            throw new NotImplementedException();
        }
    }
}
