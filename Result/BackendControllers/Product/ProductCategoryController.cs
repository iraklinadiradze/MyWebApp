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
    public class ProductCategoryController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductCategoryController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategory()
        {
            return await _context.ProductCategory.ToListAsync();
        }

        // GET: api/ProductCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var productCategory = await _context.ProductCategory.FindAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return productCategory;
        }

        // PUT: api/ProductCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(productCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        // POST: api/ProductCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategory.Add(productCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductCategoryExists(productCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductCategory", new { id = productCategory.Id }, productCategory);
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategory.Remove(productCategory);
            await _context.SaveChangesAsync();

            return productCategory;
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategory.Any(e => e.Id == id);
        }

        // GET: api/ProductCategory/5
        [Route("ProductCategoryView")]
        [HttpGet]
        public async Task<IActionResult> GetProductCategoryView(
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
String productCategoryName
      )
        {
          /*
           var result = from a in _context.ProductCategory
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
            
           var result = from e in _context.ProductCategory
                        
                        select new
                           {
                             productCategory={
                             e.Id,
e.ProductCategoryName,
e.Version
                            },
                            
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productCategory.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productCategory.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productCategory.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productCategory.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productCategory.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productCategory.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productCategory.Id== id);

                if (productCategoryName!= null) 
 result = result.Where(r => r.productCategory.ProductCategoryName== productCategoryName);

            return Ok(await result.ToListAsync());
        }

    }
}
