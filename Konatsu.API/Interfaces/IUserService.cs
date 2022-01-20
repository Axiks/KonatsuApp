using Konatsu.API;
using Konatsu.API.Models;
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
        Task<UserEntity> GetUser(int id);
        void DeleteUser(UserEntity user);

        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(UserModel userModel);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id);
    }
}