using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Inventory.Inventory.Commands.CreateInventory
{
    public class CreateInventoryCommand : IRequest<DataAccessLayer.Model.Inventory.Inventory>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Inventory.Inventory inventory { get; set; }
    }

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, DataAccessLayer.Model.Inventory.Inventory>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.Inventory> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var entity = request.inventory;

            _context.Inventory.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
