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
    public class ProductProcessorSalePriceController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductProcessorSalePriceController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductProcessorSalePrice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProcessorSalePrice>>> GetProductProcessorSalePrice()
        {
            return await _context.ProductProcessorSalePrice.ToListAsync();
        }

        // GET: api/ProductProcessorSalePrice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessorSalePrice>> GetProductProcessorSalePrice(int id)
        {
            var productProcessorSalePrice = await _context.ProductProcessorSalePrice.FindAsync(id);

            if (productProcessorSalePrice == null)
            {
                return NotFound();
            }

            return productProcessorSalePrice;
        }

        // PUT: api/ProductProcessorSalePrice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProcessorSalePrice(int id, ProductProcessorSalePrice productProcessorSalePrice)
        {
            if (id != productProcessorSalePrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(productProcessorSalePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductProcessorSalePriceExists(id))
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

        // POST: api/ProductProcessorSalePrice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessorSalePrice>> PostProductProcessorSalePrice(ProductProcessorSalePrice productProcessorSalePrice)
        {
            _context.ProductProcessorSalePrice.Add(productProcessorSalePrice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductProcessorSalePriceExists(productProcessorSalePrice.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductProcessorSalePrice", new { id = productProcessorSalePrice.Id }, productProcessorSalePrice);
        }

        // DELETE: api/ProductProcessorSalePrice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessorSalePrice>> DeleteProductProcessorSalePrice(int id)
        {
            var productProcessorSalePrice = await _context.ProductProcessorSalePrice.FindAsync(id);
            if (productProcessorSalePrice == null)
            {
                return NotFound();
            }

            _context.ProductProcessorSalePrice.Remove(productProcessorSalePrice);
            await _context.SaveChangesAsync();

            return productProcessorSalePrice;
        }

        private bool ProductProcessorSalePriceExists(int id)
        {
            return _context.ProductProcessorSalePrice.Any(e => e.Id == id);
        }

        // GET: api/ProductProcessorSalePrice/5
        [Route("ProductProcessorSalePriceView")]
        [HttpGet]
        public async Task<IActionResult> GetProductProcessorSalePriceView(
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
           var result = from a in _context.ProductProcessorSalePrice
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
            
           var result = from e in _context.ProductProcessorSalePrice
                         join _productProcessorDetail in _context.ProductProcessorDetail on e.ProductProcessorDetailId equals _productProcessorDetail.ProductProcessorDetailId into __productProcessorDetail
 from _productProcessorDetail in __productProcessorDetail.DefaultIfEmpty()
                        select new
                           {
                             productProcessorSalePrice={
                             e.Id,
e.ProductProcessorDetailId,
e.SalePrice,
e.SaleSchemaId,
e.Version
                            },
                            productProcessorDetail = new {
_productProcessorDetail.Id
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productProcessorSalePrice.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productProcessorSalePrice.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productProcessorSalePrice.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productProcessorSalePrice.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productProcessorSalePrice.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productProcessorSalePrice.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productProcessorSalePrice.Id== id);

            return Ok(await result.ToListAsync());
        }

    }
}
