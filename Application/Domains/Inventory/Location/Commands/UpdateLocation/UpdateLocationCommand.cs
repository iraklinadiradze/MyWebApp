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

namespace Application.Domains.Inventory.Location.Commands.UpdateLocation
{
    public class UpdateLocationCommand : IRequest<Application.Model.Inventory.Location>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Location Location { get; set; }
    }

    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Application.Model.Inventory.Location>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateLocationCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.Location> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Location;

            var _entity = await _context.Location.FindAsync(request.Location.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Location), entity.Id);
            }

            _context.Location.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
