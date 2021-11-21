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

using Application.Domains.Core.Currency.Queries.GetCurrency;
using Application.Domains.Core.Currency.Queries.GetCurrencyList;
using Application.Domains.Core.Currency.Commands.CreateCurrency;
using Application.Domains.Core.Currency.Commands.UpdateCurrency;
using Application.Domains.Core.Currency.Commands.DeleteCurrency;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private IMediator _mediator;

        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Currency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var Currency = await _mediator.Send(new GetCurrencyQuery { Id = id });

            return Currency;
        }

        // PUT: api/Currency/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Currency>> PutCurrency(int id, Currency Currency)
        {
            if (id != Currency.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateCurrencyCommand { Currency = Currency});

            return result; //  CreatedAtAction("CreateCurrency", result); // NoContent();
        }

        // POST: api/Currency
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency Currency)
        {
            //            _context.Currency.Add(Currency);
            var result = await _mediator.Send(new CreateCurrencyCommand { Currency = Currency});

            return result;
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Currency>> DeleteCurrency(int id)
        {

            await _mediator.Send(new DeleteCurrencyCommand { Id = id});

            return NoContent();
        }


        // GET: api/Currency/5
        [Route("CurrencyView")]
        [HttpGet]
        public async Task<ActionResult> GetCurrencyView(
            Int32? Id,
String CurrencyCode
      )
        {
            var result = await _mediator.Send(new GetCurrencyListQuery
            {
                Id = Id,
CurrencyCode = CurrencyCode
            }
            );

            return Ok(result.ToList());
        }

    }
}
