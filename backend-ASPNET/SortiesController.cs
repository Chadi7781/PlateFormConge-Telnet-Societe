using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Test.Entities;
using API_Test.Entities.Context;

namespace API_Test
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortiesController : ControllerBase
    {
        private readonly TelnetContext _context;

        public SortiesController(TelnetContext context)
        {
            _context = context;
        }

        // GET: api/Sorties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sortie>>> GetSorties()
        {
            return await _context.Sorties.ToListAsync();
        }

        // GET: api/Sorties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sortie>> GetSortie(int id)
        {
            var sortie = await _context.Sorties.FindAsync(id);

            if (sortie == null)
            {
                return NotFound();
            }

            return sortie;
        }

        // PUT: api/Sorties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSortie(int id, Sortie sortie)
        {
            if (id != sortie.Id)
            {
                return BadRequest();
            }

            _context.Entry(sortie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SortieExists(id))
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

        // POST: api/Sorties
        [HttpPost]
        public async Task<ActionResult<Sortie>> PostSortie(Sortie sortie)
        {
            _context.Sorties.Add(sortie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSortie", new { id = sortie.Id }, sortie);
        }
            
        // DELETE: api/Sorties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sortie>> DeleteSortie(int id)
        {
            var sortie = await _context.Sorties.FindAsync(id);
            if (sortie == null)
            {
                return NotFound();
            }

            _context.Sorties.Remove(sortie);
            await _context.SaveChangesAsync();

            return sortie;
        }

        private bool SortieExists(int id)
        {
            return _context.Sorties.Any(e => e.Id == id);
        }
    }
}