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

using Application.Domains.Product.ProductUnit.Queries.GetProductUnit;
using Application.Domains.Product.ProductUnit.Queries.GetProductUnitList;
using Application.Domains.Product.ProductUnit.Commands.CreateProductUnit;
using Application.Domains.Product.ProductUnit.Commands.UpdateProductUnit;
using Application.Domains.Product.ProductUnit.Commands.DeleteProductUnit;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductUnitController : ControllerBase
    {
        private IMediator _mediator;

        public ProductUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductUnit>> GetProductUnit(int id)
        {
            var ProductUnit = await _mediator.Send(new GetProductUnitQuery { Id = id });

            return ProductUnit;
        }

        // PUT: api/ProductUnit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductUnit>> PutProductUnit(int id, ProductUnit ProductUnit)
        {
            if (id != ProductUnit.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductUnitCommand { ProductUnit = ProductUnit});

            return result; //  CreatedAtAction("CreateProductUnit", result); // NoContent();
        }

        // POST: api/ProductUnit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductUnit>> PostProductUnit(ProductUnit ProductUnit)
        {
            //            _context.ProductUnit.Add(ProductUnit);
            var result = await _mediator.Send(new CreateProductUnitCommand { ProductUnit = ProductUnit});

            return result;
        }

        // DELETE: api/ProductUnit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductUnit>> DeleteProductUnit(int id)
        {

            await _mediator.Send(new DeleteProductUnitCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductUnit/5
        [Route("ProductUnitView")]
        [HttpGet]
        public async Task<ActionResult> GetProductUnitView(
            Int32? Id,
String ProductUnitName
      )
        {
            var result = await _mediator.Send(new GetProductUnitListQuery
            {
                Id = Id,
ProductUnitName = ProductUnitName
            }
            );

            return Ok(result.ToList());
        }

    }
}
