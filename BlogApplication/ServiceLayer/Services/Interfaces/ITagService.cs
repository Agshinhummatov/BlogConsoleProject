using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITagService
    {
        Tag GetTagById(int id);
        IEnumerable<Tag> GetAllTags();
        Tag CreateTag(Tag tag);
        void UpdateTag(int id, string name);
        void DeleteTag(int id);
    }
}
