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

using Application.Domains.Procurment.PurchaseAllocationSchema.Queries.GetPurchaseAllocationSchema;
using Application.Domains.Procurment.PurchaseAllocationSchema.Queries.GetPurchaseAllocationSchemaList;
using Application.Domains.Procurment.PurchaseAllocationSchema.Commands.CreatePurchaseAllocationSchema;
using Application.Domains.Procurment.PurchaseAllocationSchema.Commands.UpdatePurchaseAllocationSchema;
using Application.Domains.Procurment.PurchaseAllocationSchema.Commands.DeletePurchaseAllocationSchema;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseAllocationSchemaController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseAllocationSchemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseAllocationSchema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseAllocationSchema>> GetPurchaseAllocationSchema(int id)
        {
            var PurchaseAllocationSchema = await _mediator.Send(new GetPurchaseAllocationSchemaQuery { Id = id });

            return PurchaseAllocationSchema;
        }

        // PUT: api/PurchaseAllocationSchema/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseAllocationSchema>> PutPurchaseAllocationSchema(int id, PurchaseAllocationSchema PurchaseAllocationSchema)
        {
            if (id != PurchaseAllocationSchema.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseAllocationSchemaCommand { PurchaseAllocationSchema = PurchaseAllocationSchema});

            return result; //  CreatedAtAction("CreatePurchaseAllocationSchema", result); // NoContent();
        }

        // POST: api/PurchaseAllocationSchema
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseAllocationSchema>> PostPurchaseAllocationSchema(PurchaseAllocationSchema PurchaseAllocationSchema)
        {
            //            _context.PurchaseAllocationSchema.Add(PurchaseAllocationSchema);
            var result = await _mediator.Send(new CreatePurchaseAllocationSchemaCommand { PurchaseAllocationSchema = PurchaseAllocationSchema});

            return result;
        }

        // DELETE: api/PurchaseAllocationSchema/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseAllocationSchema>> DeletePurchaseAllocationSchema(int id)
        {

            await _mediator.Send(new DeletePurchaseAllocationSchemaCommand { Id = id});

            return NoContent();
        }


        // GET: api/PurchaseAllocationSchema/5
        [Route("PurchaseAllocationSchemaView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseAllocationSchemaView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseAllocationSchemaListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
