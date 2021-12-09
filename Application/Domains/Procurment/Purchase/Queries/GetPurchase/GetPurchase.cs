using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Procurment;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.Purchase.Queries.GetPurchase
{

    public class GetPurchaseQuery : IRequest<Application.Model.Procurment.Purchase>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseQueryHandler : IRequestHandler<GetPurchaseQuery, Application.Model.Procurment.Purchase>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Procurment.Purchase> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Purchase
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Purchase), request.Id);
            }

            return entity;

        }

    }
}
