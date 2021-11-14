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

namespace Application.Domains.Sale.SaleSchemaDetail.Queries.GetSaleSchemaDetailList
{

    public class GetSaleSchemaDetailListQuery : IRequest<List<SaleSchemaDetailView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetSaleSchemaDetailListQueryHandler : IRequestHandler<GetSaleSchemaDetailListQuery, List<SaleSchemaDetailView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleSchemaDetailListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<SaleSchemaDetailView>> Handle(GetSaleSchemaDetailListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.SaleSchemaDetail
                         join _product in _context.Product on e.ProductId equals _product.Id into __product
 from _product in __product.DefaultIfEmpty()
 join _saleSchema in _context.SaleSchema on e.SaleSchemaId equals _saleSchema.Id into __saleSchema
 from _saleSchema in __saleSchema.DefaultIfEmpty()
                        select new SaleSchemaDetailView
                           {
                             Id= e.Id,
Discount= e.Discount,
Name= e.Name,
Price= e.Price,
ProductId= e.ProductId,
SaleSchemaId= e.SaleSchemaId,
product = new SaleSchemaDetailView._Product{
Id= _product.Id,
ProductName= _product.ProductName
},
saleSchema = new SaleSchemaDetailView._SaleSchema{
Id= _saleSchema.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<SaleSchemaDetailView>)await result.ToListAsync(cancellationToken);
        }

    }
}
