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

namespace Application.Domains.Account.Transaction.Queries.GetTransaction
{

    public class GetTransactionQuery : IRequest<DataAccessLayer.Model.Account.Transaction>
    {
        public int? Id { get; set; }
    }

    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, DataAccessLayer.Model.Account.Transaction>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetTransactionQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Account.Transaction> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Transaction
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            return entity;

        }

    }
}
