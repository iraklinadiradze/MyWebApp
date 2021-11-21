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

using Application.Domains.Account.AccountDimension.Queries.GetAccountDimension;
using Application.Domains.Account.AccountDimension.Queries.GetAccountDimensionList;
using Application.Domains.Account.AccountDimension.Commands.CreateAccountDimension;
using Application.Domains.Account.AccountDimension.Commands.UpdateAccountDimension;
using Application.Domains.Account.AccountDimension.Commands.DeleteAccountDimension;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDimensionController : ControllerBase
    {
        private IMediator _mediator;

        public AccountDimensionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/AccountDimension/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDimension>> GetAccountDimension(int id)
        {
            var AccountDimension = await _mediator.Send(new GetAccountDimensionQuery { Id = id });

            return AccountDimension;
        }

        // PUT: api/AccountDimension/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<AccountDimension>> PutAccountDimension(int id, AccountDimension AccountDimension)
        {
            if (id != AccountDimension.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateAccountDimensionCommand { AccountDimension = AccountDimension});

            return result; //  CreatedAtAction("CreateAccountDimension", result); // NoContent();
        }

        // POST: api/AccountDimension
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountDimension>> PostAccountDimension(AccountDimension AccountDimension)
        {
            //            _context.AccountDimension.Add(AccountDimension);
            var result = await _mediator.Send(new CreateAccountDimensionCommand { AccountDimension = AccountDimension});

            return result;
        }

        // DELETE: api/AccountDimension/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountDimension>> DeleteAccountDimension(int id)
        {

            await _mediator.Send(new DeleteAccountDimensionCommand { Id = id});

            return NoContent();
        }


        // GET: api/AccountDimension/5
        [Route("AccountDimensionView")]
        [HttpGet]
        public async Task<ActionResult> GetAccountDimensionView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetAccountDimensionListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
