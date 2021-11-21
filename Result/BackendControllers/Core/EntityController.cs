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
using DataAccessLayer.Model.Core;

using Application.Domains.Core.Entity.Queries.GetEntity;
using Application.Domains.Core.Entity.Queries.GetEntityList;
using Application.Domains.Core.Entity.Commands.CreateEntity;
using Application.Domains.Core.Entity.Commands.UpdateEntity;
using Application.Domains.Core.Entity.Commands.DeleteEntity;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private IMediator _mediator;

        public EntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Entity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(int id)
        {
            var Entity = await _mediator.Send(new GetEntityQuery { Id = id });

            return Entity;
        }

        // PUT: api/Entity/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Entity>> PutEntity(int id, Entity Entity)
        {
            if (id != Entity.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateEntityCommand { Entity = Entity});

            return result; //  CreatedAtAction("CreateEntity", result); // NoContent();
        }

        // POST: api/Entity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity Entity)
        {
            //            _context.Entity.Add(Entity);
            var result = await _mediator.Send(new CreateEntityCommand { Entity = Entity});

            return result;
        }

        // DELETE: api/Entity/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entity>> DeleteEntity(int id)
        {

            await _mediator.Send(new DeleteEntityCommand { Id = id});

            return NoContent();
        }


        // GET: api/Entity/5
        [Route("EntityView")]
        [HttpGet]
        public async Task<ActionResult> GetEntityView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetEntityListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
