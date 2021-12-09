using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Product;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Product.ProductProcessorSalePrice.Queries.GetProductProcessorSalePriceList
{

    public class GetProductProcessorSalePriceListQuery : IRequest<List<ProductProcessorSalePriceView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetProductProcessorSalePriceListQueryHandler : IRequestHandler<GetProductProcessorSalePriceListQuery, List<ProductProcessorSalePriceView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorSalePriceListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductProcessorSalePriceView>> Handle(GetProductProcessorSalePriceListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductProcessorSalePrice
                         join _productProcessorDetail in _context.ProductProcessorDetail on e.ProductProcessorDetailId equals _productProcessorDetail.Id into __productProcessorDetail
 from _productProcessorDetail in __productProcessorDetail.DefaultIfEmpty()
                        select new ProductProcessorSalePriceView
                           {
                             Id= e.Id,
ProductProcessorDetailId= e.ProductProcessorDetailId,
SalePrice= e.SalePrice,
SaleSchemaId= e.SaleSchemaId,
productProcessorDetail = new ProductProcessorSalePriceView._ProductProcessorDetail{
Id= _productProcessorDetail.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<ProductProcessorSalePriceView>)await result.ToListAsync(cancellationToken);
        }

    }
}
