using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEventosUniversidad.Entidades;

namespace GestionEventosUniversidad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonenteEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PonenteEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PonenteEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PonenteEventos>>> GetPonenteEventos()
        {
            return await _context.PonenteEventos.ToListAsync();
        }

        // GET: api/PonenteEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PonenteEventos>> GetPonenteEventos(int id)
        {
            var ponenteEventos = await _context.PonenteEventos.FindAsync(id);

            if (ponenteEventos == null)
            {
                return NotFound();
            }

            return ponenteEventos;
        }

        // PUT: api/PonenteEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonenteEventos(int id, PonenteEventos ponenteEventos)
        {
            if (id != ponenteEventos.Id)
            {
                return BadRequest();
            }

            _context.Entry(ponenteEventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PonenteEventosExists(id))
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

        // POST: api/PonenteEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PonenteEventos>> PostPonenteEventos(PonenteEventos ponenteEventos)
        {
            _context.PonenteEventos.Add(ponenteEventos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPonenteEventos", new { id = ponenteEventos.Id }, ponenteEventos);
        }

        // DELETE: api/PonenteEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonenteEventos(int id)
        {
            var ponenteEventos = await _context.PonenteEventos.FindAsync(id);
            if (ponenteEventos == null)
            {
                return NotFound();
            }

            _context.PonenteEventos.Remove(ponenteEventos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PonenteEventosExists(int id)
        {
            return _context.PonenteEventos.Any(e => e.Id == id);
        }
    }
}
