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

namespace Application.Domains.Inventory.Movement.Queries.GetMovement
{

    public class GetMovementQuery : IRequest<Application.Model.Inventory.Movement>
    {
        public int? Id { get; set; }
    }

    public class GetMovementQueryHandler : IRequestHandler<GetMovementQuery, Application.Model.Inventory.Movement>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetMovementQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Inventory.Movement> Handle(GetMovementQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Movement
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movement), request.Id);
            }

            return entity;

        }

    }
}
