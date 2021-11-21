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

using Application.Domains.Account.Account.Queries.GetAccount;
using Application.Domains.Account.Account.Queries.GetAccountList;
using Application.Domains.Account.Account.Commands.CreateAccount;
using Application.Domains.Account.Account.Commands.UpdateAccount;
using Application.Domains.Account.Account.Commands.DeleteAccount;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var Account = await _mediator.Send(new GetAccountQuery { Id = id });

            return Account;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Account>> PutAccount(int id, Account Account)
        {
            if (id != Account.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateAccountCommand { Account = Account});

            return result; //  CreatedAtAction("CreateAccount", result); // NoContent();
        }

        // POST: api/Account
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account Account)
        {
            //            _context.Account.Add(Account);
            var result = await _mediator.Send(new CreateAccountCommand { Account = Account});

            return result;
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {

            await _mediator.Send(new DeleteAccountCommand { Id = id});

            return NoContent();
        }


        // GET: api/Account/5
        [Route("AccountView")]
        [HttpGet]
        public async Task<ActionResult> GetAccountView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetAccountListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
