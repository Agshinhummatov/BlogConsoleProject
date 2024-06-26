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
    public class AuthorRepository : IRepository<Author>
    {
        private readonly string _filePath = "authors.json";
        private List<Author> _authors;

        public AuthorRepository()
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
            _authors = JsonConvert.DeserializeObject<List<Author>>(jsonData);
        }

        public Author GetById(int id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors;
        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return _authors.Where(predicate);
        }

        public void Add(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = _authors.Count > 0 ? _authors.Max(a => a.Id) + 1 : 1;
            _authors.Add(entity);
            SaveChanges();
        }

        public void Update(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingAuthor = GetById(entity.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = entity.Name;

                SaveChanges();
            }
        }

        public void Remove(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _authors.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            string jsonData = JsonConvert.SerializeObject(_authors, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
