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

namespace Application.Domains.Product.ProductGroup.Queries.GetProductGroup
{

    public class GetProductGroupQuery : IRequest<Application.Model.Product.ProductGroup>
    {
        public int? Id { get; set; }
    }

    public class GetProductGroupQueryHandler : IRequestHandler<GetProductGroupQuery, Application.Model.Product.ProductGroup>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductGroup> Handle(GetProductGroupQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductGroup
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductGroup), request.Id);
            }

            return entity;

        }

    }
}
