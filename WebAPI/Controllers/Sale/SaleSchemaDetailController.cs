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

using Application.Domains.Sale.SaleSchemaDetail.Queries.GetSaleSchemaDetail;
using Application.Domains.Sale.SaleSchemaDetail.Queries.GetSaleSchemaDetailList;
using Application.Domains.Sale.SaleSchemaDetail.Commands.CreateSaleSchemaDetail;
using Application.Domains.Sale.SaleSchemaDetail.Commands.UpdateSaleSchemaDetail;
using Application.Domains.Sale.SaleSchemaDetail.Commands.DeleteSaleSchemaDetail;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleSchemaDetailController : ControllerBase
    {
        private IMediator _mediator;

        public SaleSchemaDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/SaleSchemaDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleSchemaDetail>> GetSaleSchemaDetail(int id)
        {
            var SaleSchemaDetail = await _mediator.Send(new GetSaleSchemaDetailQuery { Id = id });

            return SaleSchemaDetail;
        }

        // PUT: api/SaleSchemaDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SaleSchemaDetail>> PutSaleSchemaDetail(int id, SaleSchemaDetail SaleSchemaDetail)
        {
            if (id != SaleSchemaDetail.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateSaleSchemaDetailCommand { SaleSchemaDetail = SaleSchemaDetail});

            return result; //  CreatedAtAction("CreateSaleSchemaDetail", result); // NoContent();
        }

        // POST: api/SaleSchemaDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SaleSchemaDetail>> PostSaleSchemaDetail(SaleSchemaDetail SaleSchemaDetail)
        {
            //            _context.SaleSchemaDetail.Add(SaleSchemaDetail);
            var result = await _mediator.Send(new CreateSaleSchemaDetailCommand { SaleSchemaDetail = SaleSchemaDetail});

            return result;
        }

        // DELETE: api/SaleSchemaDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaleSchemaDetail>> DeleteSaleSchemaDetail(int id)
        {

            await _mediator.Send(new DeleteSaleSchemaDetailCommand { Id = id});

            return NoContent();
        }


        // GET: api/SaleSchemaDetail/5
        [Route("SaleSchemaDetailView")]
        [HttpGet]
        public async Task<ActionResult> GetSaleSchemaDetailView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetSaleSchemaDetailListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
