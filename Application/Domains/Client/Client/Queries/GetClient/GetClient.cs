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

namespace Application.Domains.Client.Client.Queries.GetClient
{

    public class GetClientQuery : IRequest<Application.Model.Client.Client>
    {
        public int? Id { get; set; }
    }

    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, Application.Model.Client.Client>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetClientQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Client.Client> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Client
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            return entity;

        }

    }
}
