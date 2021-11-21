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

using Application.Domains.Product.ProductCategory.Queries.GetProductCategory;
using Application.Domains.Product.ProductCategory.Queries.GetProductCategoryList;
using Application.Domains.Product.ProductCategory.Commands.CreateProductCategory;
using Application.Domains.Product.ProductCategory.Commands.UpdateProductCategory;
using Application.Domains.Product.ProductCategory.Commands.DeleteProductCategory;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var ProductCategory = await _mediator.Send(new GetProductCategoryQuery { Id = id });

            return ProductCategory;
        }

        // PUT: api/ProductCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> PutProductCategory(int id, ProductCategory ProductCategory)
        {
            if (id != ProductCategory.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductCategoryCommand { ProductCategory = ProductCategory});

            return result; //  CreatedAtAction("CreateProductCategory", result); // NoContent();
        }

        // POST: api/ProductCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory ProductCategory)
        {
            //            _context.ProductCategory.Add(ProductCategory);
            var result = await _mediator.Send(new CreateProductCategoryCommand { ProductCategory = ProductCategory});

            return result;
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory(int id)
        {

            await _mediator.Send(new DeleteProductCategoryCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductCategory/5
        [Route("ProductCategoryView")]
        [HttpGet]
        public async Task<ActionResult> GetProductCategoryView(
            Int32? Id,
String ProductCategoryName
      )
        {
            var result = await _mediator.Send(new GetProductCategoryListQuery
            {
                Id = Id,
ProductCategoryName = ProductCategoryName
            }
            );

            return Ok(result.ToList());
        }

    }
}
