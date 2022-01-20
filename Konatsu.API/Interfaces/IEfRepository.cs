using System.Collections.Generic;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);
    }
}
