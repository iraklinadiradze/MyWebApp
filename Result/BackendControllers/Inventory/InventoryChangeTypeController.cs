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

using Application.Domains.Inventory.InventoryChangeType.Queries.GetInventoryChangeType;
using Application.Domains.Inventory.InventoryChangeType.Queries.GetInventoryChangeTypeList;
using Application.Domains.Inventory.InventoryChangeType.Commands.CreateInventoryChangeType;
using Application.Domains.Inventory.InventoryChangeType.Commands.UpdateInventoryChangeType;
using Application.Domains.Inventory.InventoryChangeType.Commands.DeleteInventoryChangeType;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryChangeTypeController : ControllerBase
    {
        private IMediator _mediator;

        public InventoryChangeTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/InventoryChangeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryChangeType>> GetInventoryChangeType(int id)
        {
            var InventoryChangeType = await _mediator.Send(new GetInventoryChangeTypeQuery { Id = id });

            return InventoryChangeType;
        }

        // PUT: api/InventoryChangeType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<InventoryChangeType>> PutInventoryChangeType(int id, InventoryChangeType InventoryChangeType)
        {
            if (id != InventoryChangeType.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateInventoryChangeTypeCommand { InventoryChangeType = InventoryChangeType});

            return result; //  CreatedAtAction("CreateInventoryChangeType", result); // NoContent();
        }

        // POST: api/InventoryChangeType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InventoryChangeType>> PostInventoryChangeType(InventoryChangeType InventoryChangeType)
        {
            //            _context.InventoryChangeType.Add(InventoryChangeType);
            var result = await _mediator.Send(new CreateInventoryChangeTypeCommand { InventoryChangeType = InventoryChangeType});

            return result;
        }

        // DELETE: api/InventoryChangeType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryChangeType>> DeleteInventoryChangeType(int id)
        {

            await _mediator.Send(new DeleteInventoryChangeTypeCommand { Id = id});

            return NoContent();
        }


        // GET: api/InventoryChangeType/5
        [Route("InventoryChangeTypeView")]
        [HttpGet]
        public async Task<ActionResult> GetInventoryChangeTypeView(
            Int32? Id,
String ChangeName
      )
        {
            var result = await _mediator.Send(new GetInventoryChangeTypeListQuery
            {
                Id = Id,
ChangeName = ChangeName
            }
            );

            return Ok(result.ToList());
        }

    }
}
