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

namespace Application.Domains.Procurment.PurchaseAllocationSchema.Commands.CreatePurchaseAllocationSchema
{
    public class CreatePurchaseAllocationSchemaCommand : IRequest<DataAccessLayer.Model.Procurment.PurchaseAllocationSchema>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.PurchaseAllocationSchema PurchaseAllocationSchema { get; set; }
    }

    public class CreatePurchaseAllocationSchemaCommandHandler : IRequestHandler<CreatePurchaseAllocationSchemaCommand, DataAccessLayer.Model.Procurment.PurchaseAllocationSchema>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreatePurchaseAllocationSchemaCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Procurment.PurchaseAllocationSchema> Handle(CreatePurchaseAllocationSchemaCommand request, CancellationToken cancellationToken)
        {
            var entity = request.PurchaseAllocationSchema;

            _context.PurchaseAllocationSchema.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
