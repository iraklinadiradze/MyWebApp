using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Core;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Core.Entity.Queries.GetEntity
{

    public class GetEntityQuery : IRequest<DataAccessLayer.Model.Core.Entity>
    {
        public int? Id { get; set; }
    }

    public class GetEntityQueryHandler : IRequestHandler<GetEntityQuery, DataAccessLayer.Model.Core.Entity>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetEntityQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Core.Entity> Handle(GetEntityQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Entity
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entity), request.Id);
            }

            return entity;

        }

    }
}
