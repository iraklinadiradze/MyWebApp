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

namespace Application.Domains.Procurment.PurchaseAllocationSchema.Queries.GetPurchaseAllocationSchema
{

    public class GetPurchaseAllocationSchemaQuery : IRequest<Application.Model.Procurment.PurchaseAllocationSchema>
    {
        public int? Id { get; set; }
    }

    public class GetPurchaseAllocationSchemaQueryHandler : IRequestHandler<GetPurchaseAllocationSchemaQuery, Application.Model.Procurment.PurchaseAllocationSchema>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSchemaQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Procurment.PurchaseAllocationSchema> Handle(GetPurchaseAllocationSchemaQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseAllocationSchema
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSchema), request.Id);
            }

            return entity;

        }

    }
}
