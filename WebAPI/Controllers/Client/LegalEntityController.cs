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

using Application.Domains.Client.LegalEntity.Queries.GetLegalEntity;
using Application.Domains.Client.LegalEntity.Queries.GetLegalEntityList;
using Application.Domains.Client.LegalEntity.Commands.CreateLegalEntity;
using Application.Domains.Client.LegalEntity.Commands.UpdateLegalEntity;
using Application.Domains.Client.LegalEntity.Commands.DeleteLegalEntity;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LegalEntityController : ControllerBase
    {
        private IMediator _mediator;

        public LegalEntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/LegalEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalEntity>> GetLegalEntity(int id)
        {
            var LegalEntity = await _mediator.Send(new GetLegalEntityQuery { Id = id });

            return LegalEntity;
        }

        // PUT: api/LegalEntity/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<LegalEntity>> PutLegalEntity(int id, LegalEntity LegalEntity)
        {
            if (id != LegalEntity.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateLegalEntityCommand { LegalEntity = LegalEntity});

            return result; //  CreatedAtAction("CreateLegalEntity", result); // NoContent();
        }

        // POST: api/LegalEntity
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LegalEntity>> PostLegalEntity(LegalEntity LegalEntity)
        {
            //            _context.LegalEntity.Add(LegalEntity);
            var result = await _mediator.Send(new CreateLegalEntityCommand { LegalEntity = LegalEntity});

            return result;
        }

        // DELETE: api/LegalEntity/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegalEntity>> DeleteLegalEntity(int id)
        {

            await _mediator.Send(new DeleteLegalEntityCommand { Id = id});

            return NoContent();
        }


        // GET: api/LegalEntity/5
        [Route("LegalEntityView")]
        [HttpGet]
        public async Task<ActionResult> GetLegalEntityView(
            Int32? Id,
String LegalEntityName,
Int32? RegistrationCountryID,
String TaxCode
      )
        {
            var result = await _mediator.Send(new GetLegalEntityListQuery
            {
                Id = Id,
LegalEntityName = LegalEntityName,
RegistrationCountryID = RegistrationCountryID,
TaxCode = TaxCode
            }
            );

            return Ok(result.ToList());
        }

    }
}
