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
    public class ProductGroupController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductGroupController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGroup>>> GetProductGroup()
        {
            return await _context.ProductGroup.ToListAsync();
        }

        // GET: api/ProductGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroup>> GetProductGroup(int id)
        {
            var productGroup = await _context.ProductGroup.FindAsync(id);

            if (productGroup == null)
            {
                return NotFound();
            }

            return productGroup;
        }

        // PUT: api/ProductGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductGroup(int id, ProductGroup productGroup)
        {
            if (id != productGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(productGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductGroupExists(id))
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

        // POST: api/ProductGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductGroup>> PostProductGroup(ProductGroup productGroup)
        {
            _context.ProductGroup.Add(productGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductGroupExists(productGroup.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductGroup", new { id = productGroup.Id }, productGroup);
        }

        // DELETE: api/ProductGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductGroup>> DeleteProductGroup(int id)
        {
            var productGroup = await _context.ProductGroup.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }

            _context.ProductGroup.Remove(productGroup);
            await _context.SaveChangesAsync();

            return productGroup;
        }

        private bool ProductGroupExists(int id)
        {
            return _context.ProductGroup.Any(e => e.Id == id);
        }

        // GET: api/ProductGroup/5
        [Route("ProductGroupView")]
        [HttpGet]
        public async Task<IActionResult> GetProductGroupView(
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
Int32? productCategoryId,
String productGroupName,
Int32? productGroupTemplateId
      )
        {
          /*
           var result = from a in _context.ProductGroup
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
            
           var result = from e in _context.ProductGroup
                         join _productCategory in _context.ProductCategory on e.ProductCategoryId equals _productCategory.ProductCategoryId into __productCategory
 from _productCategory in __productCategory.DefaultIfEmpty(),
 join _productGroupTemplate in _context.ProductGroupTemplate on e.ProductGroupTemplateId equals _productGroupTemplate.ProductGroupTemplateId into __productGroupTemplate
 from _productGroupTemplate in __productGroupTemplate.DefaultIfEmpty()
                        select new
                           {
                             productGroup={
                             e.Id,
e.ProductCategoryId,
e.ProductGroupName,
e.ProductGroupTemplateId,
e.Version
                            },
                            productCategory = new {
_productCategory.Id
},
productGroupTemplate = new {
_productGroupTemplate.Id,
_productGroupTemplate.ProductGroupTemplateName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productGroup.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productGroup.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productGroup.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productGroup.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productGroup.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productGroup.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productGroup.Id== id);

                if (productCategoryId!= null) 
 result = result.Where(r => r.productGroup.ProductCategoryId== productCategoryId);

                if (productGroupName!= null) 
 result = result.Where(r => r.productGroup.ProductGroupName== productGroupName);

                if (productGroupTemplateId!= null) 
 result = result.Where(r => r.productGroup.ProductGroupTemplateId== productGroupTemplateId);

            return Ok(await result.ToListAsync());
        }

    }
}
