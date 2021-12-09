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

namespace Application.Domains.Product.Feature.Queries.GetFeature
{

    public class GetFeatureQuery : IRequest<Application.Model.Product.Feature>
    {
        public int? Id { get; set; }
    }

    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, Application.Model.Product.Feature>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetFeatureQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.Feature> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Feature
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Feature), request.Id);
            }

            return entity;

        }

    }
}
