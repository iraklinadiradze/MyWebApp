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

namespace Application.Domains.Product.ProductProcessor.Queries.GetProductProcessor
{

    public class GetProductProcessorQuery : IRequest<Application.Model.Product.ProductProcessor>
    {
        public int? Id { get; set; }
    }

    public class GetProductProcessorQueryHandler : IRequestHandler<GetProductProcessorQuery, Application.Model.Product.ProductProcessor>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductProcessor> Handle(GetProductProcessorQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductProcessor
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessor), request.Id);
            }

            return entity;

        }

    }
}
