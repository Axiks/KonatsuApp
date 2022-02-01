using Konatsu.API.Entities;
using Konatsu.API.Interfaces;
using Konatsu.API.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace Konatsu.API.Services
{
    public class HabitService : IHabitService
    {
        private readonly IEfRepository<HabitEntity> _habitRepository;

        public HabitService(IEfRepository<HabitEntity> habitRepository, IEfRepository<UserEntity> userRepository)
        {
            _habitRepository = habitRepository;
        }

        public async Task<Guid> Create(HabitEntity habitEntity)
        {
            var addHabit = await _habitRepository.Add(habitEntity);
            await _habitRepository.SaveChangesAsync();
            
            return addHabit;
        }

        public async Task Remove(HabitEntity habitEntity)
        {
            await _habitRepository.Remove(habitEntity);
            await _habitRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _habitRepository.Delete<HabitEntity>(id);
            await _habitRepository.SaveChangesAsync();
        }

        public IQueryable<HabitEntity> GetAll()
        {
            return _habitRepository.GetAll();
        }

        public HabitEntity GetById(Guid id)
        {
            return _habitRepository.GetById(id);
        }

        public async Task Update(HabitEntity habitEntity)
        {
            // habitEntity.DateUpdated = DateTime.Now;

            await _habitRepository.Update(habitEntity);
            await _habitRepository.SaveChangesAsync();
        }
    }
}
