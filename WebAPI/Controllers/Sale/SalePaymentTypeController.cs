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

using Application.Domains.Sale.SalePaymentType.Queries.GetSalePaymentType;
using Application.Domains.Sale.SalePaymentType.Queries.GetSalePaymentTypeList;
using Application.Domains.Sale.SalePaymentType.Commands.CreateSalePaymentType;
using Application.Domains.Sale.SalePaymentType.Commands.UpdateSalePaymentType;
using Application.Domains.Sale.SalePaymentType.Commands.DeleteSalePaymentType;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalePaymentTypeController : ControllerBase
    {
        private IMediator _mediator;

        public SalePaymentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/SalePaymentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalePaymentType>> GetSalePaymentType(int id)
        {
            var SalePaymentType = await _mediator.Send(new GetSalePaymentTypeQuery { Id = id });

            return SalePaymentType;
        }

        // PUT: api/SalePaymentType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SalePaymentType>> PutSalePaymentType(int id, SalePaymentType SalePaymentType)
        {
            if (id != SalePaymentType.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateSalePaymentTypeCommand { SalePaymentType = SalePaymentType});

            return result; //  CreatedAtAction("CreateSalePaymentType", result); // NoContent();
        }

        // POST: api/SalePaymentType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalePaymentType>> PostSalePaymentType(SalePaymentType SalePaymentType)
        {
            //            _context.SalePaymentType.Add(SalePaymentType);
            var result = await _mediator.Send(new CreateSalePaymentTypeCommand { SalePaymentType = SalePaymentType});

            return result;
        }

        // DELETE: api/SalePaymentType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalePaymentType>> DeleteSalePaymentType(int id)
        {

            await _mediator.Send(new DeleteSalePaymentTypeCommand { Id = id});

            return NoContent();
        }


        // GET: api/SalePaymentType/5
        [Route("SalePaymentTypeView")]
        [HttpGet]
        public async Task<ActionResult> GetSalePaymentTypeView(
            Int32? Id
      )
        {
            var result = await _mediator.Send(new GetSalePaymentTypeListQuery
            {
                Id = Id
            }
            );

            return Ok(result.ToList());
        }

    }
}
