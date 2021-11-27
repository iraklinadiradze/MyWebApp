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

using Application.Domains.Inventory.InventoryChange.Queries.GetInventoryChange;
using Application.Domains.Inventory.InventoryChange.Queries.GetInventoryChangeList;
using Application.Domains.Inventory.InventoryChange.Commands.CreateInventoryChange;
using Application.Domains.Inventory.InventoryChange.Commands.UpdateInventoryChange;
using Application.Domains.Inventory.InventoryChange.Commands.DeleteInventoryChange;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryChangeController : ControllerBase
    {
        private IMediator _mediator;

        public InventoryChangeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/InventoryChange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryChange>> GetInventoryChange(int id)
        {
            var InventoryChange = await _mediator.Send(new GetInventoryChangeQuery { Id = id });

            return InventoryChange;
        }

        // PUT: api/InventoryChange/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<InventoryChange>> PutInventoryChange(int id, InventoryChange InventoryChange)
        {
            if (id != InventoryChange.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateInventoryChangeCommand { InventoryChange = InventoryChange});

            return result; //  CreatedAtAction("CreateInventoryChange", result); // NoContent();
        }

        // POST: api/InventoryChange
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InventoryChange>> PostInventoryChange(InventoryChange InventoryChange)
        {
            //            _context.InventoryChange.Add(InventoryChange);
            var result = await _mediator.Send(new CreateInventoryChangeCommand { InventoryChange = InventoryChange});

            return result;
        }

        // DELETE: api/InventoryChange/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryChange>> DeleteInventoryChange(int id)
        {

            await _mediator.Send(new DeleteInventoryChangeCommand { Id = id});

            return NoContent();
        }


        // GET: api/InventoryChange/5
        [Route("InventoryChangeView")]
        [HttpGet]
        public async Task<ActionResult> GetInventoryChangeView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetInventoryChangeListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
