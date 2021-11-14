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

namespace Application.Domains.Product.ProductProcessorSalePrice.Queries.GetProductProcessorSalePrice
{

    public class GetProductProcessorSalePriceQuery : IRequest<DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {
        public int? Id { get; set; }
    }

    public class GetProductProcessorSalePriceQueryHandler : IRequestHandler<GetProductProcessorSalePriceQuery, DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorSalePriceQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Product.ProductProcessorSalePrice> Handle(GetProductProcessorSalePriceQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.ProductProcessorSalePrice
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorSalePrice), request.Id);
            }

            return entity;

        }

    }
}
