using DomainLayer.Entities;
using Newtonsoft.Json;
using RepositoryLayer.Repositories.Interfaces;


namespace RepositoryLayer.Repositories
{
    public class BlogRepository : IRepository<Blog>
    {
        private readonly string _filePath = "blogs.json";

        public BlogRepository()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public void Create(Blog entity)
        {
            if (entity == null) throw new ArgumentNullException();

            var blogs = GetAll();
            blogs.Add(entity);
            SaveToFile(blogs);
        }

        public void Delete(Blog entity)
        {
            throw new NotImplementedException();
        }

        public Blog Get(Predicate<Blog> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll(Predicate<Blog> predicate = null)
        {
            var blogs = JsonConvert.DeserializeObject<List<Blog>>(File.ReadAllText(_filePath));
            return predicate == null ? blogs : blogs.FindAll(predicate);
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }


        private void SaveToFile(List<Blog> blogs)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(blogs, Formatting.Indented));
        }
    }
}
