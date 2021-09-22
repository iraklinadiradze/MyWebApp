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
    public class ProductFeatureController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductFeatureController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductFeature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductFeature>>> GetProductFeature()
        {
            return await _context.ProductFeature.ToListAsync();
        }

        // GET: api/ProductFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductFeature>> GetProductFeature(int id)
        {
            var productFeature = await _context.ProductFeature.FindAsync(id);

            if (productFeature == null)
            {
                return NotFound();
            }

            return productFeature;
        }

        // PUT: api/ProductFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductFeature(int id, ProductFeature productFeature)
        {
            if (id != productFeature.Id)
            {
                return BadRequest();
            }

            _context.Entry(productFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductFeatureExists(id))
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

        // POST: api/ProductFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductFeature>> PostProductFeature(ProductFeature productFeature)
        {
            _context.ProductFeature.Add(productFeature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductFeatureExists(productFeature.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductFeature", new { id = productFeature.Id }, productFeature);
        }

        // DELETE: api/ProductFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductFeature>> DeleteProductFeature(int id)
        {
            var productFeature = await _context.ProductFeature.FindAsync(id);
            if (productFeature == null)
            {
                return NotFound();
            }

            _context.ProductFeature.Remove(productFeature);
            await _context.SaveChangesAsync();

            return productFeature;
        }

        private bool ProductFeatureExists(int id)
        {
            return _context.ProductFeature.Any(e => e.Id == id);
        }

        // GET: api/ProductFeature/5
        [Route("ProductFeatureView")]
        [HttpGet]
        public async Task<IActionResult> GetProductFeatureView(
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
Int32? featureValueId,
Int32? productId
      )
        {
          /*
           var result = from a in _context.ProductFeature
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
            
           var result = from e in _context.ProductFeature
                         join _featureValue in _context.FeatureValue on e.FeatureValueId equals _featureValue.FeatureValueId into __featureValue
 from _featureValue in __featureValue.DefaultIfEmpty(),
 join _product in _context.Product on e.ProductId equals _product.ProductId into __product
 from _product in __product.DefaultIfEmpty()
                        select new
                           {
                             productFeature={
                             e.Id,
e.FeatureValueId,
e.ProductId,
e.Version
                            },
                            featureValue = new {
_featureValue.Id,
_featureValue.FeatureValueName
},
product = new {
_product.Id,
_product.ProductName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productFeature.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productFeature.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productFeature.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productFeature.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productFeature.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productFeature.BirthDate >= (DateTime)bodTo);
            */

                            if (featureValueId!= null) 
 result = result.Where(r => r.productFeature.FeatureValueId== featureValueId);

                if (productId!= null) 
 result = result.Where(r => r.productFeature.ProductId== productId);

            return Ok(await result.ToListAsync());
        }

    }
}
