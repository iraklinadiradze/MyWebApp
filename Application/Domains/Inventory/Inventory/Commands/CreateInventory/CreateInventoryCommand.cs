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

namespace Application.Domains.Inventory.Inventory.Commands.CreateInventory
{
    public class CreateInventoryCommand : IRequest<Application.Model.Inventory.Inventory>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Inventory Inventory { get; set; }
    }

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Application.Model.Inventory.Inventory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.Inventory> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Inventory;

            _context.Inventory.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
