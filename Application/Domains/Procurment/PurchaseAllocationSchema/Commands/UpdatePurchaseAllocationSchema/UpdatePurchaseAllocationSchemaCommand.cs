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

namespace Application.Domains.Procurment.PurchaseAllocationSchema.Commands.UpdatePurchaseAllocationSchema
{
    public class UpdatePurchaseAllocationSchemaCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSchema>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSchema purchaseAllocationSchema { get; set; }
    }

    public class UpdatePurchaseAllocationSchemaCommandHandler : IRequestHandler<UpdatePurchaseAllocationSchemaCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationSchema>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseAllocationSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSchema> Handle(UpdatePurchaseAllocationSchemaCommand request, CancellationToken cancellationToken)
        {

            var entity = request.purchaseAllocationSchema;

            var _entity = await _context.PurchaseAllocationSchema.FindAsync(request.purchaseAllocationSchema.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(PurchaseAllocationSchema), entity.Id);
            }

            _context.PurchaseAllocationSchema.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
