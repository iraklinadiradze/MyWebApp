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

using Application.Domains.Core.Country.Queries.GetCountry;
using Application.Domains.Core.Country.Queries.GetCountryList;
using Application.Domains.Core.Country.Commands.CreateCountry;
using Application.Domains.Core.Country.Commands.UpdateCountry;
using Application.Domains.Core.Country.Commands.DeleteCountry;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var Country = await _mediator.Send(new GetCountryQuery { Id = id });

            return Country;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> PutCountry(int id, Country Country)
        {
            if (id != Country.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateCountryCommand { Country = Country});

            return result; //  CreatedAtAction("CreateCountry", result); // NoContent();
        }

        // POST: api/Country
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country Country)
        {
            //            _context.Country.Add(Country);
            var result = await _mediator.Send(new CreateCountryCommand { Country = Country});

            return result;
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {

            await _mediator.Send(new DeleteCountryCommand { Id = id});

            return NoContent();
        }


        // GET: api/Country/5
        [Route("CountryView")]
        [HttpGet]
        public async Task<ActionResult> GetCountryView(
            Int32? Id,
String Code,
String Name
      )
        {
            var result = await _mediator.Send(new GetCountryListQuery
            {
                Id = Id,
Code = Code,
Name = Name
            }
            );

            return Ok(result.ToList());
        }

    }
}
