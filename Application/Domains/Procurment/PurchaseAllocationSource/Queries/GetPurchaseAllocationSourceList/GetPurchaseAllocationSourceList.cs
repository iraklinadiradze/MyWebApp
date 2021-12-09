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

namespace Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSourceList
{

    public class GetPurchaseAllocationSourceListQuery : IRequest<List<PurchaseAllocationSourceView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetPurchaseAllocationSourceListQueryHandler : IRequestHandler<GetPurchaseAllocationSourceListQuery, List<PurchaseAllocationSourceView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSourceListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PurchaseAllocationSourceView>> Handle(GetPurchaseAllocationSourceListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.PurchaseAllocationSource
                         join _purchase in _context.Purchase on e.PurchaseId equals _purchase.Id into __purchase
 from _purchase in __purchase.DefaultIfEmpty()
 join _purchaseAllocationSchema in _context.PurchaseAllocationSchema on e.PurchaseAllocSchemaId equals _purchaseAllocationSchema.Id into __purchaseAllocationSchema
 from _purchaseAllocationSchema in __purchaseAllocationSchema.DefaultIfEmpty()
 join _purchaseAllocationSourceType in _context.PurchaseAllocationSourceType on e.PurchaseAllocationSourceTypeId equals _purchaseAllocationSourceType.Id into __purchaseAllocationSourceType
 from _purchaseAllocationSourceType in __purchaseAllocationSourceType.DefaultIfEmpty()
 join _purchaseDetail in _context.PurchaseDetail on e.AllocPurchaseDetailId equals _purchaseDetail.Id into __purchaseDetail
 from _purchaseDetail in __purchaseDetail.DefaultIfEmpty()
                        select new PurchaseAllocationSourceView
                           {
                             Id= e.Id,
AllocPurchaseDetailId= e.AllocPurchaseDetailId,
GlAccountId= e.GlAccountId,
PurchaseAllocSchemaId= e.PurchaseAllocSchemaId,
PurchaseAllocationSourceTypeId= e.PurchaseAllocationSourceTypeId,
PurchaseId= e.PurchaseId,
purchase = new PurchaseAllocationSourceView._Purchase{
Id= _purchase.Id
},
purchaseAllocationSchema = new PurchaseAllocationSourceView._PurchaseAllocationSchema{
Id= _purchaseAllocationSchema.Id
},
purchaseAllocationSourceType = new PurchaseAllocationSourceView._PurchaseAllocationSourceType{
Id= _purchaseAllocationSourceType.Id
},
purchaseDetail = new PurchaseAllocationSourceView._PurchaseDetail{
Id= _purchaseDetail.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<PurchaseAllocationSourceView>)await result.ToListAsync(cancellationToken);
        }

    }
}
