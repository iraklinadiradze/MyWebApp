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

namespace Application.Domains.Product.ProductLabel.Queries.GetProductLabel
{

    public class GetProductLabelQuery : IRequest<Application.Model.Product.ProductLabel>
    {
        public int? Id { get; set; }
    }

    public class GetProductLabelQueryHandler : IRequestHandler<GetProductLabelQuery, Application.Model.Product.ProductLabel>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductLabelQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductLabel> Handle(GetProductLabelQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductLabel
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductLabel), request.Id);
            }

            return entity;

        }

    }
}
