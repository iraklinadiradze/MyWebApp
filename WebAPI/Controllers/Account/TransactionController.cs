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

using Application.Domains.Account.Transaction.Queries.GetTransaction;
using Application.Domains.Account.Transaction.Queries.GetTransactionList;
using Application.Domains.Account.Transaction.Commands.CreateTransaction;
using Application.Domains.Account.Transaction.Commands.UpdateTransaction;
using Application.Domains.Account.Transaction.Commands.DeleteTransaction;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var Transaction = await _mediator.Send(new GetTransactionQuery { Id = id });

            return Transaction;
        }

        // PUT: api/Transaction/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Transaction>> PutTransaction(int id, Transaction Transaction)
        {
            if (id != Transaction.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateTransactionCommand { Transaction = Transaction});

            return result; //  CreatedAtAction("CreateTransaction", result); // NoContent();
        }

        // POST: api/Transaction
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction Transaction)
        {
            //            _context.Transaction.Add(Transaction);
            var result = await _mediator.Send(new CreateTransactionCommand { Transaction = Transaction});

            return result;
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteTransaction(int id)
        {

            await _mediator.Send(new DeleteTransactionCommand { Id = id});

            return NoContent();
        }


        // GET: api/Transaction/5
        [Route("TransactionView")]
        [HttpGet]
        public async Task<ActionResult> GetTransactionView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetTransactionListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
