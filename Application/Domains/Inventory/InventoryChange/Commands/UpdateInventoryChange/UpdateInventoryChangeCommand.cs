using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Inventory.InventoryChange.Commands.UpdateInventoryChange
{
    public class UpdateInventoryChangeCommand : IRequest<DataAccessLayer.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.InventoryChange InventoryChange { get; set; }
    }

    public class UpdateInventoryChangeCommandHandler : IRequestHandler<UpdateInventoryChangeCommand, DataAccessLayer.Model.Inventory.InventoryChange>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateInventoryChangeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.InventoryChange> Handle(UpdateInventoryChangeCommand request, CancellationToken cancellationToken)
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
