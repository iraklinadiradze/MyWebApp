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

namespace Application.Domains.Inventory.InventoryChange.Commands.DeleteInventoryChange
{
    public class DeleteInventoryChangeCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteInventoryChangeCommandHandler : IRequestHandler<DeleteInventoryChangeCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteInventoryChangeCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteInventoryChangeCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.InventoryChange.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(InventoryChange), request.Id);
            }

            _context.InventoryChange.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
