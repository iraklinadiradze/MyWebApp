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

namespace Application.Domains.Inventory.InventoryChangeType.Queries.GetInventoryChangeType
{

    public class GetInventoryChangeTypeQuery : IRequest<Application.Model.Inventory.InventoryChangeType>
    {
        public int? Id { get; set; }
    }

    public class GetInventoryChangeTypeQueryHandler : IRequestHandler<GetInventoryChangeTypeQuery, Application.Model.Inventory.InventoryChangeType>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryChangeTypeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Inventory.InventoryChangeType> Handle(GetInventoryChangeTypeQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.InventoryChangeType
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(InventoryChangeType), request.Id);
            }

            return entity;

        }

    }
}
