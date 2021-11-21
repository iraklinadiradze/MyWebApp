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

using Application.Domains.Procurment.PurchaseDetailPostType.Queries.GetPurchaseDetailPostType;
using Application.Domains.Procurment.PurchaseDetailPostType.Queries.GetPurchaseDetailPostTypeList;
using Application.Domains.Procurment.PurchaseDetailPostType.Commands.CreatePurchaseDetailPostType;
using Application.Domains.Procurment.PurchaseDetailPostType.Commands.UpdatePurchaseDetailPostType;
using Application.Domains.Procurment.PurchaseDetailPostType.Commands.DeletePurchaseDetailPostType;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailPostTypeController : ControllerBase
    {
        private IMediator _mediator;

        public PurchaseDetailPostTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/PurchaseDetailPostType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDetailPostType>> GetPurchaseDetailPostType(int id)
        {
            var PurchaseDetailPostType = await _mediator.Send(new GetPurchaseDetailPostTypeQuery { Id = id });

            return PurchaseDetailPostType;
        }

        // PUT: api/PurchaseDetailPostType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseDetailPostType>> PutPurchaseDetailPostType(int id, PurchaseDetailPostType PurchaseDetailPostType)
        {
            if (id != PurchaseDetailPostType.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdatePurchaseDetailPostTypeCommand { PurchaseDetailPostType = PurchaseDetailPostType});

            return result; //  CreatedAtAction("CreatePurchaseDetailPostType", result); // NoContent();
        }

        // POST: api/PurchaseDetailPostType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseDetailPostType>> PostPurchaseDetailPostType(PurchaseDetailPostType PurchaseDetailPostType)
        {
            //            _context.PurchaseDetailPostType.Add(PurchaseDetailPostType);
            var result = await _mediator.Send(new CreatePurchaseDetailPostTypeCommand { PurchaseDetailPostType = PurchaseDetailPostType});

            return result;
        }

        // DELETE: api/PurchaseDetailPostType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseDetailPostType>> DeletePurchaseDetailPostType(int id)
        {

            await _mediator.Send(new DeletePurchaseDetailPostTypeCommand { Id = id});

            return NoContent();
        }


        // GET: api/PurchaseDetailPostType/5
        [Route("PurchaseDetailPostTypeView")]
        [HttpGet]
        public async Task<ActionResult> GetPurchaseDetailPostTypeView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetPurchaseDetailPostTypeListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
