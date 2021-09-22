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
    public class ProductGroupTemplateController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductGroupTemplateController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductGroupTemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGroupTemplate>>> GetProductGroupTemplate()
        {
            return await _context.ProductGroupTemplate.ToListAsync();
        }

        // GET: api/ProductGroupTemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupTemplate>> GetProductGroupTemplate(int id)
        {
            var productGroupTemplate = await _context.ProductGroupTemplate.FindAsync(id);

            if (productGroupTemplate == null)
            {
                return NotFound();
            }

            return productGroupTemplate;
        }

        // PUT: api/ProductGroupTemplate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductGroupTemplate(int id, ProductGroupTemplate productGroupTemplate)
        {
            if (id != productGroupTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(productGroupTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductGroupTemplateExists(id))
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

        // POST: api/ProductGroupTemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductGroupTemplate>> PostProductGroupTemplate(ProductGroupTemplate productGroupTemplate)
        {
            _context.ProductGroupTemplate.Add(productGroupTemplate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductGroupTemplateExists(productGroupTemplate.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductGroupTemplate", new { id = productGroupTemplate.Id }, productGroupTemplate);
        }

        // DELETE: api/ProductGroupTemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductGroupTemplate>> DeleteProductGroupTemplate(int id)
        {
            var productGroupTemplate = await _context.ProductGroupTemplate.FindAsync(id);
            if (productGroupTemplate == null)
            {
                return NotFound();
            }

            _context.ProductGroupTemplate.Remove(productGroupTemplate);
            await _context.SaveChangesAsync();

            return productGroupTemplate;
        }

        private bool ProductGroupTemplateExists(int id)
        {
            return _context.ProductGroupTemplate.Any(e => e.Id == id);
        }

        // GET: api/ProductGroupTemplate/5
        [Route("ProductGroupTemplateView")]
        [HttpGet]
        public async Task<IActionResult> GetProductGroupTemplateView(
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
String productGroupTemplateName,
Int32? productUnitId
      )
        {
          /*
           var result = from a in _context.ProductGroupTemplate
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
            
           var result = from e in _context.ProductGroupTemplate
                         join _productUnit in _context.ProductUnit on e.ProductUnitId equals _productUnit.ProductUnitId into __productUnit
 from _productUnit in __productUnit.DefaultIfEmpty()
                        select new
                           {
                             productGroupTemplate={
                             e.Id,
e.IsSingle,
e.IsTangible,
e.IsWholeQuantity,
e.ProductGroupTemplateName,
e.ProductUnitId,
e.Version
                            },
                            productUnit = new {
_productUnit.Id,
_productUnit.ProductUnitName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productGroupTemplate.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productGroupTemplate.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productGroupTemplate.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productGroupTemplate.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productGroupTemplate.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productGroupTemplate.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productGroupTemplate.Id== id);

                if (productGroupTemplateName!= null) 
 result = result.Where(r => r.productGroupTemplate.ProductGroupTemplateName.StartsWith(productGroupTemplateName));

                if (productUnitId!= null) 
 result = result.Where(r => r.productGroupTemplate.ProductUnitId== productUnitId);

            return Ok(await result.ToListAsync());
        }

    }
}
