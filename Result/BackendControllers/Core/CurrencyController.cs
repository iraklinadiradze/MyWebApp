using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public CurrencyController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Currency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrency()
        {
            return await _context.Currency.ToListAsync();
        }

        // GET: api/Currency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var currency = await _context.Currency.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return currency;
        }

        // PUT: api/Currency/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int id, Currency currency)
        {
            if (id != currency.Id)
            {
                return BadRequest();
            }

            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currency
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
            _context.Currency.Add(currency);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CurrencyExists(currency.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCurrency", new { id = currency.Id }, currency);
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Currency>> DeleteCurrency(int id)
        {
            var currency = await _context.Currency.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _context.Currency.Remove(currency);
            await _context.SaveChangesAsync();

            return currency;
        }

        private bool CurrencyExists(int id)
        {
            return _context.Currency.Any(e => e.Id == id);
        }

        // GET: api/Currency/5
        [Route("CurrencyView")]
        [HttpGet]
        public async Task<IActionResult> GetCurrencyView(
        /*
            int? id ,
            int? topRecords ,
            string firstName,
            string lastName,
            string pid,
            DateTime? bodFrom ,
            DateTime? bodTo ,
            int? clientTypeID
       */
Int32? id,
String currencyCode
      )
        {
          /*
           var result = from a in _context.Currency
                        join b in _context.ClienType on a.ClientTypeId equals b.Id into c
                        from b in c.DefaultIfEmpty()
                        select new
                           {
                               client = new 
                               {
                                   a.Id,
                                   a.FirstName,
                                   a.LastName,
                                   a.Mobile,
                                   a.PersonalId,
                                   a.BirthDate,
                                   a.Address,
                                   a.ClientTypeId
                               },
                               clientType = new {
                                                 b.Id, 
                                                 b.ClientTypeName
                                                }
                           };
            */
            
           var result = from e in _context.Currency
                        
                        select new
                           {
                             currency={
                             e.Id,
e.CurrencyCode,
e.CurrencyDescrip,
e.Version
                            },
                            
                           }
            /*
            if (id != null)
                result = result.Where(r => r.currency.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.currency.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.currency.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.currency.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.currency.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.currency.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.currency.Id== id);

                if (currencyCode!= null) 
 result = result.Where(r => r.currency.CurrencyCode== currencyCode);

            return Ok(await result.ToListAsync());
        }

    }
}
