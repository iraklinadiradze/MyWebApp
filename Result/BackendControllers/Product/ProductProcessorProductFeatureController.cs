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
    public class ProductProcessorProductFeatureController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductProcessorProductFeatureController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductProcessorProductFeature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProcessorProductFeature>>> GetProductProcessorProductFeature()
        {
            return await _context.ProductProcessorProductFeature.ToListAsync();
        }

        // GET: api/ProductProcessorProductFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessorProductFeature>> GetProductProcessorProductFeature(int id)
        {
            var productProcessorProductFeature = await _context.ProductProcessorProductFeature.FindAsync(id);

            if (productProcessorProductFeature == null)
            {
                return NotFound();
            }

            return productProcessorProductFeature;
        }

        // PUT: api/ProductProcessorProductFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProcessorProductFeature(int id, ProductProcessorProductFeature productProcessorProductFeature)
        {
            if (id != productProcessorProductFeature.Id)
            {
                return BadRequest();
            }

            _context.Entry(productProcessorProductFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductProcessorProductFeatureExists(id))
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

        // POST: api/ProductProcessorProductFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessorProductFeature>> PostProductProcessorProductFeature(ProductProcessorProductFeature productProcessorProductFeature)
        {
            _context.ProductProcessorProductFeature.Add(productProcessorProductFeature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductProcessorProductFeatureExists(productProcessorProductFeature.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductProcessorProductFeature", new { id = productProcessorProductFeature.Id }, productProcessorProductFeature);
        }

        // DELETE: api/ProductProcessorProductFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessorProductFeature>> DeleteProductProcessorProductFeature(int id)
        {
            var productProcessorProductFeature = await _context.ProductProcessorProductFeature.FindAsync(id);
            if (productProcessorProductFeature == null)
            {
                return NotFound();
            }

            _context.ProductProcessorProductFeature.Remove(productProcessorProductFeature);
            await _context.SaveChangesAsync();

            return productProcessorProductFeature;
        }

        private bool ProductProcessorProductFeatureExists(int id)
        {
            return _context.ProductProcessorProductFeature.Any(e => e.Id == id);
        }

        // GET: api/ProductProcessorProductFeature/5
        [Route("ProductProcessorProductFeatureView")]
        [HttpGet]
        public async Task<IActionResult> GetProductProcessorProductFeatureView(
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
Int32? id
      )
        {
          /*
           var result = from a in _context.ProductProcessorProductFeature
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
            
           var result = from e in _context.ProductProcessorProductFeature
                         join _productProcessorDetail in _context.ProductProcessorDetail on e.ProductProcessorDetailId equals _productProcessorDetail.ProductProcessorDetailId into __productProcessorDetail
 from _productProcessorDetail in __productProcessorDetail.DefaultIfEmpty()
                        select new
                           {
                             productProcessorProductFeature={
                             e.Id,
e.FeatureId,
e.FeatureName,
e.FeatureValue,
e.FeatureValueId,
e.FeatureValueIdDictionary,
e.ProductProcessorDetailId,
e.Version
                            },
                            productProcessorDetail = new {
_productProcessorDetail.Id
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productProcessorProductFeature.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productProcessorProductFeature.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productProcessorProductFeature.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productProcessorProductFeature.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productProcessorProductFeature.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productProcessorProductFeature.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productProcessorProductFeature.Id== id);

            return Ok(await result.ToListAsync());
        }

    }
}
