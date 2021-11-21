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

namespace Application.Domains.Inventory.Location.Commands.CreateLocation
{
    public class CreateLocationCommand : IRequest<DataAccessLayer.Model.Inventory.Location>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Inventory.Location Location { get; set; }
    }

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, DataAccessLayer.Model.Inventory.Location>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateLocationCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.Location> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Location;

            _context.Location.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
