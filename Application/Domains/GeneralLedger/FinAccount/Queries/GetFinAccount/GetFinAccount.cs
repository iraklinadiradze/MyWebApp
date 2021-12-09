using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.GeneralLedger;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.GeneralLedger.FinAccount.Queries.GetFinAccount
{

    public class GetFinAccountQuery : IRequest<Application.Model.GeneralLedger.FinAccount>
    {
        public int? Id { get; set; }
    }

    public class GetFinAccountQueryHandler : IRequestHandler<GetFinAccountQuery, Application.Model.GeneralLedger.FinAccount>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetFinAccountQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.GeneralLedger.FinAccount> Handle(GetFinAccountQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.FinAccount
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FinAccount), request.Id);
            }

            return entity;

        }

    }
}
