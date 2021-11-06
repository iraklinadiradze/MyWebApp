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

namespace Application.Domains.Procurment.PurchaseAllocationSource.Commands.UpdatePurchaseAllocationSource
{
    public class UpdatePurchaseAllocationSourceCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSource>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSource purchaseAllocationSource { get; set; }
    }

    public class UpdatePurchaseAllocationSourceCommandHandler : IRequestHandler<UpdatePurchaseAllocationSourceCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationSource>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseAllocationSourceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSource> Handle(UpdatePurchaseAllocationSourceCommand request, CancellationToken cancellationToken)
        {

            var entity = request.purchaseAllocationSource;

            var _entity = await _context.PurchaseAllocationSource.FindAsync(request.purchaseAllocationSource.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSource), entity.Id);
            }

            _context.PurchaseAllocationSource.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
