using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Core;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Core.User.Queries.GetUser
{

    public class GetUserQuery : IRequest<Application.Model.Core.User>
    {
        public int? Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Application.Model.Core.User>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetUserQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Core.User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.User
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return entity;

        }

    }
}
