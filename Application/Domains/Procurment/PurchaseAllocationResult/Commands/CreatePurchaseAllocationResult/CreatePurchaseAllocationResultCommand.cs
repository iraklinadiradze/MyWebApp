using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Procurment;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Procurment.PurchaseAllocationResult.Commands.CreatePurchaseAllocationResult
{
    public class CreatePurchaseAllocationResultCommand : IRequest<Application.Model.Procurment.PurchaseAllocationResult>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseAllocationResult PurchaseAllocationResult { get; set; }
    }

    public class CreatePurchaseAllocationResultCommandHandler : IRequestHandler<CreatePurchaseAllocationResultCommand, Application.Model.Procurment.PurchaseAllocationResult>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationResultCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseAllocationResult> Handle(CreatePurchaseAllocationResultCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseAllocationResult;

            _context.PurchaseAllocationResult.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
