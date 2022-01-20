using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public class UserRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(long id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == ToGuid(id));

            if (result == null)
            {
                //todo: need to add logger
                return null;
            }

            return result;
        }

        public async Task<long> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return ToLong(result.Entity.Id);
        }

        List<T> IEfRepository<T>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Task<long> IEfRepository<T>.Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        private static Guid ToGuid(long value)
        {
            byte[] guidData = new byte[16];
            Array.Copy(BitConverter.GetBytes(value), guidData, 8);
            return new Guid(guidData);
        }

        private static long ToLong(Guid guid)
        {
            if (BitConverter.ToInt64(guid.ToByteArray(), 8) != 0)
                throw new OverflowException("Value was either too large or too small for an Int64.");
            return BitConverter.ToInt64(guid.ToByteArray(), 0);
        }
    }
}
