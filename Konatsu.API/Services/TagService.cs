using Konatsu.API.Entities;
using Konatsu.API.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Konatsu.API.Services
{
    public class TagService : ITagService
    {
        private readonly IEfRepository<TagEntity> _tagRepository;
        public TagService(IEfRepository<TagEntity> tagRepository, IEfRepository<TagEntity> userRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<Guid> Create(TagEntity tagEntity)
        {
            var addTag = await _tagRepository.Add(tagEntity);
            await _tagRepository.SaveChangesAsync();

            return addTag;
        }

        public async Task Delete(Guid id)
        {
            await _tagRepository.Delete<TagEntity>(id);
            await _tagRepository.SaveChangesAsync();
        }

        public IQueryable<TagEntity> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public TagEntity GetById(Guid id)
        {
            return _tagRepository.GetById(id);
        }

        public async Task Remove(TagEntity tagEntity)
        {
            await _tagRepository.Remove(tagEntity);
            await _tagRepository.SaveChangesAsync();
        }

        public async Task Update(TagEntity tagEntity)
        {
            await _tagRepository.Update(tagEntity);
            await _tagRepository.SaveChangesAsync();
        }
    }
}
