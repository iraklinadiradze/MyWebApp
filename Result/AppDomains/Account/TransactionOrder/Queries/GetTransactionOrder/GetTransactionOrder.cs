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

namespace Application.Domains.Account.TransactionOrder.Queries.GetTransactionOrder
{

    public class GetTransactionOrderQuery : IRequest<DataAccessLayer.Model.Account.TransactionOrder>
    {
        public int? Id { get; set; }
    }

    public class GetTransactionOrderQueryHandler : IRequestHandler<GetTransactionOrderQuery, DataAccessLayer.Model.Account.TransactionOrder>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetTransactionOrderQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.Account.TransactionOrder> Handle(GetTransactionOrderQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.TransactionOrder
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TransactionOrder), request.Id);
            }

            return entity;

        }

    }
}
