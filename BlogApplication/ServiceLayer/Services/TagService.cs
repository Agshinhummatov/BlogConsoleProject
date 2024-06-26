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
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepository;

        public TagService()
        {
            _tagRepository = new TagRepository();
        }

        public Tag GetTagById(int id)
        {
            return _tagRepository.GetById(id);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _tagRepository.GetAll();
        }

        public Tag CreateTag(Tag tag)
        {
            ValidateTagInput(tag.Name);

            _tagRepository.Add(tag);
            return tag;
        }

        public void UpdateTag(int id, string name)
        {
            var existingTag = _tagRepository.GetById(id);
            if (existingTag == null)
            {
                throw new NotFoundException($"Tag with id {id} not found");
            }

            existingTag.Name = string.IsNullOrWhiteSpace(name) ? existingTag.Name : name.Trim();

            _tagRepository.Update(existingTag);
        }

        public void DeleteTag(int id)
        {
            var existingTag = _tagRepository.GetById(id);
            if (existingTag == null)
            {
                throw new NotFoundException($"Tag with id {id} not found");
            }

            _tagRepository.Remove(existingTag);
        }

        private void ValidateTagInput(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tag name cannot be empty", nameof(name));
        }
    }
}
