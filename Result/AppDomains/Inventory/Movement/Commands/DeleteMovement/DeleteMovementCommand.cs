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

namespace Application.Domains.Inventory.Movement.Commands.DeleteMovement
{
    public class DeleteMovementCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
    }

    public class DeleteMovementCommandHandler : IRequestHandler<DeleteMovementCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public DeleteMovementCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<int> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {

            var _entity = await _context.Movement.FindAsync(request.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Movement), request.Id);
            }

            _context.Movement.Remove(_entity); 

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { Id = entity.Id }, cancellationToken);

            return 0;
         }

    }

}
