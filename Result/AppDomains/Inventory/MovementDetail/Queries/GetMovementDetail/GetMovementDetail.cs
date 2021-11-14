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

namespace Application.Domains.Inventory.MovementDetail.Queries.GetMovementDetail
{

    public class GetMovementDetailQuery : IRequest<DataAccessLayer.Model.Inventory.MovementDetail>
    {
        public int? Id { get; set; }
    }

    public class GetMovementDetailQueryHandler : IRequestHandler<GetMovementDetailQuery, DataAccessLayer.Model.Inventory.MovementDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetMovementDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Inventory.MovementDetail> Handle(GetMovementDetailQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.MovementDetail
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(MovementDetail), request.Id);
            }

            return entity;

        }

    }
}
