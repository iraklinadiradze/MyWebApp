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
    public class FeatureValueController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public FeatureValueController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/FeatureValue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeatureValue>>> GetFeatureValue()
        {
            return await _context.FeatureValue.ToListAsync();
        }

        // GET: api/FeatureValue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureValue>> GetFeatureValue(int id)
        {
            var featureValue = await _context.FeatureValue.FindAsync(id);

            if (featureValue == null)
            {
                return NotFound();
            }

            return featureValue;
        }

        // PUT: api/FeatureValue/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeatureValue(int id, FeatureValue featureValue)
        {
            if (id != featureValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(featureValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureValueExists(id))
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

        // POST: api/FeatureValue
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FeatureValue>> PostFeatureValue(FeatureValue featureValue)
        {
            _context.FeatureValue.Add(featureValue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeatureValueExists(featureValue.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFeatureValue", new { id = featureValue.Id }, featureValue);
        }

        // DELETE: api/FeatureValue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeatureValue>> DeleteFeatureValue(int id)
        {
            var featureValue = await _context.FeatureValue.FindAsync(id);
            if (featureValue == null)
            {
                return NotFound();
            }

            _context.FeatureValue.Remove(featureValue);
            await _context.SaveChangesAsync();

            return featureValue;
        }

        private bool FeatureValueExists(int id)
        {
            return _context.FeatureValue.Any(e => e.Id == id);
        }

        // GET: api/FeatureValue/5
        [Route("FeatureValueView")]
        [HttpGet]
        public async Task<IActionResult> GetFeatureValueView(
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
Int32? featureId,
Int32? featureValueName
      )
        {
          /*
           var result = from a in _context.FeatureValue
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
            
           var result = from e in _context.FeatureValue
                         join _feature in _context.Feature on e.FeatureId equals _feature.FeatureId into __feature
 from _feature in __feature.DefaultIfEmpty()
                        select new
                           {
                             featureValue={
                             e.Id,
e.FeatureId,
e.FeatureValueName,
e.Version
                            },
                            feature = new {
_feature.Id,
_feature.FeatureName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.featureValue.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.featureValue.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.featureValue.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.featureValue.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.featureValue.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.featureValue.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.featureValue.Id== id);

                if (featureId!= null) 
 result = result.Where(r => r.featureValue.FeatureId== featureId);

                if (featureValueName!= null) 
 result = result.Where(r => r.featureValue.FeatureValueName.StartsWith(featureValueName));

            return Ok(await result.ToListAsync());
        }

    }
}
