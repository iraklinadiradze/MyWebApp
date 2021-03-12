using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTypesController : ControllerBase
    {
        private readonly PilotDBContext _context;

        public ClientTypesController(PilotDBContext context)
        {
            _context = context;
        }

        // GET: api/ClientTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientType>>> GetClientType()
        {
            return await _context.ClientType.ToListAsync();
        }

        // GET: api/ClientTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientType>> GetClientType(int id)
        {
            var clientType = await _context.ClientType.FindAsync(id);

            if (clientType == null)
            {
                return NotFound();
            }

            return clientType;
        }

        // PUT: api/ClientTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientType(int id, ClientType clientType)
        {
            if (id != clientType.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientTypeExists(id))
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

        // POST: api/ClientTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientType>> PostClientType(ClientType clientType)
        {
            _context.ClientType.Add(clientType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientTypeExists(clientType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientType", new { id = clientType.Id }, clientType);
        }

        // DELETE: api/ClientTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientType>> DeleteClientType(int id)
        {
            var clientType = await _context.ClientType.FindAsync(id);
            if (clientType == null)
            {
                return NotFound();
            }

            _context.ClientType.Remove(clientType);
            await _context.SaveChangesAsync();

            return clientType;
        }

        private bool ClientTypeExists(int id)
        {
            return _context.ClientType.Any(e => e.Id == id);
        }
    }
}
