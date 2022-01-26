using Konatsu.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        Task<Guid> Add<T>(T entity) where T : class, IEntity;
        Task Update<T>(T entity) where T : class, IEntity;
        Task Delete<T>(Guid id) where T : class, IEntity;
        Task Remove<T>(T entity) where T : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}
