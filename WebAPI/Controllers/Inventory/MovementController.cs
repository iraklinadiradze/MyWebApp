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

using Application.Domains.Inventory.Movement.Queries.GetMovement;
using Application.Domains.Inventory.Movement.Queries.GetMovementList;
using Application.Domains.Inventory.Movement.Commands.CreateMovement;
using Application.Domains.Inventory.Movement.Commands.UpdateMovement;
using Application.Domains.Inventory.Movement.Commands.DeleteMovement;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private IMediator _mediator;

        public MovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Movement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movement>> GetMovement(int id)
        {
            var Movement = await _mediator.Send(new GetMovementQuery { Id = id });

            return Movement;
        }

        // PUT: api/Movement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Movement>> PutMovement(int id, Movement Movement)
        {
            if (id != Movement.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateMovementCommand { Movement = Movement});

            return result; //  CreatedAtAction("CreateMovement", result); // NoContent();
        }

        // POST: api/Movement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movement>> PostMovement(Movement Movement)
        {
            //            _context.Movement.Add(Movement);
            var result = await _mediator.Send(new CreateMovementCommand { Movement = Movement});

            return result;
        }

        // DELETE: api/Movement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movement>> DeleteMovement(int id)
        {

            await _mediator.Send(new DeleteMovementCommand { Id = id});

            return NoContent();
        }


        // GET: api/Movement/5
        [Route("MovementView")]
        [HttpGet]
        public async Task<ActionResult> GetMovementView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetMovementListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
