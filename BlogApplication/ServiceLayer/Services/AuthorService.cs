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
    public class AuthorService : IAuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService()
        {
            _authorRepository = new AuthorRepository();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author CreateAuthor(Author author)
        {
            ValidateAuthorInput(author.Name);

            _authorRepository.Add(author);
            return author;
        }

        public void UpdateAuthor(int id, string name)
        {
            var existingAuthor = _authorRepository.GetById(id);
            if (existingAuthor == null)
            {
                throw new NotFoundException($"Author with id {id} not found");
            }

            existingAuthor.Name = string.IsNullOrWhiteSpace(name) ? existingAuthor.Name : name.Trim();

            _authorRepository.Update(existingAuthor);
        }

        public void DeleteAuthor(int id)
        {
            var existingAuthor = _authorRepository.GetById(id);
            if (existingAuthor == null)
            {
                throw new NotFoundException($"Author with id {id} not found");
            }

            _authorRepository.Remove(existingAuthor);
        }

        private void ValidateAuthorInput(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Author name cannot be empty", nameof(name));
        }
    }

}
