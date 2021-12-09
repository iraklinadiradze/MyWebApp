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

namespace Application.Domains.Product.ProductGroupTemplateFeature.Queries.GetProductGroupTemplateFeature
{

    public class GetProductGroupTemplateFeatureQuery : IRequest<Application.Model.Product.ProductGroupTemplateFeature>
    {
        public int? Id { get; set; }
    }

    public class GetProductGroupTemplateFeatureQueryHandler : IRequestHandler<GetProductGroupTemplateFeatureQuery, Application.Model.Product.ProductGroupTemplateFeature>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupTemplateFeatureQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductGroupTemplateFeature> Handle(GetProductGroupTemplateFeatureQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductGroupTemplateFeature
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductGroupTemplateFeature), request.Id);
            }

            return entity;

        }

    }
}
