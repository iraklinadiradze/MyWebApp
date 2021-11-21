using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Procurment.PurchaseAllocationSource.Commands.CreatePurchaseAllocationSource
{
    public class CreatePurchaseAllocationSourceCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSource>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSource PurchaseAllocationSource { get; set; }
    }

    public class CreatePurchaseAllocationSourceCommandHandler : IRequestHandler<CreatePurchaseAllocationSourceCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationSource>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationSourceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSource> Handle(CreatePurchaseAllocationSourceCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseAllocationSource;

            _context.PurchaseAllocationSource.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
