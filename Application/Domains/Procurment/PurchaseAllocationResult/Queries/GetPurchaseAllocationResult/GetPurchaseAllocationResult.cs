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

namespace Application.Domains.Procurment.PurchaseAllocationResult.Queries.GetPurchaseAllocationResult
{

    public class GetPurchaseAllocationResultQuery : IRequest<Application.Model.Procurment.PurchaseAllocationResult>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseAllocationResultQueryHandler : IRequestHandler<GetPurchaseAllocationResultQuery, Application.Model.Procurment.PurchaseAllocationResult>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationResultQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Procurment.PurchaseAllocationResult> Handle(GetPurchaseAllocationResultQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseAllocationResult
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationResult), request.Id);
            }

            return entity;

        }

    }
}
