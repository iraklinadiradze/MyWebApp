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

namespace Application.Domains.Inventory.InventoryChange.Queries.GetInventoryChange
{

    public class GetInventoryChangeQuery : IRequest<Application.Model.Inventory.InventoryChange>
    {
        public int? Id { get; set; }
    }

    public class GetInventoryChangeQueryHandler : IRequestHandler<GetInventoryChangeQuery, Application.Model.Inventory.InventoryChange>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryChangeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Inventory.InventoryChange> Handle(GetInventoryChangeQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.InventoryChange
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(InventoryChange), request.Id);
            }

            return entity;

        }

    }
}
