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
using DataAccessLayer.Model.GeneralLedger;

using Application.Domains.GeneralLedger.GlTransactionDetail.Queries.GetGlTransactionDetail;
using Application.Domains.GeneralLedger.GlTransactionDetail.Queries.GetGlTransactionDetailList;
using Application.Domains.GeneralLedger.GlTransactionDetail.Commands.CreateGlTransactionDetail;
using Application.Domains.GeneralLedger.GlTransactionDetail.Commands.UpdateGlTransactionDetail;
using Application.Domains.GeneralLedger.GlTransactionDetail.Commands.DeleteGlTransactionDetail;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GlTransactionDetailController : ControllerBase
    {
        private IMediator _mediator;

        public GlTransactionDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GlTransactionDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GlTransactionDetail>> GetGlTransactionDetail(int id)
        {
            var GlTransactionDetail = await _mediator.Send(new GetGlTransactionDetailQuery { Id = id });

            return GlTransactionDetail;
        }

        // PUT: api/GlTransactionDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<GlTransactionDetail>> PutGlTransactionDetail(int id, GlTransactionDetail GlTransactionDetail)
        {
            if (id != GlTransactionDetail.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateGlTransactionDetailCommand { GlTransactionDetail = GlTransactionDetail});

            return result; //  CreatedAtAction("CreateGlTransactionDetail", result); // NoContent();
        }

        // POST: api/GlTransactionDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GlTransactionDetail>> PostGlTransactionDetail(GlTransactionDetail GlTransactionDetail)
        {
            //            _context.GlTransactionDetail.Add(GlTransactionDetail);
            var result = await _mediator.Send(new CreateGlTransactionDetailCommand { GlTransactionDetail = GlTransactionDetail});

            return result;
        }

        // DELETE: api/GlTransactionDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GlTransactionDetail>> DeleteGlTransactionDetail(int id)
        {

            await _mediator.Send(new DeleteGlTransactionDetailCommand { Id = id});

            return NoContent();
        }


        // GET: api/GlTransactionDetail/5
        [Route("GlTransactionDetailView")]
        [HttpGet]
        public async Task<ActionResult> GetGlTransactionDetailView(
            Int64? Id
      )
        {
            var result = await _mediator.Send(new GetGlTransactionDetailListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
