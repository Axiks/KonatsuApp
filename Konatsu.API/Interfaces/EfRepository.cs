using Konatsu.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public class EFRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public EFRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(Guid id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                //todo: need to add logger
                return null;
            }

            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Guid> Add<T>(T newEntity) where T : class, IEntity
        {
            newEntity.IsActive = true;
            var entity = await _context.Set<T>().AddAsync(newEntity);
            return entity.Entity.Id;
        }

        public async Task Delete<T>(Guid id) where T : class, IEntity
        {
            var item = GetById(id);
            item.IsActive = false;
            await Task.Run(() => _context.Update(item));
        }

        public async Task Remove<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async Task Update<T>(T entity) where T : class, IEntity
        {
            entity.DateUpdated = DateTime.Now;
            await Task.Run(() => _context.Set<T>().Update(entity));
        }
    }
}
