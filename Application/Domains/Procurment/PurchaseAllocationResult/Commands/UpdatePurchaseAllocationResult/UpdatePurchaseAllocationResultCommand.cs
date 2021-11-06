using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Procurment.PurchaseAllocationResult.Commands.UpdatePurchaseAllocationResult
{
    public class UpdatePurchaseAllocationResultCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationResult>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationResult purchaseAllocationResult { get; set; }
    }

    public class UpdatePurchaseAllocationResultCommandHandler : IRequestHandler<UpdatePurchaseAllocationResultCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationResult>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseAllocationResultCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationResult> Handle(UpdatePurchaseAllocationResultCommand request, CancellationToken cancellationToken)
        {

            var entity = request.purchaseAllocationResult;

            var _entity = await _context.PurchaseAllocationResult.FindAsync(request.purchaseAllocationResult.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationResult), entity.Id);
            }

            _context.PurchaseAllocationResult.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
