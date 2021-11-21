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

using Application.Domains.Product.ProductGroupTemplateFeature.Queries.GetProductGroupTemplateFeature;
using Application.Domains.Product.ProductGroupTemplateFeature.Queries.GetProductGroupTemplateFeatureList;
using Application.Domains.Product.ProductGroupTemplateFeature.Commands.CreateProductGroupTemplateFeature;
using Application.Domains.Product.ProductGroupTemplateFeature.Commands.UpdateProductGroupTemplateFeature;
using Application.Domains.Product.ProductGroupTemplateFeature.Commands.DeleteProductGroupTemplateFeature;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupTemplateFeatureController : ControllerBase
    {
        private IMediator _mediator;

        public ProductGroupTemplateFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductGroupTemplateFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupTemplateFeature>> GetProductGroupTemplateFeature(int id)
        {
            var ProductGroupTemplateFeature = await _mediator.Send(new GetProductGroupTemplateFeatureQuery { Id = id });

            return ProductGroupTemplateFeature;
        }

        // PUT: api/ProductGroupTemplateFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductGroupTemplateFeature>> PutProductGroupTemplateFeature(int id, ProductGroupTemplateFeature ProductGroupTemplateFeature)
        {
            if (id != ProductGroupTemplateFeature.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductGroupTemplateFeatureCommand { ProductGroupTemplateFeature = ProductGroupTemplateFeature});

            return result; //  CreatedAtAction("CreateProductGroupTemplateFeature", result); // NoContent();
        }

        // POST: api/ProductGroupTemplateFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductGroupTemplateFeature>> PostProductGroupTemplateFeature(ProductGroupTemplateFeature ProductGroupTemplateFeature)
        {
            //            _context.ProductGroupTemplateFeature.Add(ProductGroupTemplateFeature);
            var result = await _mediator.Send(new CreateProductGroupTemplateFeatureCommand { ProductGroupTemplateFeature = ProductGroupTemplateFeature});

            return result;
        }

        // DELETE: api/ProductGroupTemplateFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductGroupTemplateFeature>> DeleteProductGroupTemplateFeature(int id)
        {

            await _mediator.Send(new DeleteProductGroupTemplateFeatureCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductGroupTemplateFeature/5
        [Route("ProductGroupTemplateFeatureView")]
        [HttpGet]
        public async Task<ActionResult> GetProductGroupTemplateFeatureView(
            Int32? Id,
Int32? FeatureId,
Int32? ProductGroupTemplateId
      )
        {
            var result = await _mediator.Send(new GetProductGroupTemplateFeatureListQuery
            {
                Id = Id,
FeatureId = FeatureId,
ProductGroupTemplateId = ProductGroupTemplateId
            }
            );

            return Ok(result.ToList());
        }

    }
}
