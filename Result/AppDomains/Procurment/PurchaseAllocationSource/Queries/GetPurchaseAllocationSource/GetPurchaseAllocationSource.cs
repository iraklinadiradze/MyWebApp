using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSource
{

    public class GetPurchaseAllocationSourceQuery : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSource>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseAllocationSourceQueryHandler : IRequestHandler<GetPurchaseAllocationSourceQuery, DataAccessLayer.Model.Procurment.PurchaseAllocationSource>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSourceQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSource> Handle(GetPurchaseAllocationSourceQuery request, CancellationToken cancellationToken)
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
