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

namespace Application.Domains.Account.Transaction.Queries.GetTransactionList
{

    public class GetTransactionListQuery : IRequest<List<TransactionView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? Id {get;set;}
    }

    public class GetTransactionListQueryHandler : IRequestHandler<GetTransactionListQuery, List<TransactionView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetTransactionListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<TransactionView>> Handle(GetTransactionListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Transaction
                         join _account in _context.Account on e.AccountId equals _account.Id into __account
 from _account in __account.DefaultIfEmpty()
 join _transactionOrder in _context.TransactionOrder on e.PostOrderRefId equals _transactionOrder.Id into __transactionOrder
 from _transactionOrder in __transactionOrder.DefaultIfEmpty()
                        select new TransactionView
                           {
                             Id= e.Id,
AccountId= e.AccountId,
AccountTranSeq= e.AccountTranSeq,
Eod= e.Eod,
PostOrderRefId= e.PostOrderRefId,
PostTime= e.PostTime,
RefVersion= e.RefVersion,
ReferenceEntityId= e.ReferenceEntityId,
ReferenceId= e.ReferenceId,
SubReferenceEntityId= e.SubReferenceEntityId,
SubReferenceId= e.SubReferenceId,
TransDate= e.TransDate,
balance= e.balance,
decrease= e.decrease,
increase= e.increase,
account = new TransactionView._Account{
Id= _account.Id
},
transactionOrder = new TransactionView._TransactionOrder{
Id= _transactionOrder.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<TransactionView>)await result.ToListAsync(cancellationToken);
        }

    }
}
