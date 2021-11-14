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

namespace Application.Domains.Account.TransactionOrder.Queries.GetTransactionOrderList
{

    public class GetTransactionOrderListQuery : IRequest<List<TransactionOrderView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? Id {get;set;}
    }

    public class GetTransactionOrderListQueryHandler : IRequestHandler<GetTransactionOrderListQuery, List<TransactionOrderView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetTransactionOrderListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<TransactionOrderView>> Handle(GetTransactionOrderListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.TransactionOrder
                        
                        select new TransactionOrderView
                           {
                             Id= e.Id,
PostTime= e.PostTime,
ReferenceEntityId= e.ReferenceEntityId,
ReferenceId= e.ReferenceId,
SubReferenceEntityId= e.SubReferenceEntityId,
SubReferenceId= e.SubReferenceId,
TransDate= e.TransDate
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<TransactionOrderView>)await result.ToListAsync(cancellationToken);
        }

    }
}
