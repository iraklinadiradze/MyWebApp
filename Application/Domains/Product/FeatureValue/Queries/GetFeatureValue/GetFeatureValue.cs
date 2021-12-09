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

namespace Application.Domains.Product.FeatureValue.Queries.GetFeatureValue
{

    public class GetFeatureValueQuery : IRequest<Application.Model.Product.FeatureValue>
    {
        public int? Id { get; set; }
    }

    public class GetFeatureValueQueryHandler : IRequestHandler<GetFeatureValueQuery, Application.Model.Product.FeatureValue>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetFeatureValueQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.FeatureValue> Handle(GetFeatureValueQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.FeatureValue
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FeatureValue), request.Id);
            }

            return entity;

        }

    }
}
