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

namespace Application.Domains.Product.ProductProcessorProductFeature.Queries.GetProductProcessorProductFeature
{

    public class GetProductProcessorProductFeatureQuery : IRequest<Application.Model.Product.ProductProcessorProductFeature>
    {
        public int? Id { get; set; }
    }

    public class GetProductProcessorProductFeatureQueryHandler : IRequestHandler<GetProductProcessorProductFeatureQuery, Application.Model.Product.ProductProcessorProductFeature>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorProductFeatureQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductProcessorProductFeature> Handle(GetProductProcessorProductFeatureQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductProcessorProductFeature
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorProductFeature), request.Id);
            }

            return entity;

        }

    }
}
