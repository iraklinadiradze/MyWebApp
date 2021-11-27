using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseDetail.Queries.GetPurchaseDetailList
{

    public class GetPurchaseDetailListQuery : IRequest<List<PurchaseDetailView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetPurchaseDetailListQueryHandler : IRequestHandler<GetPurchaseDetailListQuery, List<PurchaseDetailView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseDetailListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PurchaseDetailView>> Handle(GetPurchaseDetailListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.PurchaseDetail
                         join _inventory in _context.Inventory on e.InventoryId equals _inventory.Id into __inventory
 from _inventory in __inventory.DefaultIfEmpty()
 join _location in _context.Location on e.LocationId equals _location.Id into __location
 from _location in __location.DefaultIfEmpty()
 join _purchase in _context.Purchase on e.PurchaseId equals _purchase.Id into __purchase
 from _purchase in __purchase.DefaultIfEmpty()
 join _purchaseDetailPostType in _context.PurchaseDetailPostType on e.PurchaseDetailPostTypeId equals _purchaseDetailPostType.Id into __purchaseDetailPostType
 from _purchaseDetailPostType in __purchaseDetailPostType.DefaultIfEmpty()
 join _product in _context.Product on e.ProductId equals _product.Id into __product
 from _product in __product.DefaultIfEmpty()
                        select new PurchaseDetailView
                           {
                             Id= e.Id,
AddCost= e.AddCost,
Allocated= e.Allocated,
CostCalculated= e.CostCalculated,
CostCalculatedEqu= e.CostCalculatedEqu,
CostInvoiced= e.CostInvoiced,
CostInvoicedEqu= e.CostInvoicedEqu,
CostInvoicedWithoutVat= e.CostInvoicedWithoutVat,
FinPosted= e.FinPosted,
FinalCost= e.FinalCost,
GlAccountId= e.GlAccountId,
InventoryCode= e.InventoryCode,
InventoryId= e.InventoryId,
LocationId= e.LocationId,
Posted= e.Posted,
ProductId= e.ProductId,
ProjectId= e.ProjectId,
PurchaseDetailPostTypeId= e.PurchaseDetailPostTypeId,
PurchaseDraftId= e.PurchaseDraftId,
PurchaseDraftVersion= e.PurchaseDraftVersion,
PurchaseId= e.PurchaseId,
QtyCalculated= e.QtyCalculated,
QtyInvoiced= e.QtyInvoiced,
QtyPosted= e.QtyPosted,
StockProductPerProcess= e.StockProductPerProcess,
VatInvoiced= e.VatInvoiced,
inventory = new PurchaseDetailView._Inventory{
Id= _inventory.Id,
InventoryCode= _inventory.InventoryCode
},
location = new PurchaseDetailView._Location{
Id= _location.Id,
Name= _location.Name
},
purchase = new PurchaseDetailView._Purchase{
Id= _purchase.Id
},
purchaseDetailPostType = new PurchaseDetailView._PurchaseDetailPostType{
Id= _purchaseDetailPostType.Id
},
product = new PurchaseDetailView._Product{
Id= _product.Id,
ProductName= _product.ProductName
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<PurchaseDetailView>)await result.ToListAsync(cancellationToken);
        }

    }
}
