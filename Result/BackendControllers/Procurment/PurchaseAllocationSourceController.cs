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

using Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSource;
using Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSourceList;
using Application.Domains.Procurment.PurchaseAllocationSource.Commands.CreatePurchaseAllocationSource;
using Application.Domains.Procurment.PurchaseAllocationSource.Commands.UpdatePurchaseAllocationSource;
using Application.Domains.Procurment.PurchaseAllocationSource.Commands.DeletePurchaseAllocationSource;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseAllocationSourceController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseAllocationSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseAllocationSource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseAllocationSource>> GetPurchaseAllocationSource(int id)
        {
            var PurchaseAllocationSource = await _mediator.Send(new GetPurchaseAllocationSourceQuery { Id = id });

            return PurchaseAllocationSource;
        }

        // PUT: api/PurchaseAllocationSource/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseAllocationSource>> PutPurchaseAllocationSource(int id, PurchaseAllocationSource PurchaseAllocationSource)
        {
            if (id != PurchaseAllocationSource.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseAllocationSourceCommand { PurchaseAllocationSource = PurchaseAllocationSource});

            return result; //  CreatedAtAction("CreatePurchaseAllocationSource", result); // NoContent();
        }

        // POST: api/PurchaseAllocationSource
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseAllocationSource>> PostPurchaseAllocationSource(PurchaseAllocationSource PurchaseAllocationSource)
        {
            //            _context.PurchaseAllocationSource.Add(PurchaseAllocationSource);
            var result = await _mediator.Send(new CreatePurchaseAllocationSourceCommand { PurchaseAllocationSource = PurchaseAllocationSource});

            return result;
        }

        // DELETE: api/PurchaseAllocationSource/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseAllocationSource>> DeletePurchaseAllocationSource(int id)
        {

            await _mediator.Send(new DeletePurchaseAllocationSourceCommand { Id = id});

            return NoContent();
        }


        // GET: api/PurchaseAllocationSource/5
        [Route("PurchaseAllocationSourceView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseAllocationSourceView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseAllocationSourceListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
