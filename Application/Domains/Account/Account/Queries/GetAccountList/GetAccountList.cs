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

namespace Application.Domains.Account.Account.Queries.GetAccountList
{

    public class GetAccountListQuery : IRequest<List<AccountView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? Id {get;set;}
    }

    public class GetAccountListQueryHandler : IRequestHandler<GetAccountListQuery, List<AccountView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetAccountListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<AccountView>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Account
                         join _accountDimension in _context.AccountDimension on e.AccountDimensionId equals _accountDimension.Id into __accountDimension
 from _accountDimension in __accountDimension.DefaultIfEmpty()
                        select new AccountView
                           {
                             Id= e.Id,
AccountDimensionId= e.AccountDimensionId,
EntityForeignId1= e.EntityForeignId1,
EntityForeignId2= e.EntityForeignId2,
EntityForeignId3= e.EntityForeignId3,
EntityForeignId4= e.EntityForeignId4,
EntityForeignId5= e.EntityForeignId5,
EntityForeignId6= e.EntityForeignId6,
accountDimension = new AccountView._AccountDimension{
Id= _accountDimension.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<AccountView>)await result.ToListAsync(cancellationToken);
        }

    }
}
