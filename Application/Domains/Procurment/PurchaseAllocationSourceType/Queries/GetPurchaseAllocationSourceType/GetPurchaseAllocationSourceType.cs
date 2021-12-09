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

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Queries.GetPurchaseAllocationSourceType
{

    public class GetPurchaseAllocationSourceTypeQuery : IRequest<Application.Model.Procurment.PurchaseAllocationSourceType>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseAllocationSourceTypeQueryHandler : IRequestHandler<GetPurchaseAllocationSourceTypeQuery, Application.Model.Procurment.PurchaseAllocationSourceType>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSourceTypeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Procurment.PurchaseAllocationSourceType> Handle(GetPurchaseAllocationSourceTypeQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseAllocationSourceType
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSourceType), request.Id);
            }

            return entity;

        }

    }
}
