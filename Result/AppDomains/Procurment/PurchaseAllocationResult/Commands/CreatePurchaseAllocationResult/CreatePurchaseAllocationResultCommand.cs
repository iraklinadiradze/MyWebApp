using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Procurment.PurchaseAllocationResult.Commands.CreatePurchaseAllocationResult
{
    public class CreatePurchaseAllocationResultCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationResult>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationResult purchaseAllocationResult { get; set; }
    }

    public class CreatePurchaseAllocationResultCommandHandler : IRequestHandler<CreatePurchaseAllocationResultCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationResult>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationResultCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationResult> Handle(CreatePurchaseAllocationResultCommand request, CancellationToken cancellationToken)
        {
            var entity = request.purchaseAllocationResult;

            _context.PurchaseAllocationResult.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
