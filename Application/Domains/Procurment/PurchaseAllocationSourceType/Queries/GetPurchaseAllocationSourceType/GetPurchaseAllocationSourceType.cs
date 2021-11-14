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

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Queries.GetPurchaseAllocationSourceType
{

    public class GetPurchaseAllocationSourceTypeQuery : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseAllocationSourceTypeQueryHandler : IRequestHandler<GetPurchaseAllocationSourceTypeQuery, DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSourceTypeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType> Handle(GetPurchaseAllocationSourceTypeQuery request, CancellationToken cancellationToken)
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
