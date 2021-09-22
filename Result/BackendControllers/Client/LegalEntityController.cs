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
    public class LegalEntityController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public LegalEntityController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/LegalEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalEntity>>> GetLegalEntity()
        {
            return await _context.LegalEntity.ToListAsync();
        }

        // GET: api/LegalEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalEntity>> GetLegalEntity(int id)
        {
            var legalEntity = await _context.LegalEntity.FindAsync(id);

            if (legalEntity == null)
            {
                return NotFound();
            }

            return legalEntity;
        }

        // PUT: api/LegalEntity/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalEntity(int id, LegalEntity legalEntity)
        {
            if (id != legalEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(legalEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalEntityExists(id))
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

        // POST: api/LegalEntity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LegalEntity>> PostLegalEntity(LegalEntity legalEntity)
        {
            _context.LegalEntity.Add(legalEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LegalEntityExists(legalEntity.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLegalEntity", new { id = legalEntity.Id }, legalEntity);
        }

        // DELETE: api/LegalEntity/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegalEntity>> DeleteLegalEntity(int id)
        {
            var legalEntity = await _context.LegalEntity.FindAsync(id);
            if (legalEntity == null)
            {
                return NotFound();
            }

            _context.LegalEntity.Remove(legalEntity);
            await _context.SaveChangesAsync();

            return legalEntity;
        }

        private bool LegalEntityExists(int id)
        {
            return _context.LegalEntity.Any(e => e.Id == id);
        }

        // GET: api/LegalEntity/5
        [Route("LegalEntityView")]
        [HttpGet]
        public async Task<IActionResult> GetLegalEntityView(
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
String legalEntityName,
Int32? registrationCountryID,
String taxCode
      )
        {
          /*
           var result = from a in _context.LegalEntity
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
            
           var result = from e in _context.LegalEntity
                         join _client in _context.Client on e.Id equals _client.Id into __client
 from _client in __client.DefaultIfEmpty(),
 join _country in _context.Country on e.RegistrationCountryID equals _country.RegistrationCountryID into __country
 from _country in __country.DefaultIfEmpty()
                        select new
                           {
                             legalEntity={
                             e.Id,
e.Email,
e.LegalAddress,
e.LegalEntityName,
e.Mobile,
e.OfficeAddress,
e.RegistrationCountryID,
e.TaxCode,
e.TaxRegDate,
e.Version
                            },
                            client = new {
_client.Id,
_client.Name
},
country = new {
_country.Id,
_country.Code,
_country.Name
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.legalEntity.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.legalEntity.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.legalEntity.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.legalEntity.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.legalEntity.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.legalEntity.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.legalEntity.Id== id);

                if (legalEntityName!= null) 
 result = result.Where(r => r.legalEntity.LegalEntityName.StartsWith(legalEntityName));

                if (registrationCountryID!= null) 
 result = result.Where(r => r.legalEntity.RegistrationCountryID== registrationCountryID);

                if (taxCode!= null) 
 result = result.Where(r => r.legalEntity.TaxCode== taxCode);

            return Ok(await result.ToListAsync());
        }

    }
}
