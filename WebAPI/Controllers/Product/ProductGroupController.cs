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

using Application.Domains.Product.ProductGroup.Queries.GetProductGroup;
using Application.Domains.Product.ProductGroup.Queries.GetProductGroupList;
using Application.Domains.Product.ProductGroup.Commands.CreateProductGroup;
using Application.Domains.Product.ProductGroup.Commands.UpdateProductGroup;
using Application.Domains.Product.ProductGroup.Commands.DeleteProductGroup;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        private IMediator _mediator;

        public ProductGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroup>> GetProductGroup(int id)
        {
            var ProductGroup = await _mediator.Send(new GetProductGroupQuery { Id = id });

            return ProductGroup;
        }

        // PUT: api/ProductGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductGroup>> PutProductGroup(int id, ProductGroup ProductGroup)
        {
            if (id != ProductGroup.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductGroupCommand { ProductGroup = ProductGroup});

            return result; //  CreatedAtAction("CreateProductGroup", result); // NoContent();
        }

        // POST: api/ProductGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductGroup>> PostProductGroup(ProductGroup ProductGroup)
        {
            //            _context.ProductGroup.Add(ProductGroup);
            var result = await _mediator.Send(new CreateProductGroupCommand { ProductGroup = ProductGroup});

            return result;
        }

        // DELETE: api/ProductGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductGroup>> DeleteProductGroup(int id)
        {

            await _mediator.Send(new DeleteProductGroupCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductGroup/5
        [Route("ProductGroupView")]
        [HttpGet]
        public async Task<ActionResult> GetProductGroupView(
            Int32? Id,
Int32? ProductCategoryId,
String ProductGroupName,
Int32? ProductGroupTemplateId
      )
        {
            var result = await _mediator.Send(new GetProductGroupListQuery
            {
                Id = Id,
ProductCategoryId = ProductCategoryId,
ProductGroupName = ProductGroupName,
ProductGroupTemplateId = ProductGroupTemplateId
            }
            );

            return Ok(result.ToList());
        }

    }
}
