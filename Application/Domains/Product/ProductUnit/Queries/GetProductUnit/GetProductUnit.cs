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

namespace Application.Domains.Product.ProductUnit.Queries.GetProductUnit
{

    public class GetProductUnitQuery : IRequest<Application.Model.Product.ProductUnit>
    {
        public int? Id { get; set; }
    }

    public class GetProductUnitQueryHandler : IRequestHandler<GetProductUnitQuery, Application.Model.Product.ProductUnit>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductUnitQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductUnit> Handle(GetProductUnitQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductUnit
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductUnit), request.Id);
            }

            return entity;

        }

    }
}
