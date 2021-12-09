using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Client;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Client.LegalEntity.Queries.GetLegalEntity
{

    public class GetLegalEntityQuery : IRequest<Application.Model.Client.LegalEntity>
    {
        public int? Id { get; set; }
    }

    public class GetLegalEntityQueryHandler : IRequestHandler<GetLegalEntityQuery, Application.Model.Client.LegalEntity>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetLegalEntityQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Client.LegalEntity> Handle(GetLegalEntityQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.LegalEntity
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(LegalEntity), request.Id);
            }

            return entity;

        }

    }
}
