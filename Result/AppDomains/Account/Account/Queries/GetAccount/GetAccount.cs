using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Account;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Account.Account.Queries.GetAccount
{

    public class GetAccountQuery : IRequest<DataAccessLayer.Model.Account.Account>
    {
        public int? Id { get; set; }
    }

    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, DataAccessLayer.Model.Account.Account>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetAccountQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Account.Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Account
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Account), request.Id);
            }

            return entity;

        }

    }
}
