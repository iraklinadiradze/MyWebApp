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
using DataAccessLayer.Model.Sale;

using Application.Domains.Sale.SaleSchema.Queries.GetSaleSchema;
using Application.Domains.Sale.SaleSchema.Queries.GetSaleSchemaList;
using Application.Domains.Sale.SaleSchema.Commands.CreateSaleSchema;
using Application.Domains.Sale.SaleSchema.Commands.UpdateSaleSchema;
using Application.Domains.Sale.SaleSchema.Commands.DeleteSaleSchema;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleSchemaController : ControllerBase
    {
        private IMediator _mediator;

        public SaleSchemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/SaleSchema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleSchema>> GetSaleSchema(int id)
        {
            var SaleSchema = await _mediator.Send(new GetSaleSchemaQuery { Id = id });

            return SaleSchema;
        }

        // PUT: api/SaleSchema/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SaleSchema>> PutSaleSchema(int id, SaleSchema SaleSchema)
        {
            if (id != SaleSchema.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateSaleSchemaCommand { SaleSchema = SaleSchema});

            return result; //  CreatedAtAction("CreateSaleSchema", result); // NoContent();
        }

        // POST: api/SaleSchema
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaleSchema>> PostSaleSchema(SaleSchema SaleSchema)
        {
            //            _context.SaleSchema.Add(SaleSchema);
            var result = await _mediator.Send(new CreateSaleSchemaCommand { SaleSchema = SaleSchema});

            return result;
        }

        // DELETE: api/SaleSchema/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaleSchema>> DeleteSaleSchema(int id)
        {

            await _mediator.Send(new DeleteSaleSchemaCommand { Id = id});

            return NoContent();
        }


        // GET: api/SaleSchema/5
        [Route("SaleSchemaView")]
        [HttpGet]
        public async Task<ActionResult> GetSaleSchemaView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetSaleSchemaListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
