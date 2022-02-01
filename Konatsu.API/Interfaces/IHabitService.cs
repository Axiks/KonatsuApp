using Konatsu.API.Entities;
using Konatsu.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface IHabitService
    {
        Task<Guid> Create(HabitEntity habitEntity);
        HabitEntity GetById(Guid id);
        Task Update(HabitEntity habitEntity);
        Task Delete(Guid id);
        Task Remove(HabitEntity habitEntity);
        IQueryable<HabitEntity> GetAll();
    }
}