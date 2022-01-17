using Konatsu.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface IUserService : IDisposable
    {
        void AddUser(string username);
        Task<PersonEntity> GetUser(int id);
        void DeleteUser(PersonEntity user);
    }
}