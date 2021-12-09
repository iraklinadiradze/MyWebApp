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

namespace Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSource
{

    public class GetPurchaseAllocationSourceQuery : IRequest<Application.Model.Procurment.PurchaseAllocationSource>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseAllocationSourceQueryHandler : IRequestHandler<GetPurchaseAllocationSourceQuery, Application.Model.Procurment.PurchaseAllocationSource>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSourceQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Procurment.PurchaseAllocationSource> Handle(GetPurchaseAllocationSourceQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseAllocationSource
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSource), request.Id);
            }

            return entity;

        }

    }
}
