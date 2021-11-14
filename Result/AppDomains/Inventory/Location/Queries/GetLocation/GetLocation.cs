using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.Location.Queries.GetLocation
{

    public class GetLocationQuery : IRequest<DataAccessLayer.Model.Inventory.Location>
    {
        public int? Id { get; set; }
    }

    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, DataAccessLayer.Model.Inventory.Location>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetLocationQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Inventory.Location> Handle(GetLocationQuery request, CancellationToken cancellationToken)
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
