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
    public class FeatureController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public FeatureController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Feature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeature()
        {
            return await _context.Feature.ToListAsync();
        }

        // GET: api/Feature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
            var feature = await _context.Feature.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        // PUT: api/Feature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            _context.Entry(feature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
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

        // POST: api/Feature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
            _context.Feature.Add(feature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeatureExists(feature.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        // DELETE: api/Feature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feature>> DeleteFeature(int id)
        {
            var feature = await _context.Feature.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            _context.Feature.Remove(feature);
            await _context.SaveChangesAsync();

            return feature;
        }

        private bool FeatureExists(int id)
        {
            return _context.Feature.Any(e => e.Id == id);
        }

        // GET: api/Feature/5
        [Route("FeatureView")]
        [HttpGet]
        public async Task<IActionResult> GetFeatureView(
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
String featureName
      )
        {
          /*
           var result = from a in _context.Feature
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
            
           var result = from e in _context.Feature
                        
                        select new
                           {
                             feature={
                             e.Id,
e.FeatureName,
e.Version,
e.ts
                            },
                            
                           }
            /*
            if (id != null)
                result = result.Where(r => r.feature.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.feature.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.feature.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.feature.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.feature.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.feature.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.feature.Id== id);

                if (featureName!= null) 
 result = result.Where(r => r.feature.FeatureName.StartsWith(featureName));

            return Ok(await result.ToListAsync());
        }

    }
}
