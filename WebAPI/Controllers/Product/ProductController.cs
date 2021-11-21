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

using Application.Domains.Product.Product.Queries.GetProduct;
using Application.Domains.Product.Product.Queries.GetProductList;
using Application.Domains.Product.Product.Commands.CreateProduct;
using Application.Domains.Product.Product.Commands.UpdateProduct;
using Application.Domains.Product.Product.Commands.DeleteProduct;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _mediator.Send(new GetProductQuery { Id = id });

            return Product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductCommand { Product = Product});

            return result; //  CreatedAtAction("CreateProduct", result); // NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            //            _context.Product.Add(Product);
            var result = await _mediator.Send(new CreateProductCommand { Product = Product});

            return result;
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {

            await _mediator.Send(new DeleteProductCommand { Id = id});

            return NoContent();
        }


        // GET: api/Product/5
        [Route("ProductView")]
        [HttpGet]
        public async Task<ActionResult> GetProductView(
            Int32? Id,
String ProductCode,
Int32? ProductGroupId,
Int32? ProductLabelId,
String ProductName,
Int32? ProductUnitId
      )
        {
            var result = await _mediator.Send(new GetProductListQuery
            {
                Id = Id,
ProductCode = ProductCode,
ProductGroupId = ProductGroupId,
ProductLabelId = ProductLabelId,
ProductName = ProductName,
ProductUnitId = ProductUnitId
            }
            );

            return Ok(result.ToList());
        }

    }
}
