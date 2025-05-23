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
    public class EventosUniversidadsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventosUniversidadsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventosUniversidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventosUniversidad>>> GetEventosUniversidad()
        {
            return await _context.EventosUniversidad.ToListAsync();
        }

        // GET: api/EventosUniversidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventosUniversidad>> GetEventosUniversidad(int id)
        {
            var eventosUniversidad = await _context.EventosUniversidad.FindAsync(id);

            if (eventosUniversidad == null)
            {
                return NotFound();
            }

            return eventosUniversidad;
        }

        // PUT: api/EventosUniversidads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventosUniversidad(int id, EventosUniversidad eventosUniversidad)
        {
            if (id != eventosUniversidad.IdEvento)
            {
                return BadRequest();
            }

            _context.Entry(eventosUniversidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventosUniversidadExists(id))
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

        // POST: api/EventosUniversidads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventosUniversidad>> PostEventosUniversidad(EventosUniversidad eventosUniversidad)
        {
            _context.EventosUniversidad.Add(eventosUniversidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventosUniversidad", new { id = eventosUniversidad.IdEvento }, eventosUniversidad);
        }

        // DELETE: api/EventosUniversidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventosUniversidad(int id)
        {
            var eventosUniversidad = await _context.EventosUniversidad.FindAsync(id);
            if (eventosUniversidad == null)
            {
                return NotFound();
            }

            _context.EventosUniversidad.Remove(eventosUniversidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventosUniversidadExists(int id)
        {
            return _context.EventosUniversidad.Any(e => e.IdEvento == id);
        }
    }
}
