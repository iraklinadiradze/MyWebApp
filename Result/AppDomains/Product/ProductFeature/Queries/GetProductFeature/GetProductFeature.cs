using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Product.ProductFeature.Queries.GetProductFeature
{

    public class GetProductFeatureQuery : IRequest<DataAccessLayer.Model.Product.ProductFeature>
    {
        public int? Id { get; set; }
    }

    public class GetProductFeatureQueryHandler : IRequestHandler<GetProductFeatureQuery, DataAccessLayer.Model.Product.ProductFeature>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductFeatureQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Product.ProductFeature> Handle(GetProductFeatureQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductFeature
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductFeature), request.Id);
            }

            return entity;

        }

    }
}
