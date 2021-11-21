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
using DataAccessLayer.Model.Product;

using Application.Domains.Product.FeatureValue.Queries.GetFeatureValue;
using Application.Domains.Product.FeatureValue.Queries.GetFeatureValueList;
using Application.Domains.Product.FeatureValue.Commands.CreateFeatureValue;
using Application.Domains.Product.FeatureValue.Commands.UpdateFeatureValue;
using Application.Domains.Product.FeatureValue.Commands.DeleteFeatureValue;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureValueController : ControllerBase
    {
        private IMediator _mediator;

        public FeatureValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/FeatureValue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureValue>> GetFeatureValue(int id)
        {
            var FeatureValue = await _mediator.Send(new GetFeatureValueQuery { Id = id });

            return FeatureValue;
        }

        // PUT: api/FeatureValue/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<FeatureValue>> PutFeatureValue(int id, FeatureValue FeatureValue)
        {
            if (id != FeatureValue.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateFeatureValueCommand { FeatureValue = FeatureValue});

            return result; //  CreatedAtAction("CreateFeatureValue", result); // NoContent();
        }

        // POST: api/FeatureValue
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FeatureValue>> PostFeatureValue(FeatureValue FeatureValue)
        {
            //            _context.FeatureValue.Add(FeatureValue);
            var result = await _mediator.Send(new CreateFeatureValueCommand { FeatureValue = FeatureValue});

            return result;
        }

        // DELETE: api/FeatureValue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeatureValue>> DeleteFeatureValue(int id)
        {

            await _mediator.Send(new DeleteFeatureValueCommand { Id = id});

            return NoContent();
        }


        // GET: api/FeatureValue/5
        [Route("FeatureValueView")]
        [HttpGet]
        public async Task<ActionResult> GetFeatureValueView(
            Int32? Id,
Int32? FeatureId,
String FeatureValueName
      )
        {
            var result = await _mediator.Send(new GetFeatureValueListQuery
            {
                Id = Id,
FeatureId = FeatureId,
FeatureValueName = FeatureValueName
            }
            );

            return Ok(result.ToList());
        }

    }
}
