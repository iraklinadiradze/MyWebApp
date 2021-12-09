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

namespace Application.Domains.Product.Product.Queries.GetProduct
{

    public class GetProductQuery : IRequest<Application.Model.Product.Product>
    {
        public int? Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Application.Model.Product.Product>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Product
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return entity;

        }

    }
}
