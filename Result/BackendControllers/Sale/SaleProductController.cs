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
using DataAccessLayer.Model.Sale;

using Application.Domains.Sale.SaleProduct.Queries.GetSaleProduct;
using Application.Domains.Sale.SaleProduct.Queries.GetSaleProductList;
using Application.Domains.Sale.SaleProduct.Commands.CreateSaleProduct;
using Application.Domains.Sale.SaleProduct.Commands.UpdateSaleProduct;
using Application.Domains.Sale.SaleProduct.Commands.DeleteSaleProduct;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleProductController : ControllerBase
    {
        private IMediator _mediator;

        public SaleProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/SaleProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleProduct>> GetSaleProduct(int id)
        {
            var SaleProduct = await _mediator.Send(new GetSaleProductQuery { Id = id });

            return SaleProduct;
        }

        // PUT: api/SaleProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SaleProduct>> PutSaleProduct(int id, SaleProduct SaleProduct)
        {
            if (id != SaleProduct.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateSaleProductCommand { SaleProduct = SaleProduct});

            return result; //  CreatedAtAction("CreateSaleProduct", result); // NoContent();
        }

        // POST: api/SaleProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaleProduct>> PostSaleProduct(SaleProduct SaleProduct)
        {
            //            _context.SaleProduct.Add(SaleProduct);
            var result = await _mediator.Send(new CreateSaleProductCommand { SaleProduct = SaleProduct});

            return result;
        }

        // DELETE: api/SaleProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaleProduct>> DeleteSaleProduct(int id)
        {

            await _mediator.Send(new DeleteSaleProductCommand { Id = id});

            return NoContent();
        }


        // GET: api/SaleProduct/5
        [Route("SaleProductView")]
        [HttpGet]
        public async Task<ActionResult> GetSaleProductView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetSaleProductListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
