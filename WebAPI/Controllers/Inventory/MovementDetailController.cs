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
using DataAccessLayer.Model.Inventory;

using Application.Domains.Inventory.MovementDetail.Queries.GetMovementDetail;
using Application.Domains.Inventory.MovementDetail.Queries.GetMovementDetailList;
using Application.Domains.Inventory.MovementDetail.Commands.CreateMovementDetail;
using Application.Domains.Inventory.MovementDetail.Commands.UpdateMovementDetail;
using Application.Domains.Inventory.MovementDetail.Commands.DeleteMovementDetail;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovementDetailController : ControllerBase
    {
        private IMediator _mediator;

        public MovementDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/MovementDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovementDetail>> GetMovementDetail(int id)
        {
            var MovementDetail = await _mediator.Send(new GetMovementDetailQuery { Id = id });

            return MovementDetail;
        }

        // PUT: api/MovementDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<MovementDetail>> PutMovementDetail(int id, MovementDetail MovementDetail)
        {
            if (id != MovementDetail.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateMovementDetailCommand { MovementDetail = MovementDetail});

            return result; //  CreatedAtAction("CreateMovementDetail", result); // NoContent();
        }

        // POST: api/MovementDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovementDetail>> PostMovementDetail(MovementDetail MovementDetail)
        {
            //            _context.MovementDetail.Add(MovementDetail);
            var result = await _mediator.Send(new CreateMovementDetailCommand { MovementDetail = MovementDetail});

            return result;
        }

        // DELETE: api/MovementDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovementDetail>> DeleteMovementDetail(int id)
        {

            await _mediator.Send(new DeleteMovementDetailCommand { Id = id});

            return NoContent();
        }


        // GET: api/MovementDetail/5
        [Route("MovementDetailView")]
        [HttpGet]
        public async Task<ActionResult> GetMovementDetailView(
            Int32? Id,
Int32? InventoryId,
Int32? MovementId
      )
        {
            var result = await _mediator.Send(new GetMovementDetailListQuery
            {
                Id = Id,
InventoryId = InventoryId,
MovementId = MovementId
            }
            );

            return Ok(result.ToList());
        }

    }
}
