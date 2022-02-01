using Konatsu.API.Entities;
using Konatsu.API.Helpers;
using Konatsu.API.Interfaces;
using Konatsu.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Konatsu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService _habitService;
        private readonly IUserService _userService;
        public HabitsController(IHabitService habitService, IUserService userService)
        {
            _habitService = habitService;
            _userService = userService;
        }
        // GET: api/<HabitsController>
        [HttpGet]
        public IActionResult Get()
        {
            var habits = _habitService.GetAll();
            return Ok(habits);
        }

        // GET api/<HabitsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var habit = _habitService.GetById(id);
            return Ok(habit);
        }

        // POST api/<HabitsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(HabitEntity habitEntity)
        {
            habitEntity.UserCreated = _userService.AuthUser().Id;
            var habit = _habitService.Create(habitEntity);
            return Ok(habit.Result);
        }

        // PUT api/<HabitsController>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, HabitRequest habitRequest)
        {
            // habitEntity.UserCreated = _userService.AuthUser().Id;
            var habit = _habitService.GetById(id);

            if (habit == null)
                return NotFound($"Employee with Id = {id} not found");

            habit.UserUpdated = _userService.AuthUser().Id;
            habit.Title = habitRequest.Title;
            habit.Description = habitRequest.Description;
            await _habitService.Update(habit);
            return Ok();
        }

        // DELETE api/<HabitsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _habitService.Delete(id);
            return Ok();
        }
    }
}
