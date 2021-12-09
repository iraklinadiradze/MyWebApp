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

namespace Application.Domains.Inventory.Inventory.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest<Application.Model.Inventory.Inventory>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Inventory Inventory { get; set; }
    }

    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, Application.Model.Inventory.Inventory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.Inventory> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Inventory;

            var _entity = await _context.Inventory.FindAsync(request.Inventory.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Inventory), entity.Id);
            }

            _context.Inventory.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
