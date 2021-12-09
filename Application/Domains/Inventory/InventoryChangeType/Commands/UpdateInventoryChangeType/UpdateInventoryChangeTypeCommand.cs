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

namespace Application.Domains.Inventory.InventoryChangeType.Commands.UpdateInventoryChangeType
{
    public class UpdateInventoryChangeTypeCommand : IRequest<Application.Model.Inventory.InventoryChangeType>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.InventoryChangeType InventoryChangeType { get; set; }
    }

    public class UpdateInventoryChangeTypeCommandHandler : IRequestHandler<UpdateInventoryChangeTypeCommand, Application.Model.Inventory.InventoryChangeType>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateInventoryChangeTypeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.InventoryChangeType> Handle(UpdateInventoryChangeTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = request.InventoryChangeType;

            var _entity = await _context.InventoryChangeType.FindAsync(request.InventoryChangeType.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(InventoryChangeType), entity.Id);
            }

            _context.InventoryChangeType.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
