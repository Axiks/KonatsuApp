using Konatsu.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(Guid id);
        Task<Guid> Add(T entity);
    }
}
