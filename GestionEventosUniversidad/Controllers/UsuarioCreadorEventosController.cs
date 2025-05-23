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
    public class UsuarioCreadorEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioCreadorEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioCreadorEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioCreadorEventos>>> GetUsuarioCreadorEventos()
        {
            return await _context.UsuarioCreadorEventos.ToListAsync();
        }

        // GET: api/UsuarioCreadorEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioCreadorEventos>> GetUsuarioCreadorEventos(int id)
        {
            var usuarioCreadorEventos = await _context.UsuarioCreadorEventos.FindAsync(id);

            if (usuarioCreadorEventos == null)
            {
                return NotFound();
            }

            return usuarioCreadorEventos;
        }

        // PUT: api/UsuarioCreadorEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioCreadorEventos(int id, UsuarioCreadorEventos usuarioCreadorEventos)
        {
            if (id != usuarioCreadorEventos.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioCreadorEventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioCreadorEventosExists(id))
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

        // POST: api/UsuarioCreadorEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioCreadorEventos>> PostUsuarioCreadorEventos(UsuarioCreadorEventos usuarioCreadorEventos)
        {
            _context.UsuarioCreadorEventos.Add(usuarioCreadorEventos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioCreadorEventos", new { id = usuarioCreadorEventos.Id }, usuarioCreadorEventos);
        }

        // DELETE: api/UsuarioCreadorEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioCreadorEventos(int id)
        {
            var usuarioCreadorEventos = await _context.UsuarioCreadorEventos.FindAsync(id);
            if (usuarioCreadorEventos == null)
            {
                return NotFound();
            }

            _context.UsuarioCreadorEventos.Remove(usuarioCreadorEventos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioCreadorEventosExists(int id)
        {
            return _context.UsuarioCreadorEventos.Any(e => e.Id == id);
        }
    }
}
