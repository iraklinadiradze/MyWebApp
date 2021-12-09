using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Account;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Account.AccountBalance.Queries.GetAccountBalance
{

    public class GetAccountBalanceQuery : IRequest<Application.Model.Account.AccountBalance>
    {
        public int? Id { get; set; }
    }

    public class GetAccountBalanceQueryHandler : IRequestHandler<GetAccountBalanceQuery, Application.Model.Account.AccountBalance>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetAccountBalanceQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.Account.AccountBalance> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.AccountBalance
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AccountBalance), request.Id);
            }

            return entity;

        }

    }
}
