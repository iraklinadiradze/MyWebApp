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

using Application.Domains.GeneralLedger.GlAccount.Queries.GetGlAccount;
using Application.Domains.GeneralLedger.GlAccount.Queries.GetGlAccountList;
using Application.Domains.GeneralLedger.GlAccount.Commands.CreateGlAccount;
using Application.Domains.GeneralLedger.GlAccount.Commands.UpdateGlAccount;
using Application.Domains.GeneralLedger.GlAccount.Commands.DeleteGlAccount;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GlAccountController : ControllerBase
    {
        private IMediator _mediator;

        public GlAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GlAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlAccount>> GetGlAccount(int id)
        {
            var GlAccount = await _mediator.Send(new GetGlAccountQuery { Id = id });

            return GlAccount;
        }

        // PUT: api/GlAccount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<GlAccount>> PutGlAccount(int id, GlAccount GlAccount)
        {
            if (id != GlAccount.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateGlAccountCommand { GlAccount = GlAccount});

            return result; //  CreatedAtAction("CreateGlAccount", result); // NoContent();
        }

        // POST: api/GlAccount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GlAccount>> PostGlAccount(GlAccount GlAccount)
        {
            //            _context.GlAccount.Add(GlAccount);
            var result = await _mediator.Send(new CreateGlAccountCommand { GlAccount = GlAccount});

            return result;
        }

        // DELETE: api/GlAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GlAccount>> DeleteGlAccount(int id)
        {

            await _mediator.Send(new DeleteGlAccountCommand { Id = id});

            return NoContent();
        }


        // GET: api/GlAccount/5
        [Route("GlAccountView")]
        [HttpGet]
        public async Task<ActionResult> GetGlAccountView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetGlAccountListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
