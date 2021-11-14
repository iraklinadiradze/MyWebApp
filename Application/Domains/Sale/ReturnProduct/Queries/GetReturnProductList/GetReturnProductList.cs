using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.ReturnProduct.Queries.GetReturnProductList
{

    public class GetReturnProductListQuery : IRequest<List<ReturnProductView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetReturnProductListQueryHandler : IRequestHandler<GetReturnProductListQuery, List<ReturnProductView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetReturnProductListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ReturnProductView>> Handle(GetReturnProductListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ReturnProduct
                         join _sale in _context.Sale on e.SaleId equals _sale.Id into __sale
 from _sale in __sale.DefaultIfEmpty()
                        select new ReturnProductView
                           {
                             Id= e.Id,
Cogs= e.Cogs,
ConsultantId= e.ConsultantId,
FinPostStarted= e.FinPostStarted,
FinPosted= e.FinPosted,
InventoryId= e.InventoryId,
NominalPrice= e.NominalPrice,
NominalPriceDiscount= e.NominalPriceDiscount,
Note= e.Note,
OwnerId= e.OwnerId,
Posted= e.Posted,
Qty= e.Qty,
QtyPostStarted= e.QtyPostStarted,
QtyPosted= e.QtyPosted,
Revenue= e.Revenue,
SaleId= e.SaleId,
SalePrice= e.SalePrice,
SchemaPrice= e.SchemaPrice,
TotalPrice= e.TotalPrice,
VatAmount= e.VatAmount,
VatRate= e.VatRate,
sale = new ReturnProductView._Sale{
Id= _sale.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<ReturnProductView>)await result.ToListAsync(cancellationToken);
        }

    }
}
