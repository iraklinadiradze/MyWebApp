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

using Application.Domains.Client.Person.Queries.GetPerson;
using Application.Domains.Client.Person.Queries.GetPersonList;
using Application.Domains.Client.Person.Commands.CreatePerson;
using Application.Domains.Client.Person.Commands.UpdatePerson;
using Application.Domains.Client.Person.Commands.DeletePerson;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var Person = await _mediator.Send(new GetPersonQuery { Id = id });

            return Person;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> PutPerson(int id, Person Person)
        {
            if (id != Person.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePersonCommand { Person = Person});

            return result; //  CreatedAtAction("CreatePerson", result); // NoContent();
        }

        // POST: api/Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person Person)
        {
            //            _context.Person.Add(Person);
            var result = await _mediator.Send(new CreatePersonCommand { Person = Person});

            return result;
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {

            await _mediator.Send(new DeletePersonCommand { Id = id});

            return NoContent();
        }


        // GET: api/Person/5
        [Route("PersonView")]
        [HttpGet]
        public async Task<ActionResult> GetPersonView(
            Int32? Id,
DateTime? BirthDate_from,
DateTime? BirthDate_to,
Int32? CitizenShipId,
String FirstName,
String LastName,
String PersonalId
      )
        {
            var result = await _mediator.Send(new GetPersonListQuery
            {
                Id = Id,
BirthDate_from = BirthDate_from,
BirthDate_to = BirthDate_to,
CitizenShipId = CitizenShipId,
FirstName = FirstName,
LastName = LastName,
PersonalId = PersonalId
            }
            );

            return Ok(result.ToList());
        }

    }
}
