using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pipeline_GithubActions.Context;
using Pipeline_GithubActions.Entity;

namespace Pipeline_GithubActions.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var persons = await _context.Persons.ToListAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute] Guid id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            person.Id = Guid.NewGuid();
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Created($"/{person.Id}", person);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
                return NotFound();
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
