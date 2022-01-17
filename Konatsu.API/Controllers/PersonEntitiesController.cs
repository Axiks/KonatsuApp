using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Konatsu.API;

namespace Konatsu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonEntity>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        // GET: api/PersonEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonEntity>> GetPersonEntity(Guid id)
        {
            var personEntity = await _context.Persons.FindAsync(id);

            if (personEntity == null)
            {
                return NotFound();
            }

            return personEntity;
        }

        // PUT: api/PersonEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonEntity(Guid id, PersonEntity personEntity)
        {
            if (id != personEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(personEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonEntity>> PostPersonEntity(PersonEntity personEntity)
        {
            _context.Persons.Add(personEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonEntity", new { id = personEntity.Id }, personEntity);
        }

        // DELETE: api/PersonEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonEntity(Guid id)
        {
            var personEntity = await _context.Persons.FindAsync(id);
            if (personEntity == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(personEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonEntityExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
