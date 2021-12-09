using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Inventory;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Inventory.InventoryChangeType.Commands.CreateInventoryChangeType
{
    public class CreateInventoryChangeTypeCommand : IRequest<Application.Model.Inventory.InventoryChangeType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.InventoryChangeType InventoryChangeType { get; set; }
    }

    public class CreateInventoryChangeTypeCommandHandler : IRequestHandler<CreateInventoryChangeTypeCommand, Application.Model.Inventory.InventoryChangeType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateInventoryChangeTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.InventoryChangeType> Handle(CreateInventoryChangeTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.InventoryChangeType;

            _context.InventoryChangeType.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
