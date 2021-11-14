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

namespace Application.Domains.Product.ProductCategory.Queries.GetProductCategory
{

    public class GetProductCategoryQuery : IRequest<DataAccessLayer.Model.Product.ProductCategory>
    {
        public int? Id { get; set; }
    }

    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, DataAccessLayer.Model.Product.ProductCategory>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductCategoryQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Product.ProductCategory> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
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
