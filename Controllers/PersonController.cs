using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleBank.Data;
using SimpleBank.Models;

namespace SimpleBank.Controllers
{
    [ApiController]
    [Route("simpleBank/api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [Route("store")]
        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            person.birthday = DateTime.UtcNow;
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerson", new { id = person.personid }, person);
        }

        [Route("update/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.personid)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.personid == id);
        }
    }
}
