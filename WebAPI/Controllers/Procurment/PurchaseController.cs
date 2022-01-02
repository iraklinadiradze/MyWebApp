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
using DataAccessLayer.Model.Procurment;

using Application.Domains.Procurment.Purchase.Queries.GetPurchase;
using Application.Domains.Procurment.Purchase.Queries.GetPurchaseList;
using Application.Domains.Procurment.Purchase.Commands.CreatePurchase;
using Application.Domains.Procurment.Purchase.Commands.UpdatePurchase;
using Application.Domains.Procurment.Purchase.Commands.DeletePurchase;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Purchase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var Purchase = await _mediator.Send(new GetPurchaseQuery { Id = id });

            return Purchase;
        }

        // PUT: api/Purchase/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Purchase>> PutPurchase(int id, Purchase Purchase)
        {
            if (id != Purchase.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseCommand { Purchase = Purchase});

            return result; //  CreatedAtAction("CreatePurchase", result); // NoContent();
        }

        // POST: api/Purchase
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase Purchase)
        {
            //            _context.Purchase.Add(Purchase);
            var result = await _mediator.Send(new AllocatePurchaseCommand { Purchase = Purchase});

            return result;
        }

        // DELETE: api/Purchase/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Purchase>> DeletePurchase(int id)
        {

            await _mediator.Send(new DeletePurchaseCommand { Id = id});

            return NoContent();
        }


        // GET: api/Purchase/5
        [Route("PurchaseView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
