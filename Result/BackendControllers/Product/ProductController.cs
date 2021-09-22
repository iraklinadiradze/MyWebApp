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
    public class ProductController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        // GET: api/Product/5
        [Route("ProductView")]
        [HttpGet]
        public async Task<IActionResult> GetProductView(
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
String productCode,
Int32? productGroupId,
Int32? productLabelId,
String productName,
Int32? productUnitId
      )
        {
          /*
           var result = from a in _context.Product
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
            
           var result = from e in _context.Product
                         join _productGroup in _context.ProductGroup on e.ProductGroupId equals _productGroup.ProductGroupId into __productGroup
 from _productGroup in __productGroup.DefaultIfEmpty(),
 join _productLabel in _context.ProductLabel on e.ProductLabelId equals _productLabel.ProductLabelId into __productLabel
 from _productLabel in __productLabel.DefaultIfEmpty(),
 join _productUnit in _context.ProductUnit on e.ProductUnitId equals _productUnit.ProductUnitId into __productUnit
 from _productUnit in __productUnit.DefaultIfEmpty()
                        select new
                           {
                             product={
                             e.Id,
e.IsSingle,
e.IsTangible,
e.IsWholeQuantity,
e.ProductCode,
e.ProductGroupId,
e.ProductLabelId,
e.ProductName,
e.ProductUnitId,
e.Version
                            },
                            productGroup = new {
_productGroup.Id
},
productLabel = new {
_productLabel.Id,
_productLabel.ProductLabelName
},
productUnit = new {
_productUnit.Id,
_productUnit.ProductUnitName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.product.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.product.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.product.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.product.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.product.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.product.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.product.Id== id);

                if (productCode!= null) 
 result = result.Where(r => r.product.ProductCode== productCode);

                if (productGroupId!= null) 
 result = result.Where(r => r.product.ProductGroupId== productGroupId);

                if (productLabelId!= null) 
 result = result.Where(r => r.product.ProductLabelId== productLabelId);

                if (productName!= null) 
 result = result.Where(r => r.product.ProductName.StartsWith(productName));

                if (productUnitId!= null) 
 result = result.Where(r => r.product.ProductUnitId== productUnitId);

            return Ok(await result.ToListAsync());
        }

    }
}
