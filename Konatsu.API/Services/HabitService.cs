using Konatsu.API.Entities;
using Konatsu.API.Interfaces;
using Konatsu.API.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.Threading.Tasks;

namespace Konatsu.API.Services
{
    public class HabitService : IHabitService
    {
        private readonly IEfRepository<HabitEntity> _habitRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public HabitService(IEfRepository<HabitEntity> habitRepository, IConfiguration configuration, IMapper mapper)
        {
            _habitRepository = habitRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Guid> Create(HabitEntity habitEntity)
        {
            var addHabit = await _habitRepository.Add(habitEntity);
            return addHabit;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ForceDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<HabitEntity> GetAll()
        {
            return _habitRepository.GetAll();
        }

        public HabitEntity GetById(Guid id)
        {
            return _habitRepository.GetById(id);
        }
    }
}
