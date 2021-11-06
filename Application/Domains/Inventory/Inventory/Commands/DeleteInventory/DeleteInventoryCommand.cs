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

namespace Application.Domains.Inventory.Inventory.Commands.DeleteInventory
{
    public class DeleteInventoryCommand : IRequest<int>
    {
        public int senderId { get; set; }  = 0;
        public int Id { get; set; }
    }

    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.Inventory.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Inventory), request.Id);
            }

            _context.Inventory.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
