using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Inventory.Movement.Commands.CreateMovement
{
    public class CreateMovementCommand : IRequest<DataAccessLayer.Model.Inventory.Movement>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.Movement Movement { get; set; }
    }

    public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, DataAccessLayer.Model.Inventory.Movement>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateMovementCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.Movement> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Movement;

            _context.Movement.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
