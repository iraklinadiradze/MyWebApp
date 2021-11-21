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
using DataAccessLayer.Model.Client;

using Application.Domains.Client.Client.Queries.GetClient;
using Application.Domains.Client.Client.Queries.GetClientList;
using Application.Domains.Client.Client.Commands.CreateClient;
using Application.Domains.Client.Client.Commands.UpdateClient;
using Application.Domains.Client.Client.Commands.DeleteClient;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var Client = await _mediator.Send(new GetClientQuery { Id = id });

            return Client;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> PutClient(int id, Client Client)
        {
            if (id != Client.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateClientCommand { Client = Client });

            return result; //  CreatedAtAction("CreateClient", result); // NoContent();
        }

        // POST: api/Client
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client Client)
        {
            //            _context.Client.Add(Client);
            var result = await _mediator.Send(new CreateClientCommand { Client = Client });

            return result;
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {

            await _mediator.Send(new DeleteClientCommand { Id = id });

            return NoContent();
        }


        // GET: api/Client/5
        [Route("ClientView")]
        [HttpGet]
        public async Task<ActionResult> GetClientView(
            Int32? Id,
String Name
      )
        {
            var result = await _mediator.Send(new GetClientListQuery
            {
                Id = Id,
                Name = Name
            }
            );

            return Ok(result.ToList());
        }

    }
}
