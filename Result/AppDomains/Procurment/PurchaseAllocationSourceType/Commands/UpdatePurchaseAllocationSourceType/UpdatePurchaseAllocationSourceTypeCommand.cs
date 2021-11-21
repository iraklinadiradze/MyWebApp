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
using Application.Common;

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Commands.UpdatePurchaseAllocationSourceType
{
    public class UpdatePurchaseAllocationSourceTypeCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSourceType PurchaseAllocationSourceType { get; set; }
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

            var entity = request.PurchaseAllocationSourceType;

            var _entity = await _context.PurchaseAllocationSourceType.FindAsync(request.PurchaseAllocationSourceType.Id);

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
