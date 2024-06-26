using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Author GetAuthorById(int id);
        IEnumerable<Author> GetAllAuthors();
        Author CreateAuthor(Author author);
        void UpdateAuthor(int id, string name);
        void DeleteAuthor(int id);
    }
}
