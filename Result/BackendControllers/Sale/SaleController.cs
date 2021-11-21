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

using Application.Domains.Sale.Sale.Queries.GetSale;
using Application.Domains.Sale.Sale.Queries.GetSaleList;
using Application.Domains.Sale.Sale.Commands.CreateSale;
using Application.Domains.Sale.Sale.Commands.UpdateSale;
using Application.Domains.Sale.Sale.Commands.DeleteSale;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Sale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var Sale = await _mediator.Send(new GetSaleQuery { Id = id });

            return Sale;
        }

        // PUT: api/Sale/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Sale>> PutSale(int id, Sale Sale)
        {
            if (id != Sale.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateSaleCommand { Sale = Sale});

            return result; //  CreatedAtAction("CreateSale", result); // NoContent();
        }

        // POST: api/Sale
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale Sale)
        {
            //            _context.Sale.Add(Sale);
            var result = await _mediator.Send(new CreateSaleCommand { Sale = Sale});

            return result;
        }

        // DELETE: api/Sale/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> DeleteSale(int id)
        {

            await _mediator.Send(new DeleteSaleCommand { Id = id});

            return NoContent();
        }


        // GET: api/Sale/5
        [Route("SaleView")]
        [HttpGet]
        public async Task<ActionResult> GetSaleView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetSaleListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
