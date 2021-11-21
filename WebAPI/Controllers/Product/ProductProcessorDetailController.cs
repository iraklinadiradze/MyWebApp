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

using Application.Domains.Product.ProductProcessorDetail.Queries.GetProductProcessorDetail;
using Application.Domains.Product.ProductProcessorDetail.Queries.GetProductProcessorDetailList;
using Application.Domains.Product.ProductProcessorDetail.Commands.CreateProductProcessorDetail;
using Application.Domains.Product.ProductProcessorDetail.Commands.UpdateProductProcessorDetail;
using Application.Domains.Product.ProductProcessorDetail.Commands.DeleteProductProcessorDetail;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProcessorDetailController : ControllerBase
    {
        private IMediator _mediator;

        public ProductProcessorDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductProcessorDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProcessorDetail>> GetProductProcessorDetail(int id)
        {
            var ProductProcessorDetail = await _mediator.Send(new GetProductProcessorDetailQuery { Id = id });

            return ProductProcessorDetail;
        }

        // PUT: api/ProductProcessorDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductProcessorDetail>> PutProductProcessorDetail(int id, ProductProcessorDetail ProductProcessorDetail)
        {
            if (id != ProductProcessorDetail.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductProcessorDetailCommand { ProductProcessorDetail = ProductProcessorDetail});

            return result; //  CreatedAtAction("CreateProductProcessorDetail", result); // NoContent();
        }

        // POST: api/ProductProcessorDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductProcessorDetail>> PostProductProcessorDetail(ProductProcessorDetail ProductProcessorDetail)
        {
            //            _context.ProductProcessorDetail.Add(ProductProcessorDetail);
            var result = await _mediator.Send(new CreateProductProcessorDetailCommand { ProductProcessorDetail = ProductProcessorDetail});

            return result;
        }

        // DELETE: api/ProductProcessorDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductProcessorDetail>> DeleteProductProcessorDetail(int id)
        {

            await _mediator.Send(new DeleteProductProcessorDetailCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductProcessorDetail/5
        [Route("ProductProcessorDetailView")]
        [HttpGet]
        public async Task<ActionResult> GetProductProcessorDetailView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetProductProcessorDetailListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
