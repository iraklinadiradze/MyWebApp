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

namespace Application.Domains.Core.Country.Queries.GetCountry
{

    public class GetCountryQuery : IRequest<Application.Model.Core.Country>
    {
        public int? Id { get; set; }
    }

    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, Application.Model.Core.Country>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetCountryQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Core.Country> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Country
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            return entity;

        }

    }
}
