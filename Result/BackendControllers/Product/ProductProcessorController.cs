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
    public class ProductProcessorController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductProcessorController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductProcessor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProcessor>>> GetProductProcessor()
        {
            return await _context.ProductProcessor.ToListAsync();
        }

        // GET: api/ProductProcessor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessor>> GetProductProcessor(int id)
        {
            var productProcessor = await _context.ProductProcessor.FindAsync(id);

            if (productProcessor == null)
            {
                return NotFound();
            }

            return productProcessor;
        }

        // PUT: api/ProductProcessor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProcessor(int id, ProductProcessor productProcessor)
        {
            if (id != productProcessor.Id)
            {
                return BadRequest();
            }

            _context.Entry(productProcessor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductProcessorExists(id))
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

        // POST: api/ProductProcessor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessor>> PostProductProcessor(ProductProcessor productProcessor)
        {
            _context.ProductProcessor.Add(productProcessor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductProcessorExists(productProcessor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductProcessor", new { id = productProcessor.Id }, productProcessor);
        }

        // DELETE: api/ProductProcessor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessor>> DeleteProductProcessor(int id)
        {
            var productProcessor = await _context.ProductProcessor.FindAsync(id);
            if (productProcessor == null)
            {
                return NotFound();
            }

            _context.ProductProcessor.Remove(productProcessor);
            await _context.SaveChangesAsync();

            return productProcessor;
        }

        private bool ProductProcessorExists(int id)
        {
            return _context.ProductProcessor.Any(e => e.Id == id);
        }

        // GET: api/ProductProcessor/5
        [Route("ProductProcessorView")]
        [HttpGet]
        public async Task<IActionResult> GetProductProcessorView(
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
           var result = from a in _context.ProductProcessor
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
            
           var result = from e in _context.ProductProcessor
                        
                        select new
                           {
                             productProcessor={
                             e.Id,
e.IdentifyProducts,
e.IdentifyProductsAfterRegistration,
e.PurchaseId,
e.RegisterBrandProps,
e.RegisterProducts,
e.RegisterPurchaseDetails,
e.RegisterSalesPrices,
e.Version
                            },
                            
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productProcessor.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productProcessor.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productProcessor.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productProcessor.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productProcessor.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productProcessor.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productProcessor.Id== id);

            return Ok(await result.ToListAsync());
        }

    }
}
