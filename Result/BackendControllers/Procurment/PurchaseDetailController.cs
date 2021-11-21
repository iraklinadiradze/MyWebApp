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
using DataAccessLayer.Model.Procurment;

using Application.Domains.Procurment.PurchaseDetail.Queries.GetPurchaseDetail;
using Application.Domains.Procurment.PurchaseDetail.Queries.GetPurchaseDetailList;
using Application.Domains.Procurment.PurchaseDetail.Commands.CreatePurchaseDetail;
using Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetail;
using Application.Domains.Procurment.PurchaseDetail.Commands.DeletePurchaseDetail;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDetail>> GetPurchaseDetail(int id)
        {
            var PurchaseDetail = await _mediator.Send(new GetPurchaseDetailQuery { Id = id });

            return PurchaseDetail;
        }

        // PUT: api/PurchaseDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseDetail>> PutPurchaseDetail(int id, PurchaseDetail PurchaseDetail)
        {
            if (id != PurchaseDetail.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseDetailCommand { PurchaseDetail = PurchaseDetail});

            return result; //  CreatedAtAction("CreatePurchaseDetail", result); // NoContent();
        }

        // POST: api/PurchaseDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseDetail>> PostPurchaseDetail(PurchaseDetail PurchaseDetail)
        {
            //            _context.PurchaseDetail.Add(PurchaseDetail);
            var result = await _mediator.Send(new CreatePurchaseDetailCommand { PurchaseDetail = PurchaseDetail});

            return result;
        }

        // DELETE: api/PurchaseDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseDetail>> DeletePurchaseDetail(int id)
        {

            await _mediator.Send(new DeletePurchaseDetailCommand { Id = id});

            return NoContent();
        }


        // GET: api/PurchaseDetail/5
        [Route("PurchaseDetailView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseDetailView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseDetailListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
