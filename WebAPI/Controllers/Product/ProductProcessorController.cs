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

using Application.Domains.Product.ProductProcessor.Queries.GetProductProcessor;
using Application.Domains.Product.ProductProcessor.Queries.GetProductProcessorList;
using Application.Domains.Product.ProductProcessor.Commands.CreateProductProcessor;
using Application.Domains.Product.ProductProcessor.Commands.UpdateProductProcessor;
using Application.Domains.Product.ProductProcessor.Commands.DeleteProductProcessor;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProcessorController : ControllerBase
    {
        private IMediator _mediator;

        public ProductProcessorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductProcessor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessor>> GetProductProcessor(int id)
        {
            var ProductProcessor = await _mediator.Send(new GetProductProcessorQuery { Id = id });

            return ProductProcessor;
        }

        // PUT: api/ProductProcessor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductProcessor>> PutProductProcessor(int id, ProductProcessor ProductProcessor)
        {
            if (id != ProductProcessor.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductProcessorCommand { ProductProcessor = ProductProcessor});

            return result; //  CreatedAtAction("CreateProductProcessor", result); // NoContent();
        }

        // POST: api/ProductProcessor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessor>> PostProductProcessor(ProductProcessor ProductProcessor)
        {
            //            _context.ProductProcessor.Add(ProductProcessor);
            var result = await _mediator.Send(new CreateProductProcessorCommand { ProductProcessor = ProductProcessor});

            return result;
        }

        // DELETE: api/ProductProcessor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessor>> DeleteProductProcessor(int id)
        {

            await _mediator.Send(new DeleteProductProcessorCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductProcessor/5
        [Route("ProductProcessorView")]
        [HttpGet]
        public async Task<ActionResult> GetProductProcessorView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetProductProcessorListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
