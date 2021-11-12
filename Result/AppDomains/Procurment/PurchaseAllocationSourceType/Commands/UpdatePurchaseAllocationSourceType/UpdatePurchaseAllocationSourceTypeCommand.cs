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

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.UpdatePurchaseAllocationSourceType
{
    public class UpdatePurchaseAllocationSourceTypeCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType purchaseAllocationSourceType { get; set; }
    }

    public class UpdatePurchaseAllocationSourceTypeCommandHandler : IRequestHandler<UpdatePurchaseAllocationSourceTypeCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseAllocationSourceTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType> Handle(UpdatePurchaseAllocationSourceTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.purchaseAllocationSourceType;

            var _entity = await _context.PurchaseAllocationSourceType.FindAsync(request.purchaseAllocationSourceType.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSourceType), entity.Id);
            }

            _context.PurchaseAllocationSourceType.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
