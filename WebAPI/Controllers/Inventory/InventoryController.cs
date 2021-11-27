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

using Application.Domains.Inventory.Inventory.Queries.GetInventory;
using Application.Domains.Inventory.Inventory.Queries.GetInventoryList;
using Application.Domains.Inventory.Inventory.Commands.ChangeInventoryStock;
using Application.Domains.Inventory.Inventory.Commands.UpdateInventory;
using Application.Domains.Inventory.Inventory.Commands.DeleteInventory;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            var Inventory = await _mediator.Send(new GetInventoryQuery { Id = id });

            return Inventory;
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Inventory>> PutInventory(int id, Inventory Inventory)
        {
            if (id != Inventory.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateInventoryCommand { Inventory = Inventory});

            return result; //  CreatedAtAction("CreateInventory", result); // NoContent();
        }

        // POST: api/Inventory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory Inventory)
        {
            //            _context.Inventory.Add(Inventory);
            var result = await _mediator.Send(new CreateInventoryCommand { Inventory = Inventory});

            return result;
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventory>> DeleteInventory(int id)
        {

            await _mediator.Send(new DeleteInventoryCommand { Id = id});

            return NoContent();
        }


        // GET: api/Inventory/5
        [Route("InventoryView")]
        [HttpGet]
        public async Task<ActionResult> GetInventoryView(
            Int32? Id,
String InventoryCode
      )
        {
            var result = await _mediator.Send(new GetInventoryListQuery
            {
                Id = Id,
InventoryCode = InventoryCode
            }
            );

            return Ok(result.ToList());
        }

    }
}
