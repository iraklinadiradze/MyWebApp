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

namespace Application.Domains.Client.Person.Queries.GetPerson
{

    public class GetPersonQuery : IRequest<Application.Model.Client.Person>
    {
        public int? Id { get; set; }
    }

    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Application.Model.Client.Person>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPersonQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Client.Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Person
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            return entity;

        }

    }
}
