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

using Application.Domains.Product.ProductGroupTemplate.Queries.GetProductGroupTemplate;
using Application.Domains.Product.ProductGroupTemplate.Queries.GetProductGroupTemplateList;
using Application.Domains.Product.ProductGroupTemplate.Commands.CreateProductGroupTemplate;
using Application.Domains.Product.ProductGroupTemplate.Commands.UpdateProductGroupTemplate;
using Application.Domains.Product.ProductGroupTemplate.Commands.DeleteProductGroupTemplate;

namespace WebAPI.Controllers
{
    //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupTemplateController : ControllerBase
    {
        private IMediator _mediator;

        public ProductGroupTemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProductGroupTemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupTemplate>> GetProductGroupTemplate(int id)
        {
            var ProductGroupTemplate = await _mediator.Send(new GetProductGroupTemplateQuery { Id = id });

            return ProductGroupTemplate;
        }

        // PUT: api/ProductGroupTemplate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductGroupTemplate>> PutProductGroupTemplate(int id, ProductGroupTemplate ProductGroupTemplate)
        {
            if (id != ProductGroupTemplate.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductGroupTemplateCommand { ProductGroupTemplate = ProductGroupTemplate});

            return result; //  CreatedAtAction("CreateProductGroupTemplate", result); // NoContent();
        }

        // POST: api/ProductGroupTemplate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductGroupTemplate>> PostProductGroupTemplate(ProductGroupTemplate ProductGroupTemplate)
        {
            //            _context.ProductGroupTemplate.Add(ProductGroupTemplate);
            var result = await _mediator.Send(new CreateProductGroupTemplateCommand { ProductGroupTemplate = ProductGroupTemplate});

            return result;
        }

        // DELETE: api/ProductGroupTemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductGroupTemplate>> DeleteProductGroupTemplate(int id)
        {

            await _mediator.Send(new DeleteProductGroupTemplateCommand { Id = id});

            return NoContent();
        }


        // GET: api/ProductGroupTemplate/5
        [Route("ProductGroupTemplateView")]
        [HttpGet]
        public async Task<ActionResult> GetProductGroupTemplateView(
            Int32? Id,
String ProductGroupTemplateName,
Int32? ProductUnitId
      )
        {
            var result = await _mediator.Send(new GetProductGroupTemplateListQuery
            {
                Id = Id,
ProductGroupTemplateName = ProductGroupTemplateName,
ProductUnitId = ProductUnitId
            }
            );

            return Ok(result.ToList());
        }

    }
}
