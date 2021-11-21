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
using DataAccessLayer.Model.GeneralLedger;

using Application.Domains.GeneralLedger.FinAccount.Queries.GetFinAccount;
using Application.Domains.GeneralLedger.FinAccount.Queries.GetFinAccountList;
using Application.Domains.GeneralLedger.FinAccount.Commands.CreateFinAccount;
using Application.Domains.GeneralLedger.FinAccount.Commands.UpdateFinAccount;
using Application.Domains.GeneralLedger.FinAccount.Commands.DeleteFinAccount;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinAccountController : ControllerBase
    {
        private IMediator _mediator;

        public FinAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/FinAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinAccount>> GetFinAccount(int id)
        {
            var FinAccount = await _mediator.Send(new GetFinAccountQuery { Id = id });

            return FinAccount;
        }

        // PUT: api/FinAccount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<FinAccount>> PutFinAccount(int id, FinAccount FinAccount)
        {
            if (id != FinAccount.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateFinAccountCommand { FinAccount = FinAccount});

            return result; //  CreatedAtAction("CreateFinAccount", result); // NoContent();
        }

        // POST: api/FinAccount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FinAccount>> PostFinAccount(FinAccount FinAccount)
        {
            //            _context.FinAccount.Add(FinAccount);
            var result = await _mediator.Send(new CreateFinAccountCommand { FinAccount = FinAccount});

            return result;
        }

        // DELETE: api/FinAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinAccount>> DeleteFinAccount(int id)
        {

            await _mediator.Send(new DeleteFinAccountCommand { Id = id});

            return NoContent();
        }


        // GET: api/FinAccount/5
        [Route("FinAccountView")]
        [HttpGet]
        public async Task<ActionResult> GetFinAccountView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetFinAccountListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
