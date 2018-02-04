using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Consultants")]
    public class ConsultantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Consultants
        [HttpGet]
        public IEnumerable<Consultant> GetConsultants()
        {
            return _context.Consultants;
        }

        // GET: api/Consultants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultant = await _context.Consultants.SingleOrDefaultAsync(m => m.ID == id);

            if (consultant == null)
            {
                return NotFound();
            }

            return Ok(consultant);
        }

        // PUT: api/Consultants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultant([FromRoute] int id, [FromBody] Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultant.ID)
            {
                return BadRequest();
            }

            _context.Entry(consultant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
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

        // POST: api/Consultants
        [HttpPost]
        public async Task<IActionResult> PostConsultant([FromBody] Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Consultants.Add(consultant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultant", new { id = consultant.ID }, consultant);
        }

        // DELETE: api/Consultants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultant = await _context.Consultants.SingleOrDefaultAsync(m => m.ID == id);
            if (consultant == null)
            {
                return NotFound();
            }

            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();

            return Ok(consultant);
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultants.Any(e => e.ID == id);
        }
    }
}