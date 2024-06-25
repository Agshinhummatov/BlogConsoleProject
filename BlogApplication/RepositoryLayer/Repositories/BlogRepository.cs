using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;


namespace RepositoryLayer.Repositories
{
    public class BlogRepository : IRepository<Blog>
    {
        public void Create(Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog entity)
        {
            throw new NotImplementedException();
        }

        public Blog Get(Predicate<Blog> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll(Predicate<Blog> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
