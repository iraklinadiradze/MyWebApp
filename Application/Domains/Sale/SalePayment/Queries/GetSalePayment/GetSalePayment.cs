using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.SalePayment.Queries.GetSalePayment
{

    public class GetSalePaymentQuery : IRequest<DataAccessLayer.Model.Sale.SalePayment>
    {
        public int? Id { get; set; }
    }

    public class GetSalePaymentQueryHandler : IRequestHandler<GetSalePaymentQuery, DataAccessLayer.Model.Sale.SalePayment>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSalePaymentQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Sale.SalePayment> Handle(GetSalePaymentQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.SalePayment
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalePayment), request.Id);
            }

            return entity;

        }

    }
}
