using Konatsu.API.Entities;
using Konatsu.API.Helpers;
using Konatsu.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Konatsu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IUserService _userService;
        public TagsController(ITagService tagService, IUserService userService)
        {
            _tagService = tagService;
            _userService = userService;
        }

        // GET: api/<TagsController>
        [HttpGet]
        public IActionResult Get()
        {
            var tags = _tagService.GetAll();
            return Ok(tags);
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var tag = _tagService.GetById(id);
            return Ok(tag);
        }

        // POST api/<TagsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post(TagEntity tagEntity)
        {
            tagEntity.UserCreated = _userService.AuthUser().Id;
            var tag = _tagService.Create(tagEntity);
            return Ok(tag.Result);
        }

        // PUT api/<TagsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TagEntity tagEntity)
        {
            if (id != tagEntity.Id)
            {
                return BadRequest("Employee ID mismatch");
            }

            TagEntity tag = _tagService.GetById(id);
            if(tag == null)
                return NotFound($"Employee with Id = {id} not found");

            tag.UserUpdated = _userService.AuthUser().Id;
            await _tagService.Update(tag);
            return Ok();
        }

        // DELETE api/<TagsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _tagService.Delete(id);
            return Ok();
        }
    }
}
