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
using DataAccessLayer.Model.Account;

using Application.Domains.Account.TransactionOrder.Queries.GetTransactionOrder;
using Application.Domains.Account.TransactionOrder.Queries.GetTransactionOrderList;
using Application.Domains.Account.TransactionOrder.Commands.CreateTransactionOrder;
using Application.Domains.Account.TransactionOrder.Commands.UpdateTransactionOrder;
using Application.Domains.Account.TransactionOrder.Commands.DeleteTransactionOrder;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionOrderController : ControllerBase
    {
        private IMediator _mediator;

        public TransactionOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/TransactionOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionOrder>> GetTransactionOrder(int id)
        {
            var TransactionOrder = await _mediator.Send(new GetTransactionOrderQuery { Id = id });

            return TransactionOrder;
        }

        // PUT: api/TransactionOrder/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionOrder>> PutTransactionOrder(int id, TransactionOrder TransactionOrder)
        {
            if (id != TransactionOrder.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateTransactionOrderCommand { TransactionOrder = TransactionOrder});

            return result; //  CreatedAtAction("CreateTransactionOrder", result); // NoContent();
        }

        // POST: api/TransactionOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransactionOrder>> PostTransactionOrder(TransactionOrder TransactionOrder)
        {
            //            _context.TransactionOrder.Add(TransactionOrder);
            var result = await _mediator.Send(new CreateTransactionOrderCommand { TransactionOrder = TransactionOrder});

            return result;
        }

        // DELETE: api/TransactionOrder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionOrder>> DeleteTransactionOrder(int id)
        {

            await _mediator.Send(new DeleteTransactionOrderCommand { Id = id});

            return NoContent();
        }


        // GET: api/TransactionOrder/5
        [Route("TransactionOrderView")]
        [HttpGet]
        public async Task<ActionResult> GetTransactionOrderView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetTransactionOrderListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
