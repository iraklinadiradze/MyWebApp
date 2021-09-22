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
    public class ProductUnitController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductUnitController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductUnit>>> GetProductUnit()
        {
            return await _context.ProductUnit.ToListAsync();
        }

        // GET: api/ProductUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductUnit>> GetProductUnit(int id)
        {
            var productUnit = await _context.ProductUnit.FindAsync(id);

            if (productUnit == null)
            {
                return NotFound();
            }

            return productUnit;
        }

        // PUT: api/ProductUnit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductUnit(int id, ProductUnit productUnit)
        {
            if (id != productUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(productUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductUnitExists(id))
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

        // POST: api/ProductUnit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductUnit>> PostProductUnit(ProductUnit productUnit)
        {
            _context.ProductUnit.Add(productUnit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductUnitExists(productUnit.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductUnit", new { id = productUnit.Id }, productUnit);
        }

        // DELETE: api/ProductUnit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductUnit>> DeleteProductUnit(int id)
        {
            var productUnit = await _context.ProductUnit.FindAsync(id);
            if (productUnit == null)
            {
                return NotFound();
            }

            _context.ProductUnit.Remove(productUnit);
            await _context.SaveChangesAsync();

            return productUnit;
        }

        private bool ProductUnitExists(int id)
        {
            return _context.ProductUnit.Any(e => e.Id == id);
        }

        // GET: api/ProductUnit/5
        [Route("ProductUnitView")]
        [HttpGet]
        public async Task<IActionResult> GetProductUnitView(
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
String productUnitName
      )
        {
          /*
           var result = from a in _context.ProductUnit
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
            
           var result = from e in _context.ProductUnit
                        
                        select new
                           {
                             productUnit={
                             e.Id,
e.ProductUnitName,
e.Version
                            },
                            
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productUnit.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productUnit.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productUnit.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productUnit.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productUnit.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productUnit.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productUnit.Id== id);

                if (productUnitName!= null) 
 result = result.Where(r => r.productUnit.ProductUnitName.StartsWith(productUnitName));

            return Ok(await result.ToListAsync());
        }

    }
}
