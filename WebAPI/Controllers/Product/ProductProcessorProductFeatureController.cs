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

using Application.Domains.Product.ProductProcessorProductFeature.Queries.GetProductProcessorProductFeature;
using Application.Domains.Product.ProductProcessorProductFeature.Queries.GetProductProcessorProductFeatureList;
using Application.Domains.Product.ProductProcessorProductFeature.Commands.CreateProductProcessorProductFeature;
using Application.Domains.Product.ProductProcessorProductFeature.Commands.UpdateProductProcessorProductFeature;
using Application.Domains.Product.ProductProcessorProductFeature.Commands.DeleteProductProcessorProductFeature;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProcessorProductFeatureController : ControllerBase
    {
        private IMediator _mediator;

        public ProductProcessorProductFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductProcessorProductFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessorProductFeature>> GetProductProcessorProductFeature(int id)
        {
            var ProductProcessorProductFeature = await _mediator.Send(new GetProductProcessorProductFeatureQuery { Id = id });

            return ProductProcessorProductFeature;
        }

        // PUT: api/ProductProcessorProductFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductProcessorProductFeature>> PutProductProcessorProductFeature(int id, ProductProcessorProductFeature ProductProcessorProductFeature)
        {
            if (id != ProductProcessorProductFeature.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductProcessorProductFeatureCommand { ProductProcessorProductFeature = ProductProcessorProductFeature});

            return result; //  CreatedAtAction("CreateProductProcessorProductFeature", result); // NoContent();
        }

        // POST: api/ProductProcessorProductFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessorProductFeature>> PostProductProcessorProductFeature(ProductProcessorProductFeature ProductProcessorProductFeature)
        {
            //            _context.ProductProcessorProductFeature.Add(ProductProcessorProductFeature);
            var result = await _mediator.Send(new CreateProductProcessorProductFeatureCommand { ProductProcessorProductFeature = ProductProcessorProductFeature});

            return result;
        }

        // DELETE: api/ProductProcessorProductFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessorProductFeature>> DeleteProductProcessorProductFeature(int id)
        {

            await _mediator.Send(new DeleteProductProcessorProductFeatureCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductProcessorProductFeature/5
        [Route("ProductProcessorProductFeatureView")]
        [HttpGet]
        public async Task<ActionResult> GetProductProcessorProductFeatureView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetProductProcessorProductFeatureListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
