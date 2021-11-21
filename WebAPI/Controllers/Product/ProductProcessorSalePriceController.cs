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

using Application.Domains.Product.ProductProcessorSalePrice.Queries.GetProductProcessorSalePrice;
using Application.Domains.Product.ProductProcessorSalePrice.Queries.GetProductProcessorSalePriceList;
using Application.Domains.Product.ProductProcessorSalePrice.Commands.CreateProductProcessorSalePrice;
using Application.Domains.Product.ProductProcessorSalePrice.Commands.UpdateProductProcessorSalePrice;
using Application.Domains.Product.ProductProcessorSalePrice.Commands.DeleteProductProcessorSalePrice;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProcessorSalePriceController : ControllerBase
    {
        private IMediator _mediator;

        public ProductProcessorSalePriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductProcessorSalePrice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessorSalePrice>> GetProductProcessorSalePrice(int id)
        {
            var ProductProcessorSalePrice = await _mediator.Send(new GetProductProcessorSalePriceQuery { Id = id });

            return ProductProcessorSalePrice;
        }

        // PUT: api/ProductProcessorSalePrice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductProcessorSalePrice>> PutProductProcessorSalePrice(int id, ProductProcessorSalePrice ProductProcessorSalePrice)
        {
            if (id != ProductProcessorSalePrice.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductProcessorSalePriceCommand { ProductProcessorSalePrice = ProductProcessorSalePrice});

            return result; //  CreatedAtAction("CreateProductProcessorSalePrice", result); // NoContent();
        }

        // POST: api/ProductProcessorSalePrice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessorSalePrice>> PostProductProcessorSalePrice(ProductProcessorSalePrice ProductProcessorSalePrice)
        {
            //            _context.ProductProcessorSalePrice.Add(ProductProcessorSalePrice);
            var result = await _mediator.Send(new CreateProductProcessorSalePriceCommand { ProductProcessorSalePrice = ProductProcessorSalePrice});

            return result;
        }

        // DELETE: api/ProductProcessorSalePrice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessorSalePrice>> DeleteProductProcessorSalePrice(int id)
        {

            await _mediator.Send(new DeleteProductProcessorSalePriceCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductProcessorSalePrice/5
        [Route("ProductProcessorSalePriceView")]
        [HttpGet]
        public async Task<ActionResult> GetProductProcessorSalePriceView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetProductProcessorSalePriceListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
