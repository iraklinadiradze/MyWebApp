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

namespace Application.Domains.Inventory.Inventory.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest<DataAccessLayer.Model.Inventory.Inventory>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Inventory.Inventory inventory { get; set; }
    }

    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, DataAccessLayer.Model.Inventory.Inventory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.Inventory> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {

            var entity = request.inventory;

            var _entity = await _context.Inventory.FindAsync(request.inventory.Id);

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
