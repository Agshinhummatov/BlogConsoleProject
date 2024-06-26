using DomainLayer.Entities;
using Newtonsoft.Json;
using RepositoryLayer.Repositories.Interfaces;


namespace RepositoryLayer.Repositories
{
    public class BlogRepository : IRepository<Blog>
    {
        private readonly string _filePath = "blogs.json";
        private List<Blog> _blogs;

        public BlogRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }

            string jsonData = File.ReadAllText(_filePath);
            _blogs = JsonConvert.DeserializeObject<List<Blog>>(jsonData);
        }

        public Blog GetById(int id)
        {
            return _blogs.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogs;
        }

        public IEnumerable<Blog> Find(Func<Blog, bool> predicate)
        {
            return _blogs.Where(predicate);
        }

        public void Add(Blog entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = _blogs.Count > 0 ? _blogs.Max(b => b.Id) + 1 : 1;
            _blogs.Add(entity);
            SaveChanges();
        }

        public void Update(Blog entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingBlog = GetById(entity.Id);
            if (existingBlog != null)
            {
                existingBlog.Title = entity.Title;
                existingBlog.Content = entity.Content;
                existingBlog.Author = entity.Author;
                existingBlog.Tags = entity.Tags;
                SaveChanges();
            }
        }

        public void Remove(Blog entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _blogs.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            string jsonData = JsonConvert.SerializeObject(_blogs, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
