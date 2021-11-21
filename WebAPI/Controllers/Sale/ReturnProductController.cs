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

using Application.Domains.Sale.ReturnProduct.Queries.GetReturnProduct;
using Application.Domains.Sale.ReturnProduct.Queries.GetReturnProductList;
using Application.Domains.Sale.ReturnProduct.Commands.CreateReturnProduct;
using Application.Domains.Sale.ReturnProduct.Commands.UpdateReturnProduct;
using Application.Domains.Sale.ReturnProduct.Commands.DeleteReturnProduct;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnProductController : ControllerBase
    {
        private IMediator _mediator;

        public ReturnProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ReturnProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnProduct>> GetReturnProduct(int id)
        {
            var ReturnProduct = await _mediator.Send(new GetReturnProductQuery { Id = id });

            return ReturnProduct;
        }

        // PUT: api/ReturnProduct/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnProduct>> PutReturnProduct(int id, ReturnProduct ReturnProduct)
        {
            if (id != ReturnProduct.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateReturnProductCommand { ReturnProduct = ReturnProduct});

            return result; //  CreatedAtAction("CreateReturnProduct", result); // NoContent();
        }

        // POST: api/ReturnProduct
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReturnProduct>> PostReturnProduct(ReturnProduct ReturnProduct)
        {
            //            _context.ReturnProduct.Add(ReturnProduct);
            var result = await _mediator.Send(new CreateReturnProductCommand { ReturnProduct = ReturnProduct});

            return result;
        }

        // DELETE: api/ReturnProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnProduct>> DeleteReturnProduct(int id)
        {

            await _mediator.Send(new DeleteReturnProductCommand { Id = id});

            return NoContent();
        }


        // GET: api/ReturnProduct/5
        [Route("ReturnProductView")]
        [HttpGet]
        public async Task<ActionResult> GetReturnProductView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetReturnProductListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
