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

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.CreatePurchaseAllocationSourceType
{
    public class CreatePurchaseAllocationSourceTypeCommand : IRequest<Application.Model.Procurment.PurchaseAllocationSourceType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseAllocationSourceType PurchaseAllocationSourceType { get; set; }
    }

    public class CreatePurchaseAllocationSourceTypeCommandHandler : IRequestHandler<CreatePurchaseAllocationSourceTypeCommand, Application.Model.Procurment.PurchaseAllocationSourceType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationSourceTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Procurment.PurchaseAllocationSourceType> Handle(CreatePurchaseAllocationSourceTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseAllocationSourceType;

            _context.PurchaseAllocationSourceType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
