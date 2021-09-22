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
    public class ProductLabelController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductLabelController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductLabel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLabel>>> GetProductLabel()
        {
            return await _context.ProductLabel.ToListAsync();
        }

        // GET: api/ProductLabel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductLabel>> GetProductLabel(int id)
        {
            var productLabel = await _context.ProductLabel.FindAsync(id);

            if (productLabel == null)
            {
                return NotFound();
            }

            return productLabel;
        }

        // PUT: api/ProductLabel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductLabel(int id, ProductLabel productLabel)
        {
            if (id != productLabel.Id)
            {
                return BadRequest();
            }

            _context.Entry(productLabel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductLabelExists(id))
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

        // POST: api/ProductLabel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductLabel>> PostProductLabel(ProductLabel productLabel)
        {
            _context.ProductLabel.Add(productLabel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductLabelExists(productLabel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductLabel", new { id = productLabel.Id }, productLabel);
        }

        // DELETE: api/ProductLabel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductLabel>> DeleteProductLabel(int id)
        {
            var productLabel = await _context.ProductLabel.FindAsync(id);
            if (productLabel == null)
            {
                return NotFound();
            }

            _context.ProductLabel.Remove(productLabel);
            await _context.SaveChangesAsync();

            return productLabel;
        }

        private bool ProductLabelExists(int id)
        {
            return _context.ProductLabel.Any(e => e.Id == id);
        }

        // GET: api/ProductLabel/5
        [Route("ProductLabelView")]
        [HttpGet]
        public async Task<IActionResult> GetProductLabelView(
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
Int32? brandId,
String productLabelName
      )
        {
          /*
           var result = from a in _context.ProductLabel
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
            
           var result = from e in _context.ProductLabel
                         join _brand in _context.Brand on e.BrandId equals _brand.BrandId into __brand
 from _brand in __brand.DefaultIfEmpty()
                        select new
                           {
                             productLabel={
                             e.Id,
e.BrandId,
e.ProductLabelName,
e.Version
                            },
                            brand = new {
_brand.Id,
_brand.BrandName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productLabel.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productLabel.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productLabel.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productLabel.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productLabel.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productLabel.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productLabel.Id== id);

                if (brandId!= null) 
 result = result.Where(r => r.productLabel.BrandId== brandId);

                if (productLabelName!= null) 
 result = result.Where(r => r.productLabel.ProductLabelName.StartsWith(productLabelName));

            return Ok(await result.ToListAsync());
        }

    }
}
