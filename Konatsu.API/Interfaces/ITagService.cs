using Konatsu.API.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface ITagService
    {
        Task<Guid> Create(TagEntity tagEntity);
        TagEntity GetById(Guid id);
        Task Update(TagEntity tagEntity);
        Task Delete(Guid id);
        Task Remove(TagEntity tagEntity);
        IQueryable<TagEntity> GetAll();
    }
}
