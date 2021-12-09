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

namespace Application.Domains.Product.ProductCategory.Queries.GetProductCategory
{

    public class GetProductCategoryQuery : IRequest<Application.Model.Product.ProductCategory>
    {
        public int? Id { get; set; }
    }

    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, Application.Model.Product.ProductCategory>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductCategoryQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Product.ProductCategory> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductCategory
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.Id);
            }

            return entity;

        }

    }
}
