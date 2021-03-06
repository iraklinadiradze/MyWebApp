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

namespace Application.Domains.Inventory.Movement.Commands.UpdateMovement
{
    public class UpdateMovementCommand : IRequest<DataAccessLayer.Model.Inventory.Movement>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.Movement Movement { get; set; }
    }

    public class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, DataAccessLayer.Model.Inventory.Movement>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateMovementCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.Movement> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
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
