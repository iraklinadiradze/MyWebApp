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

namespace Application.Domains.Core.Currency.Queries.GetCurrency
{

    public class GetCurrencyQuery : IRequest<Application.Model.Core.Currency>
    {
        public int? Id { get; set; }
    }

    public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, Application.Model.Core.Currency>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetCurrencyQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Core.Currency> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Currency
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.Id);
            }

            return entity;

        }

    }
}
