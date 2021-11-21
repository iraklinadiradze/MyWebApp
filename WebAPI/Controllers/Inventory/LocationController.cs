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

using Application.Domains.Inventory.Location.Queries.GetLocation;
using Application.Domains.Inventory.Location.Queries.GetLocationList;
using Application.Domains.Inventory.Location.Commands.CreateLocation;
using Application.Domains.Inventory.Location.Commands.UpdateLocation;
using Application.Domains.Inventory.Location.Commands.DeleteLocation;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var Location = await _mediator.Send(new GetLocationQuery { Id = id });

            return Location;
        }

        // PUT: api/Location/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Location>> PutLocation(int id, Location Location)
        {
            if (id != Location.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateLocationCommand { Location = Location});

            return result; //  CreatedAtAction("CreateLocation", result); // NoContent();
        }

        // POST: api/Location
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location Location)
        {
            //            _context.Location.Add(Location);
            var result = await _mediator.Send(new CreateLocationCommand { Location = Location});

            return result;
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Location>> DeleteLocation(int id)
        {

            await _mediator.Send(new DeleteLocationCommand { Id = id});

            return NoContent();
        }


        // GET: api/Location/5
        [Route("LocationView")]
        [HttpGet]
        public async Task<ActionResult> GetLocationView(
            Int32? Id,
String Name
      )
        {
            var result = await _mediator.Send(new GetLocationListQuery
            {
                Id = Id,
Name = Name
            }
            );

            return Ok(result.ToList());
        }

    }
}
