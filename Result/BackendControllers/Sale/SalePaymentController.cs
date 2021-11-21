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

using Application.Domains.Sale.SalePayment.Queries.GetSalePayment;
using Application.Domains.Sale.SalePayment.Queries.GetSalePaymentList;
using Application.Domains.Sale.SalePayment.Commands.CreateSalePayment;
using Application.Domains.Sale.SalePayment.Commands.UpdateSalePayment;
using Application.Domains.Sale.SalePayment.Commands.DeleteSalePayment;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalePaymentController : ControllerBase
    {
        private IMediator _mediator;

        public SalePaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/SalePayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalePayment>> GetSalePayment(int id)
        {
            var SalePayment = await _mediator.Send(new GetSalePaymentQuery { Id = id });

            return SalePayment;
        }

        // PUT: api/SalePayment/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SalePayment>> PutSalePayment(int id, SalePayment SalePayment)
        {
            if (id != SalePayment.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateSalePaymentCommand { SalePayment = SalePayment});

            return result; //  CreatedAtAction("CreateSalePayment", result); // NoContent();
        }

        // POST: api/SalePayment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalePayment>> PostSalePayment(SalePayment SalePayment)
        {
            //            _context.SalePayment.Add(SalePayment);
            var result = await _mediator.Send(new CreateSalePaymentCommand { SalePayment = SalePayment});

            return result;
        }

        // DELETE: api/SalePayment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalePayment>> DeleteSalePayment(int id)
        {

            await _mediator.Send(new DeleteSalePaymentCommand { Id = id});

            return NoContent();
        }


        // GET: api/SalePayment/5
        [Route("SalePaymentView")]
        [HttpGet]
        public async Task<ActionResult> GetSalePaymentView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetSalePaymentListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
