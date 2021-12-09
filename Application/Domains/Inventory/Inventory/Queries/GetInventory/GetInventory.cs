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

namespace Application.Domains.Inventory.Inventory.Queries.GetInventory
{

    public class GetInventoryQuery : IRequest<Application.Model.Inventory.Inventory>
    {
        public int? Id { get; set; }
    }

    public class GetInventoryQueryHandler : IRequestHandler<GetInventoryQuery, Application.Model.Inventory.Inventory>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Inventory.Inventory> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Inventory
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Inventory), request.Id);
            }

            return entity;

        }

    }
}
