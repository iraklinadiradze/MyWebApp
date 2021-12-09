using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Procurment;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Procurment.PurchaseAllocationResult.Commands.UpdatePurchaseAllocationResult
{
    public class UpdatePurchaseAllocationResultCommand : IRequest<Application.Model.Procurment.PurchaseAllocationResult>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseAllocationResult PurchaseAllocationResult { get; set; }
    }

    public class UpdatePurchaseAllocationResultCommandHandler : IRequestHandler<UpdatePurchaseAllocationResultCommand, Application.Model.Procurment.PurchaseAllocationResult>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseAllocationResultCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseAllocationResult> Handle(UpdatePurchaseAllocationResultCommand request, CancellationToken cancellationToken)
        {

            var entity = request.PurchaseAllocationResult;

            var _entity = await _context.PurchaseAllocationResult.FindAsync(request.PurchaseAllocationResult.Id);

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
