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

namespace Application.Domains.Inventory.Location.Commands.CreateLocation
{
    public class CreateLocationCommand : IRequest<Application.Model.Inventory.Location>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Location Location { get; set; }
    }

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Application.Model.Inventory.Location>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateLocationCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Inventory.Location> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Location;

            _context.Location.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
