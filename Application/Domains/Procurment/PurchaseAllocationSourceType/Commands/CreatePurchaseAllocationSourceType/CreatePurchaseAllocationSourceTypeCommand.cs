using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.CreatePurchaseAllocationSourceType
{
    public class CreatePurchaseAllocationSourceTypeCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType purchaseAllocationSourceType { get; set; }
    }

    public class CreatePurchaseAllocationSourceTypeCommandHandler : IRequestHandler<CreatePurchaseAllocationSourceTypeCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationSourceTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType> Handle(CreatePurchaseAllocationSourceTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.purchaseAllocationSourceType;

            _context.PurchaseAllocationSourceType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
