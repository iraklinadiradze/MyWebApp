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

namespace Application.Domains.Sale.SalePaymentType.Queries.GetSalePaymentType
{

    public class GetSalePaymentTypeQuery : IRequest<Application.Model.Sale.SalePaymentType>
    {
        public int? Id { get; set; }
    }

    public class GetSalePaymentTypeQueryHandler : IRequestHandler<GetSalePaymentTypeQuery, Application.Model.Sale.SalePaymentType>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSalePaymentTypeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Sale.SalePaymentType> Handle(GetSalePaymentTypeQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.SalePaymentType
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalePaymentType), request.Id);
            }

            return entity;

        }

    }
}
