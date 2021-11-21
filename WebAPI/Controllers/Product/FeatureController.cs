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

using Application.Domains.Product.Feature.Queries.GetFeature;
using Application.Domains.Product.Feature.Queries.GetFeatureList;
using Application.Domains.Product.Feature.Commands.CreateFeature;
using Application.Domains.Product.Feature.Commands.UpdateFeature;
using Application.Domains.Product.Feature.Commands.DeleteFeature;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Feature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
            var Feature = await _mediator.Send(new GetFeatureQuery { Id = id });

            return Feature;
        }

        // PUT: api/Feature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Feature>> PutFeature(int id, Feature Feature)
        {
            if (id != Feature.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateFeatureCommand { Feature = Feature});

            return result; //  CreatedAtAction("CreateFeature", result); // NoContent();
        }

        // POST: api/Feature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature Feature)
        {
            //            _context.Feature.Add(Feature);
            var result = await _mediator.Send(new CreateFeatureCommand { Feature = Feature});

            return result;
        }

        // DELETE: api/Feature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feature>> DeleteFeature(int id)
        {

            await _mediator.Send(new DeleteFeatureCommand { Id = id});

            return NoContent();
        }


        // GET: api/Feature/5
        [Route("FeatureView")]
        [HttpGet]
        public async Task<ActionResult> GetFeatureView(
            Int32? Id,
String FeatureName
      )
        {
            var result = await _mediator.Send(new GetFeatureListQuery
            {
                Id = Id,
FeatureName = FeatureName
            }
            );

            return Ok(result.ToList());
        }

    }
}
