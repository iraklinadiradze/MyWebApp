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

using Application.Domains.Account.AccountBalance.Queries.GetAccountBalance;
using Application.Domains.Account.AccountBalance.Queries.GetAccountBalanceList;
using Application.Domains.Account.AccountBalance.Commands.CreateAccountBalance;
using Application.Domains.Account.AccountBalance.Commands.UpdateAccountBalance;
using Application.Domains.Account.AccountBalance.Commands.DeleteAccountBalance;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBalanceController : ControllerBase
    {
        private IMediator _mediator;

        public AccountBalanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/AccountBalance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountBalance>> GetAccountBalance(int id)
        {
            var AccountBalance = await _mediator.Send(new GetAccountBalanceQuery { Id = id });

            return AccountBalance;
        }

        // PUT: api/AccountBalance/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<AccountBalance>> PutAccountBalance(int id, AccountBalance AccountBalance)
        {
            if (id != AccountBalance.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateAccountBalanceCommand { AccountBalance = AccountBalance});

            return result; //  CreatedAtAction("CreateAccountBalance", result); // NoContent();
        }

        // POST: api/AccountBalance
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountBalance>> PostAccountBalance(AccountBalance AccountBalance)
        {
            //            _context.AccountBalance.Add(AccountBalance);
            var result = await _mediator.Send(new CreateAccountBalanceCommand { AccountBalance = AccountBalance});

            return result;
        }

        // DELETE: api/AccountBalance/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountBalance>> DeleteAccountBalance(int id)
        {

            await _mediator.Send(new DeleteAccountBalanceCommand { Id = id});

            return NoContent();
        }


        // GET: api/AccountBalance/5
        [Route("AccountBalanceView")]
        [HttpGet]
        public async Task<ActionResult> GetAccountBalanceView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetAccountBalanceListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
