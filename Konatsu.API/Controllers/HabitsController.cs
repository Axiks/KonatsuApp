using Konatsu.API.Entities;
using Konatsu.API.Helpers;
using Konatsu.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Konatsu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService _habitService;
        public HabitsController(IHabitService habitService)
        {
            _habitService = habitService;
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
            var habit = _habitService.Create(habitEntity);
            return Ok(habit.Result);
        }

        /*// PUT api/<HabitsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, HabitEntity habitEntity)
        {
            var habit = _habitService.GetById(id);
            _
        }*/

        [Authorize]
        // DELETE api/<HabitsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _habitService.Delete(id);
            return Ok();
        }
    }
}
