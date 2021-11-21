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

using Application.Domains.Product.ProductFeature.Queries.GetProductFeature;
using Application.Domains.Product.ProductFeature.Queries.GetProductFeatureList;
using Application.Domains.Product.ProductFeature.Commands.CreateProductFeature;
using Application.Domains.Product.ProductFeature.Commands.UpdateProductFeature;
using Application.Domains.Product.ProductFeature.Commands.DeleteProductFeature;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : ControllerBase
    {
        private IMediator _mediator;

        public ProductFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductFeature>> GetProductFeature(int id)
        {
            var ProductFeature = await _mediator.Send(new GetProductFeatureQuery { Id = id });

            return ProductFeature;
        }

        // PUT: api/ProductFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductFeature>> PutProductFeature(int id, ProductFeature ProductFeature)
        {
            if (id != ProductFeature.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductFeatureCommand { ProductFeature = ProductFeature});

            return result; //  CreatedAtAction("CreateProductFeature", result); // NoContent();
        }

        // POST: api/ProductFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductFeature>> PostProductFeature(ProductFeature ProductFeature)
        {
            //            _context.ProductFeature.Add(ProductFeature);
            var result = await _mediator.Send(new CreateProductFeatureCommand { ProductFeature = ProductFeature});

            return result;
        }

        // DELETE: api/ProductFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductFeature>> DeleteProductFeature(int id)
        {

            await _mediator.Send(new DeleteProductFeatureCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductFeature/5
        [Route("ProductFeatureView")]
        [HttpGet]
        public async Task<ActionResult> GetProductFeatureView(
            Int32? FeatureValueId,
Int32? ProductId
      )
        {
            var result = await _mediator.Send(new GetProductFeatureListQuery
            {
                FeatureValueId = FeatureValueId,
ProductId = ProductId
            }
            );

            return Ok(result.ToList());
        }

    }
}
