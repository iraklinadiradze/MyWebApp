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

using Application.Domains.Procurment.PurchaseAllocationSourceType.Queries.GetPurchaseAllocationSourceType;
using Application.Domains.Procurment.PurchaseAllocationSourceType.Queries.GetPurchaseAllocationSourceTypeList;
using Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.CreatePurchaseAllocationSourceType;
using Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.UpdatePurchaseAllocationSourceType;
using Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.DeletePurchaseAllocationSourceType;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseAllocationSourceTypeController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseAllocationSourceTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseAllocationSourceType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseAllocationSourceType>> GetPurchaseAllocationSourceType(int id)
        {
            var PurchaseAllocationSourceType = await _mediator.Send(new GetPurchaseAllocationSourceTypeQuery { Id = id });

            return PurchaseAllocationSourceType;
        }

        // PUT: api/PurchaseAllocationSourceType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseAllocationSourceType>> PutPurchaseAllocationSourceType(int id, PurchaseAllocationSourceType PurchaseAllocationSourceType)
        {
            if (id != PurchaseAllocationSourceType.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseAllocationSourceTypeCommand { PurchaseAllocationSourceType = PurchaseAllocationSourceType});

            return result; //  CreatedAtAction("CreatePurchaseAllocationSourceType", result); // NoContent();
        }

        // POST: api/PurchaseAllocationSourceType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseAllocationSourceType>> PostPurchaseAllocationSourceType(PurchaseAllocationSourceType PurchaseAllocationSourceType)
        {
            //            _context.PurchaseAllocationSourceType.Add(PurchaseAllocationSourceType);
            var result = await _mediator.Send(new CreatePurchaseAllocationSourceTypeCommand { PurchaseAllocationSourceType = PurchaseAllocationSourceType});

            return result;
        }

        // DELETE: api/PurchaseAllocationSourceType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseAllocationSourceType>> DeletePurchaseAllocationSourceType(int id)
        {

            await _mediator.Send(new DeletePurchaseAllocationSourceTypeCommand { Id = id});

            return NoContent();
        }


        // GET: api/PurchaseAllocationSourceType/5
        [Route("PurchaseAllocationSourceTypeView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseAllocationSourceTypeView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseAllocationSourceTypeListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
