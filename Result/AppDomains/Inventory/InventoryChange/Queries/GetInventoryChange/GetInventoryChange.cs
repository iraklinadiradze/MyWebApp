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

namespace Application.Domains.Inventory.InventoryChange.Queries.GetInventoryChange
{

    public class GetInventoryChangeQuery : IRequest<DataAccessLayer.Model.Inventory.InventoryChange>
    {
        public int? Id { get; set; }
    }

    public class GetInventoryChangeQueryHandler : IRequestHandler<GetInventoryChangeQuery, DataAccessLayer.Model.Inventory.InventoryChange>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryChangeQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Inventory.InventoryChange> Handle(GetInventoryChangeQuery request, CancellationToken cancellationToken)
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
