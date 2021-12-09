using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Inventory;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Inventory.InventoryChange.Commands.UpdateInventoryChange
{
    public class UpdateInventoryChangeCommand : IRequest<Application.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.InventoryChange InventoryChange { get; set; }
    }

    public class UpdateInventoryChangeCommandHandler : IRequestHandler<UpdateInventoryChangeCommand, Application.Model.Inventory.InventoryChange>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateInventoryChangeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.InventoryChange> Handle(UpdateInventoryChangeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.InventoryChange;

            var _entity = await _context.InventoryChange.FindAsync(request.InventoryChange.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(InventoryChange), entity.Id);
            }

            _context.InventoryChange.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
