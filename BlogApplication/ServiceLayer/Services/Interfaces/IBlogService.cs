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

        Blog Create(Blog teacher);

        public void Delete(int? id);
        Blog GetById(int? id);
        List<Blog> Search(string searchText);

        List<Blog> GetAll();
        Blog Update(int? id, Blog teacher);

    }
}
