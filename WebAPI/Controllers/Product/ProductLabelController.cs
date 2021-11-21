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

using Application.Domains.Product.ProductLabel.Queries.GetProductLabel;
using Application.Domains.Product.ProductLabel.Queries.GetProductLabelList;
using Application.Domains.Product.ProductLabel.Commands.CreateProductLabel;
using Application.Domains.Product.ProductLabel.Commands.UpdateProductLabel;
using Application.Domains.Product.ProductLabel.Commands.DeleteProductLabel;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLabelController : ControllerBase
    {
        private IMediator _mediator;

        public ProductLabelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductLabel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductLabel>> GetProductLabel(int id)
        {
            var ProductLabel = await _mediator.Send(new GetProductLabelQuery { Id = id });

            return ProductLabel;
        }

        // PUT: api/ProductLabel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductLabel>> PutProductLabel(int id, ProductLabel ProductLabel)
        {
            if (id != ProductLabel.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductLabelCommand { ProductLabel = ProductLabel});

            return result; //  CreatedAtAction("CreateProductLabel", result); // NoContent();
        }

        // POST: api/ProductLabel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductLabel>> PostProductLabel(ProductLabel ProductLabel)
        {
            //            _context.ProductLabel.Add(ProductLabel);
            var result = await _mediator.Send(new CreateProductLabelCommand { ProductLabel = ProductLabel});

            return result;
        }

        // DELETE: api/ProductLabel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductLabel>> DeleteProductLabel(int id)
        {

            await _mediator.Send(new DeleteProductLabelCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductLabel/5
        [Route("ProductLabelView")]
        [HttpGet]
        public async Task<ActionResult> GetProductLabelView(
            Int32? Id,
Int32? BrandId,
String ProductLabelName
      )
        {
            var result = await _mediator.Send(new GetProductLabelListQuery
            {
                Id = Id,
BrandId = BrandId,
ProductLabelName = ProductLabelName
            }
            );

            return Ok(result.ToList());
        }

    }
}
