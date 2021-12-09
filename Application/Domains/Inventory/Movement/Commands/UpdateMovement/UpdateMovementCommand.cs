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

namespace Application.Domains.Inventory.Movement.Commands.UpdateMovement
{
    public class UpdateMovementCommand : IRequest<Application.Model.Inventory.Movement>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Movement Movement { get; set; }
    }

    public class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, Application.Model.Inventory.Movement>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateMovementCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.Movement> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Movement;

            var _entity = await _context.Movement.FindAsync(request.Movement.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Movement), entity.Id);
            }

            _context.Movement.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
