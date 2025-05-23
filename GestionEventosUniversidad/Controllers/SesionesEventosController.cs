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
    public class SesionesEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SesionesEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SesionesEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SesionesEventos>>> GetSesionesEventos()
        {
            return await _context.SesionesEventos.ToListAsync();
        }

        // GET: api/SesionesEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SesionesEventos>> GetSesionesEventos(int id)
        {
            var sesionesEventos = await _context.SesionesEventos.FindAsync(id);

            if (sesionesEventos == null)
            {
                return NotFound();
            }

            return sesionesEventos;
        }

        // PUT: api/SesionesEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesionesEventos(int id, SesionesEventos sesionesEventos)
        {
            if (id != sesionesEventos.Id)
            {
                return BadRequest();
            }

            _context.Entry(sesionesEventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SesionesEventosExists(id))
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

        // POST: api/SesionesEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SesionesEventos>> PostSesionesEventos(SesionesEventos sesionesEventos)
        {
            _context.SesionesEventos.Add(sesionesEventos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSesionesEventos", new { id = sesionesEventos.Id }, sesionesEventos);
        }

        // DELETE: api/SesionesEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesionesEventos(int id)
        {
            var sesionesEventos = await _context.SesionesEventos.FindAsync(id);
            if (sesionesEventos == null)
            {
                return NotFound();
            }

            _context.SesionesEventos.Remove(sesionesEventos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SesionesEventosExists(int id)
        {
            return _context.SesionesEventos.Any(e => e.Id == id);
        }
    }
}
