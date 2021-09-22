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
    public class CountryController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public CountryController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            return await _context.Country.ToListAsync();
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Country
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Country.Add(country);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountryExists(country.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        private bool CountryExists(int id)
        {
            return _context.Country.Any(e => e.Id == id);
        }

        // GET: api/Country/5
        [Route("CountryView")]
        [HttpGet]
        public async Task<IActionResult> GetCountryView(
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
String code,
String name
      )
        {
          /*
           var result = from a in _context.Country
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
            
           var result = from e in _context.Country
                        
                        select new
                           {
                             country={
                             e.Id,
e.Code,
e.Name,
e.Version
                            },
                            
                           }
            /*
            if (id != null)
                result = result.Where(r => r.country.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.country.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.country.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.country.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.country.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.country.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.country.Id== id);

                if (code!= null) 
 result = result.Where(r => r.country.Code== code);

                if (name!= null) 
 result = result.Where(r => r.country.Name.StartsWith(name));

            return Ok(await result.ToListAsync());
        }

    }
}
