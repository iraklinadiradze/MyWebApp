using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Inventory;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.Location.Queries.GetLocation
{

    public class GetLocationQuery : IRequest<Application.Model.Inventory.Location>
    {
        public int? Id { get; set; }
    }

    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, Application.Model.Inventory.Location>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetLocationQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Inventory.Location> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Location
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Location), request.Id);
            }

            return entity;

        }

    }
}
