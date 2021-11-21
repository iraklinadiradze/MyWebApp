using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;

using Application.Common;
using DataAccessLayer.Model.Product;

using Application.Domains.Product.Brand.Queries.GetBrand;
using Application.Domains.Product.Brand.Queries.GetBrandList;
using Application.Domains.Product.Brand.Commands.CreateBrand;
using Application.Domains.Product.Brand.Commands.UpdateBrand;
using Application.Domains.Product.Brand.Commands.DeleteBrand;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var Brand = await _mediator.Send(new GetBrandQuery { Id = id });

            return Brand;
        }

        // PUT: api/Brand/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> PutBrand(int id, Brand Brand)
        {
            if (id != Brand.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateBrandCommand { Brand = Brand});

            return result; //  CreatedAtAction("CreateBrand", result); // NoContent();
        }

        // POST: api/Brand
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand Brand)
        {
            //            _context.Brand.Add(Brand);
            var result = await _mediator.Send(new CreateBrandCommand { Brand = Brand});

            return result;
        }

        // DELETE: api/Brand/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrand(int id)
        {

            await _mediator.Send(new DeleteBrandCommand { Id = id});

            return NoContent();
        }


        // GET: api/Brand/5
        [Route("BrandView")]
        [HttpGet]
        public async Task<ActionResult> GetBrandView(
            Int32? Id,
String BrandName
      )
        {
            var result = await _mediator.Send(new GetBrandListQuery
            {
                Id = Id,
BrandName = BrandName
            }
            );

            return Ok(result.ToList());
        }

    }
}
