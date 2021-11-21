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

using Application.Domains.GeneralLedger.GlTransaction.Queries.GetGlTransaction;
using Application.Domains.GeneralLedger.GlTransaction.Queries.GetGlTransactionList;
using Application.Domains.GeneralLedger.GlTransaction.Commands.CreateGlTransaction;
using Application.Domains.GeneralLedger.GlTransaction.Commands.UpdateGlTransaction;
using Application.Domains.GeneralLedger.GlTransaction.Commands.DeleteGlTransaction;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GlTransactionController : ControllerBase
    {
        private IMediator _mediator;

        public GlTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GlTransaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlTransaction>> GetGlTransaction(int id)
        {
            var GlTransaction = await _mediator.Send(new GetGlTransactionQuery { Id = id });

            return GlTransaction;
        }

        // PUT: api/GlTransaction/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<GlTransaction>> PutGlTransaction(int id, GlTransaction GlTransaction)
        {
            if (id != GlTransaction.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateGlTransactionCommand { GlTransaction = GlTransaction});

            return result; //  CreatedAtAction("CreateGlTransaction", result); // NoContent();
        }

        // POST: api/GlTransaction
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GlTransaction>> PostGlTransaction(GlTransaction GlTransaction)
        {
            //            _context.GlTransaction.Add(GlTransaction);
            var result = await _mediator.Send(new CreateGlTransactionCommand { GlTransaction = GlTransaction});

            return result;
        }

        // DELETE: api/GlTransaction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GlTransaction>> DeleteGlTransaction(int id)
        {

            await _mediator.Send(new DeleteGlTransactionCommand { Id = id});

            return NoContent();
        }


        // GET: api/GlTransaction/5
        [Route("GlTransactionView")]
        [HttpGet]
        public async Task<ActionResult> GetGlTransactionView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetGlTransactionListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
