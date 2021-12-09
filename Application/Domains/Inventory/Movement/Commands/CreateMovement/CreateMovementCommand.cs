using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Inventory;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Inventory.Movement.Commands.CreateMovement
{
    public class CreateMovementCommand : IRequest<Application.Model.Inventory.Movement>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Movement Movement { get; set; }
    }

    public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, Application.Model.Inventory.Movement>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateMovementCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.Movement> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Movement;

            _context.Movement.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
