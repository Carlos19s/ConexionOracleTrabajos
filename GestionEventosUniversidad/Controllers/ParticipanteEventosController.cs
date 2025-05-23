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
    public class ParticipanteEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipanteEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ParticipanteEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipanteEventos>>> GetParticipanteEventos()
        {
            return await _context.ParticipanteEventos.ToListAsync();
        }

        // GET: api/ParticipanteEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipanteEventos>> GetParticipanteEventos(int id)
        {
            var participanteEventos = await _context.ParticipanteEventos.FindAsync(id);

            if (participanteEventos == null)
            {
                return NotFound();
            }

            return participanteEventos;
        }

        // PUT: api/ParticipanteEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipanteEventos(int id, ParticipanteEventos participanteEventos)
        {
            if (id != participanteEventos.Id)
            {
                return BadRequest();
            }

            _context.Entry(participanteEventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteEventosExists(id))
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

        // POST: api/ParticipanteEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParticipanteEventos>> PostParticipanteEventos(ParticipanteEventos participanteEventos)
        {
            _context.ParticipanteEventos.Add(participanteEventos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipanteEventos", new { id = participanteEventos.Id }, participanteEventos);
        }

        // DELETE: api/ParticipanteEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipanteEventos(int id)
        {
            var participanteEventos = await _context.ParticipanteEventos.FindAsync(id);
            if (participanteEventos == null)
            {
                return NotFound();
            }

            _context.ParticipanteEventos.Remove(participanteEventos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipanteEventosExists(int id)
        {
            return _context.ParticipanteEventos.Any(e => e.Id == id);
        }
    }
}
