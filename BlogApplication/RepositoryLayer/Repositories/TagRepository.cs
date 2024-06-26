using DomainLayer.Entities;
using Newtonsoft.Json;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly string _filePath = "tags.json";
        private List<Tag> _tags;

        public TagRepository()
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
            _tags = JsonConvert.DeserializeObject<List<Tag>>(jsonData);
        }

        public Tag GetById(int id)
        {
            return _tags.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tags;
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return _tags.Where(predicate);
        }

        public void Add(Tag entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = _tags.Count > 0 ? _tags.Max(t => t.Id) + 1 : 1;
            _tags.Add(entity);
            SaveChanges();
        }

        public void Update(Tag entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingTag = GetById(entity.Id);
            if (existingTag != null)
            {
                existingTag.Name = entity.Name;
                // Add other properties as needed
                SaveChanges();
            }
        }

        public void Remove(Tag entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _tags.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            string jsonData = JsonConvert.SerializeObject(_tags, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
