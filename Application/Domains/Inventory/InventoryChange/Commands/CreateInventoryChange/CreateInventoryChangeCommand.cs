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

namespace Application.Domains.Inventory.InventoryChange.Commands.CreateInventoryChange
{
    public class CreateInventoryChangeCommand : IRequest<Application.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.InventoryChange InventoryChange { get; set; }
    }

    public class CreateInventoryChangeCommandHandler : IRequestHandler<CreateInventoryChangeCommand, Application.Model.Inventory.InventoryChange>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateInventoryChangeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.InventoryChange> Handle(CreateInventoryChangeCommand request, CancellationToken cancellationToken)
        {
            var entity = request.InventoryChange;

            _context.InventoryChange.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
