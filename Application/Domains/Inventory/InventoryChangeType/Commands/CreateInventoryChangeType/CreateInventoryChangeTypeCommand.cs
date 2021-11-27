using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Inventory.InventoryChangeType.Commands.CreateInventoryChangeType
{
    public class CreateInventoryChangeTypeCommand : IRequest<DataAccessLayer.Model.Inventory.InventoryChangeType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.InventoryChangeType InventoryChangeType { get; set; }
    }

    public class CreateInventoryChangeTypeCommandHandler : IRequestHandler<CreateInventoryChangeTypeCommand, DataAccessLayer.Model.Inventory.InventoryChangeType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateInventoryChangeTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.InventoryChangeType> Handle(CreateInventoryChangeTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.InventoryChangeType;

            _context.InventoryChangeType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
