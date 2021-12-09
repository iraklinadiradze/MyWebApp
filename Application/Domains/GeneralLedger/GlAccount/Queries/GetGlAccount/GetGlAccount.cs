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

namespace Application.Domains.GeneralLedger.GlAccount.Queries.GetGlAccount
{

    public class GetGlAccountQuery : IRequest<Application.Model.GeneralLedger.GlAccount>
    {
        public int? Id { get; set; }
    }

    public class GetGlAccountQueryHandler : IRequestHandler<GetGlAccountQuery, Application.Model.GeneralLedger.GlAccount>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlAccountQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.GeneralLedger.GlAccount> Handle(GetGlAccountQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.GlAccount
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GlAccount), request.Id);
            }

            return entity;

        }

    }
}
