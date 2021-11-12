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

namespace Application.Domains.Inventory.Location.Commands.UpdateLocation
{
    public class UpdateLocationCommand : IRequest<DataAccessLayer.Model.Inventory.Location>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Inventory.Location location { get; set; }
    }

    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, DataAccessLayer.Model.Inventory.Location>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateLocationCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.Location> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {

            var entity = request.location;

            var _entity = await _context.Location.FindAsync(request.location.Id);

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
