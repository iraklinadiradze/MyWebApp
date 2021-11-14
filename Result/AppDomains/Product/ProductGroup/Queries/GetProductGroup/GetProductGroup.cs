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

namespace Application.Domains.Product.ProductGroup.Queries.GetProductGroup
{

    public class GetProductGroupQuery : IRequest<DataAccessLayer.Model.Product.ProductGroup>
    {
        public int? Id { get; set; }
    }

    public class GetProductGroupQueryHandler : IRequestHandler<GetProductGroupQuery, DataAccessLayer.Model.Product.ProductGroup>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Product.ProductGroup> Handle(GetProductGroupQuery request, CancellationToken cancellationToken)
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
