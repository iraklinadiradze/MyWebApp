using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Product;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Product.ProductGroupTemplate.Queries.GetProductGroupTemplate
{

    public class GetProductGroupTemplateQuery : IRequest<Application.Model.Product.ProductGroupTemplate>
    {
        public int? Id { get; set; }
    }

    public class GetProductGroupTemplateQueryHandler : IRequestHandler<GetProductGroupTemplateQuery, Application.Model.Product.ProductGroupTemplate>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupTemplateQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductGroupTemplate> Handle(GetProductGroupTemplateQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductGroupTemplate
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductGroupTemplate), request.Id);
            }

            return entity;

        }

    }
}
