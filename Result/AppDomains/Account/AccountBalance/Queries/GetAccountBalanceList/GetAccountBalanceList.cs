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

namespace Application.Domains.Account.AccountBalance.Queries.GetAccountBalanceList
{

    public class GetAccountBalanceListQuery : IRequest<List<AccountBalanceView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? id {get;set;}
    }

    public class GetAccountBalanceListQueryHandler : IRequestHandler<GetAccountBalanceListQuery, List<AccountBalanceView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetAccountBalanceListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<AccountBalanceView>> Handle(GetAccountBalanceListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.AccountBalance
                         join _account in _context.Account on e.AccountId equals _account.Id into __account
 from _account in __account.DefaultIfEmpty()
                        select new AccountBalanceView
                           {
                             Id= e.Id,
AccountBalanceCount= e.AccountBalanceCount,
AccountId= e.AccountId,
BalanceTransactionId= e.BalanceTransactionId,
MaxPostTime= e.MaxPostTime,
TransDate= e.TransDate,
balance= e.balance,
decrease= e.decrease,
increase= e.increase,
account = new AccountBalanceView._Account{
Id= _account.Id
}
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

            return (List<AccountBalanceView>)await result.ToListAsync(cancellationToken);
        }

    }
}
