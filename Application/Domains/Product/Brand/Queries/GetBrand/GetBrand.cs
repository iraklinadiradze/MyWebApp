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

namespace Application.Domains.Product.Brand.Queries.GetBrand
{

    public class GetBrandQuery : IRequest<Application.Model.Product.Brand>
    {
        public int? Id { get; set; }
    }

    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, Application.Model.Product.Brand>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetBrandQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.Brand> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Brand
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Brand), request.Id);
            }

            return entity;

        }

    }
}
