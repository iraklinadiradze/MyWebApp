using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Sale;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.SaleProduct.Queries.GetSaleProduct
{

    public class GetSaleProductQuery : IRequest<Application.Model.Sale.SaleProduct>
    {
        public int? Id { get; set; }
    }

    public class GetSaleProductQueryHandler : IRequestHandler<GetSaleProductQuery, Application.Model.Sale.SaleProduct>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleProductQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Sale.SaleProduct> Handle(GetSaleProductQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.SaleProduct
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SaleProduct), request.Id);
            }

            return entity;

        }

    }
}
