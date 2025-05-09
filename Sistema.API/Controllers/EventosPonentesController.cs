using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.model;

namespace Sistema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosPonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventosPonentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventosPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoPonente>>> GetEventoPonente()
        {
            var data = await _context.EventosPonentes
                .Include(e => e.Eventos)
                .Include(e => e.Ponentes)
                .ToListAsync();
            return data;
        }

        // GET: api/EventosPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoPonente>> GetEventoPonente(int id)
        {
            var eventoPonente = await _context.EventosPonentes.FindAsync(id);

            if (eventoPonente == null)
            {
                return NotFound();
            }

            return eventoPonente;
        }

        // PUT: api/EventosPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoPonente(int id, EventoPonente eventoPonente)
        {
            if (id != eventoPonente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(eventoPonente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoPonenteExists(id))
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

        // POST: api/EventosPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoPonente>> PostEventoPonente(EventoPonente eventoPonente)
        {
            _context.EventosPonentes.Add(eventoPonente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoPonente", new { id = eventoPonente.Codigo }, eventoPonente);
        }

        // DELETE: api/EventosPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoPonente(int id)
        {
            var eventoPonente = await _context.EventosPonentes.FindAsync(id);
            if (eventoPonente == null)
            {
                return NotFound();
            }

            _context.EventosPonentes.Remove(eventoPonente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoPonenteExists(int id)
        {
            return _context.EventosPonentes.Any(e => e.Codigo == id);
        }
    }
}
