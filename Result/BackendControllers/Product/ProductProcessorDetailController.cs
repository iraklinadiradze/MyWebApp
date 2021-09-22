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
    public class ProductProcessorDetailController : ControllerBase
    {
        private readonly CoreDBContext _context;

        public ProductProcessorDetailController(CoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductProcessorDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProcessorDetail>>> GetProductProcessorDetail()
        {
            return await _context.ProductProcessorDetail.ToListAsync();
        }

        // GET: api/ProductProcessorDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessorDetail>> GetProductProcessorDetail(int id)
        {
            var productProcessorDetail = await _context.ProductProcessorDetail.FindAsync(id);

            if (productProcessorDetail == null)
            {
                return NotFound();
            }

            return productProcessorDetail;
        }

        // PUT: api/ProductProcessorDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProcessorDetail(int id, ProductProcessorDetail productProcessorDetail)
        {
            if (id != productProcessorDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(productProcessorDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductProcessorDetailExists(id))
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

        // POST: api/ProductProcessorDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessorDetail>> PostProductProcessorDetail(ProductProcessorDetail productProcessorDetail)
        {
            _context.ProductProcessorDetail.Add(productProcessorDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductProcessorDetailExists(productProcessorDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductProcessorDetail", new { id = productProcessorDetail.Id }, productProcessorDetail);
        }

        // DELETE: api/ProductProcessorDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessorDetail>> DeleteProductProcessorDetail(int id)
        {
            var productProcessorDetail = await _context.ProductProcessorDetail.FindAsync(id);
            if (productProcessorDetail == null)
            {
                return NotFound();
            }

            _context.ProductProcessorDetail.Remove(productProcessorDetail);
            await _context.SaveChangesAsync();

            return productProcessorDetail;
        }

        private bool ProductProcessorDetailExists(int id)
        {
            return _context.ProductProcessorDetail.Any(e => e.Id == id);
        }

        // GET: api/ProductProcessorDetail/5
        [Route("ProductProcessorDetailView")]
        [HttpGet]
        public async Task<IActionResult> GetProductProcessorDetailView(
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
           var result = from a in _context.ProductProcessorDetail
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
            
           var result = from e in _context.ProductProcessorDetail
                         join _productProcessor in _context.ProductProcessor on e.ProductProcessorId equals _productProcessor.ProductProcessorId into __productProcessor
 from _productProcessor in __productProcessor.DefaultIfEmpty()
                        select new
                           {
                             productProcessorDetail={
                             e.Id,
e.BrandId,
e.BrandIdDictionary,
e.BrandName,
e.Cost,
e.LocationId,
e.ProductCode,
e.ProductGroupId,
e.ProductGroupIdDictionary,
e.ProductGroupName,
e.ProductId,
e.ProductLabelId,
e.ProductLabelIdDictionary,
e.ProductLabelName,
e.ProductProcessorId,
e.Qty,
e.Version
                            },
                            productProcessor = new {
_productProcessor.Id
}
                           }
            /*
            if (id != null)
                result = result.Where(r => r.productProcessorDetail.Id == id);

            if (topRecords != null)
                result = result.Take((int)topRecords);

            if (firstName != null)
                result = result.Where( r=>r.productProcessorDetail.FirstName.StartsWith(firstName) );

            if (lastName != null)
                result = result.Where(r => r.productProcessorDetail.LastName.StartsWith(lastName));

            if (pid != null)
                result = result.Where(r =>r.productProcessorDetail.PersonalId == pid);

            if (bodFrom != null)
                result = result.Where(r => r.productProcessorDetail.BirthDate >= (DateTime)bodFrom );

            if (bodTo != null)
                result = result.Where(r => r.productProcessorDetail.BirthDate >= (DateTime)bodTo);
            */

                            if (id!= null) 
 result = result.Where(r => r.productProcessorDetail.Id== id);

            return Ok(await result.ToListAsync());
        }

    }
}
