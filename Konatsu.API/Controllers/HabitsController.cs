using Konatsu.API.Entities;
using Konatsu.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/<HabitsController>
        [HttpPost]
        public IActionResult Post(HabitEntity habitEntity)
        {
            _habitService.Create(habitEntity);
            return Ok();
        }

        // PUT api/<HabitsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HabitsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
