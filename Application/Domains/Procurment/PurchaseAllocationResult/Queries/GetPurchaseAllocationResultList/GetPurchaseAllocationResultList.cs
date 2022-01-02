using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Procurment;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseAllocationResult.Queries.GetPurchaseAllocationResultList
{

    public class GetPurchaseAllocationResultListQuery : IRequest<List<PurchaseAllocationResultView>>
    {
        //        public int? id { get; set; }
        //        public int? topRecords { get; set; }
        //        public string? name { get; set; }

        public Int32? Id { get; set; }
    }

    public class GetPurchaseAllocationResultListQueryHandler : IRequestHandler<GetPurchaseAllocationResultListQuery, List<PurchaseAllocationResultView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationResultListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PurchaseAllocationResultView>> Handle(GetPurchaseAllocationResultListQuery request, CancellationToken cancellationToken)
        {

            var result = from e in _context.PurchaseAllocationResult
                         join _purchaseAllocationSource in _context.PurchaseAllocationSource on e.PurchaseAllocationSourceId equals _purchaseAllocationSource.Id into __purchaseAllocationSource
                         from _purchaseAllocationSource in __purchaseAllocationSource.DefaultIfEmpty()
                         join _purchaseDetail in _context.PurchaseDetail on e.PurchaseDetailId equals _purchaseDetail.Id into __purchaseDetail
                         from _purchaseDetail in __purchaseDetail.DefaultIfEmpty()
                         select new PurchaseAllocationResultView
                         {
                             Id = e.Id,
                             Amount = e.Amount,
                             PurchaseAllocationSourceId = e.PurchaseAllocationSourceId,
                             PurchaseDetailId = e.PurchaseDetailId,
                             purchaseAllocationSource = new PurchaseAllocationResultView._PurchaseAllocationSource
                             {
                                 Id = _purchaseAllocationSource.Id
                             },
                             purchaseDetail = new PurchaseAllocationResultView._PurchaseDetail
                             {
                                 Id = _purchaseDetail.Id
                             }
                         };


            if (request.Id != null)
                result = result.Where(r => r.Id == request.Id);

            return (List<PurchaseAllocationResultView>)await result.ToListAsync(cancellationToken);
        }

    }
}
