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

using Application.Domains.Procurment.PurchaseAllocationResult.Queries.GetPurchaseAllocationResult;
using Application.Domains.Procurment.PurchaseAllocationResult.Queries.GetPurchaseAllocationResultList;
using Application.Domains.Procurment.PurchaseAllocationResult.Commands.CreatePurchaseAllocationResult;
using Application.Domains.Procurment.PurchaseAllocationResult.Commands.UpdatePurchaseAllocationResult;
using Application.Domains.Procurment.PurchaseAllocationResult.Commands.DeletePurchaseAllocationResult;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseAllocationResultController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseAllocationResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseAllocationResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseAllocationResult>> GetPurchaseAllocationResult(int id)
        {
            var PurchaseAllocationResult = await _mediator.Send(new GetPurchaseAllocationResultQuery { Id = id });

            return PurchaseAllocationResult;
        }

        // PUT: api/PurchaseAllocationResult/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseAllocationResult>> PutPurchaseAllocationResult(int id, PurchaseAllocationResult PurchaseAllocationResult)
        {
            if (id != PurchaseAllocationResult.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseAllocationResultCommand { PurchaseAllocationResult = PurchaseAllocationResult});

            return result; //  CreatedAtAction("CreatePurchaseAllocationResult", result); // NoContent();
        }

        // POST: api/PurchaseAllocationResult
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseAllocationResult>> PostPurchaseAllocationResult(PurchaseAllocationResult PurchaseAllocationResult)
        {
            //            _context.PurchaseAllocationResult.Add(PurchaseAllocationResult);
            var result = await _mediator.Send(new CreatePurchaseAllocationResultCommand { PurchaseAllocationResult = PurchaseAllocationResult});

            return result;
        }

        // DELETE: api/PurchaseAllocationResult/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseAllocationResult>> DeletePurchaseAllocationResult(int id)
        {

            await _mediator.Send(new DeletePurchaseAllocationResultCommand { Id = id});

            return NoContent();
        }


        // GET: api/PurchaseAllocationResult/5
        [Route("PurchaseAllocationResultView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseAllocationResultView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseAllocationResultListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
