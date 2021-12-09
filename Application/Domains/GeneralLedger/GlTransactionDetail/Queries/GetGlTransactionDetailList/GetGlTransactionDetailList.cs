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

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Queries.GetGlTransactionDetailList
{

    public class GetGlTransactionDetailListQuery : IRequest<List<GlTransactionDetailView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? Id {get;set;}
    }

    public class GetGlTransactionDetailListQueryHandler : IRequestHandler<GetGlTransactionDetailListQuery, List<GlTransactionDetailView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlTransactionDetailListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<GlTransactionDetailView>> Handle(GetGlTransactionDetailListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.GlTransactionDetail
                         join _glAccount in _context.GlAccount on e.GlAccountId equals _glAccount.Id into __glAccount
 from _glAccount in __glAccount.DefaultIfEmpty()
 join _glTransaction in _context.GlTransaction on e.TransactionId equals _glTransaction.Id into __glTransaction
 from _glTransaction in __glTransaction.DefaultIfEmpty()
                        select new GlTransactionDetailView
                           {
                             Id= e.Id,
Amount= e.Amount,
Description= e.Description,
GlAccountId= e.GlAccountId,
IsDebit= e.IsDebit,
TransactionId= e.TransactionId,
glAccount = new GlTransactionDetailView._GlAccount{
Id= _glAccount.Id
},
glTransaction = new GlTransactionDetailView._GlTransaction{
Id= _glTransaction.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<GlTransactionDetailView>)await result.ToListAsync(cancellationToken);
        }

    }
}
