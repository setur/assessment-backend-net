using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeturDirectoryApp.Models;

namespace SeturDirectoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantactInformationsController : ControllerBase
    {
        private readonly mytestdbContext _context;

        public CantactInformationsController(mytestdbContext context)
        {
            _context = context;
        }

        // GET: api/CantactInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CantactInformation>>> GetCantactInformations()
        {
            return await _context.CantactInformations.ToListAsync();
        }

        // GET: api/CantactInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CantactInformation>> GetCantactInformation(int id)
        {
            var cantactInformation = await _context.CantactInformations.FindAsync(id);

            if (cantactInformation == null)
            {
                return NotFound();
            }

            return cantactInformation;
        }

        // PUT: api/CantactInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCantactInformation(int id, CantactInformation cantactInformation)
        {
            if (id != cantactInformation.CantactInformationId)
            {
                return BadRequest();
            }

            _context.Entry(cantactInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantactInformationExists(id))
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

        // POST: api/CantactInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CantactInformation>> PostCantactInformation(CantactInformation cantactInformation)
        {
            _context.CantactInformations.Add(cantactInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCantactInformation", new { id = cantactInformation.CantactInformationId }, cantactInformation);
        }

        // DELETE: api/CantactInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCantactInformation(int id)
        {
            var cantactInformation = await _context.CantactInformations.FindAsync(id);
            if (cantactInformation == null)
            {
                return NotFound();
            }

            _context.CantactInformations.Remove(cantactInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CantactInformationExists(int id)
        {
            return _context.CantactInformations.Any(e => e.CantactInformationId == id);
        }
    }
}
