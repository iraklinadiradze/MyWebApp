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
    public class ProductGroupTemplateFeatureController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductGroupTemplateFeatureController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductGroupTemplateFeature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGroupTemplateFeature>>> GetProductGroupTemplateFeature()
        {
            return await _context.ProductGroupTemplateFeature.ToListAsync();
        }

        // GET: api/ProductGroupTemplateFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupTemplateFeature>> GetProductGroupTemplateFeature(int id)
        {
            var productGroupTemplateFeature = await _context.ProductGroupTemplateFeature.FindAsync(id);

            if (productGroupTemplateFeature == null)
            {
                return NotFound();
            }

            return productGroupTemplateFeature;
        }

        // PUT: api/ProductGroupTemplateFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductGroupTemplateFeature(int id, ProductGroupTemplateFeature productGroupTemplateFeature)
        {
            if (id != productGroupTemplateFeature.Id)
            {
                return BadRequest();
            }

            _context.Entry(productGroupTemplateFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductGroupTemplateFeatureExists(id))
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

        // POST: api/ProductGroupTemplateFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductGroupTemplateFeature>> PostProductGroupTemplateFeature(ProductGroupTemplateFeature productGroupTemplateFeature)
        {
            _context.ProductGroupTemplateFeature.Add(productGroupTemplateFeature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductGroupTemplateFeatureExists(productGroupTemplateFeature.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductGroupTemplateFeature", new { id = productGroupTemplateFeature.Id }, productGroupTemplateFeature);
        }

        // DELETE: api/ProductGroupTemplateFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductGroupTemplateFeature>> DeleteProductGroupTemplateFeature(int id)
        {
            var productGroupTemplateFeature = await _context.ProductGroupTemplateFeature.FindAsync(id);
            if (productGroupTemplateFeature == null)
            {
                return NotFound();
            }

            _context.ProductGroupTemplateFeature.Remove(productGroupTemplateFeature);
            await _context.SaveChangesAsync();

            return productGroupTemplateFeature;
        }

        private bool ProductGroupTemplateFeatureExists(int id)
        {
            return _context.ProductGroupTemplateFeature.Any(e => e.Id == id);
        }

        // GET: api/ProductGroupTemplateFeature/5
        [Route("ProductGroupTemplateFeatureView")]
        [HttpGet]
        public async Task<IActionResult> GetProductGroupTemplateFeatureView(
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
Int32? featureId,
Int32? productGroupTemplateId
      )
        {
          /*
           var result = from a in _context.ProductGroupTemplateFeature
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
            
           var result = from e in _context.ProductGroupTemplateFeature
                         join _feature in _context.Feature on e.FeatureId equals _feature.FeatureId into __feature
 from _feature in __feature.DefaultIfEmpty(),
 join _productGroupTemplate in _context.ProductGroupTemplate on e.ProductGroupTemplateId equals _productGroupTemplate.ProductGroupTemplateId into __productGroupTemplate
 from _productGroupTemplate in __productGroupTemplate.DefaultIfEmpty()
                        select new
                           {
                             productGroupTemplateFeature={
                             e.Id,
e.FeatureId,
e.IsMandatory,
e.ProductGroupTemplateId,
e.Version
                            },
                            feature = new {
_feature.Id,
_feature.FeatureName
},
productGroupTemplate = new {
_productGroupTemplate.Id,
_productGroupTemplate.ProductGroupTemplateName
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productGroupTemplateFeature.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productGroupTemplateFeature.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productGroupTemplateFeature.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productGroupTemplateFeature.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productGroupTemplateFeature.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productGroupTemplateFeature.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productGroupTemplateFeature.Id== id);

                if (featureId!= null) 
 result = result.Where(r => r.productGroupTemplateFeature.FeatureId== featureId);

                if (productGroupTemplateId!= null) 
 result = result.Where(r => r.productGroupTemplateFeature.ProductGroupTemplateId== productGroupTemplateId);

            return Ok(await result.ToListAsync());
        }

    }
}
