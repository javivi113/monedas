using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monedas;
using monedas.Models;

namespace monedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        private readonly MonedaContext _context;

        public MonedasController(MonedaContext context)
        {
            _context = context;
        }

        // GET: api/Monedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monedas>>> GetMonedas()
        {
            var ran = new Random();
            foreach (var m in _context.Monedas)
            {
                // calcuylar valor
                m.ValorActual = (decimal)ran.NextDouble() * 100;
                // actualir moneda
                if (m.ValorMax < m.ValorActual)
                {
                    m.ValorMax = m.ValorActual;
                }
            }
            _context.SaveChanges();
            return await _context.Monedas.ToListAsync();
        }

        // GET: api/Monedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monedas>> GetMonedas(string id)
        {
            var monedas = await _context.Monedas.FindAsync(id);
            var ran = new Random();
            if (monedas == null)
            {
                return NotFound();
            }
            else
            {
                monedas.ValorActual = (decimal)ran.NextDouble() * 100;
                if (monedas.ValorMax < monedas.ValorActual)
                {
                    monedas.ValorMax = monedas.ValorActual;
                }
            }
            _context.SaveChanges();
            return monedas;
        }

        // PUT: api/Monedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonedas(string id, Monedas monedas)
        {
            if (id != monedas.moneda)
            {
                return BadRequest();
            }

            _context.Entry(monedas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonedasExists(id))
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

        // POST: api/Monedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Monedas>> PostMonedas(Monedas monedas)
        {
            _context.Monedas.Add(monedas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonedasExists(monedas.moneda))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMonedas", new { id = monedas.moneda }, monedas);
        }

        // DELETE: api/Monedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonedas(string id)
        {
            var monedas = await _context.Monedas.FindAsync(id);
            if (monedas == null)
            {
                return NotFound();
            }

            _context.Monedas.Remove(monedas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonedasExists(string id)
        {
            return _context.Monedas.Any(e => e.moneda == id);
        }
    }
}
