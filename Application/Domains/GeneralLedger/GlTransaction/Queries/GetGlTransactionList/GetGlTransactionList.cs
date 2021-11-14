using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.GeneralLedger.GlTransaction.Queries.GetGlTransactionList
{

    public class GetGlTransactionListQuery : IRequest<List<GlTransactionView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int64? Id {get;set;}
    }

    public class GetGlTransactionListQueryHandler : IRequestHandler<GetGlTransactionListQuery, List<GlTransactionView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlTransactionListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<GlTransactionView>> Handle(GetGlTransactionListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.GlTransaction
                        
                        select new GlTransactionView
                           {
                             Id= e.Id,
Description= e.Description,
OwnerId= e.OwnerId,
TransDate= e.TransDate
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<GlTransactionView>)await result.ToListAsync(cancellationToken);
        }

    }
}
