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

namespace Application.Domains.Procurment.PurchaseAllocationSource.Commands.CreatePurchaseAllocationSource
{
    public class CreatePurchaseAllocationSourceCommand : IRequest<Application.Model.Procurment.PurchaseAllocationSource>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseAllocationSource PurchaseAllocationSource { get; set; }
    }

    public class CreatePurchaseAllocationSourceCommandHandler : IRequestHandler<CreatePurchaseAllocationSourceCommand, Application.Model.Procurment.PurchaseAllocationSource>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationSourceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseAllocationSource> Handle(CreatePurchaseAllocationSourceCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseAllocationSource;

            _context.PurchaseAllocationSource.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
