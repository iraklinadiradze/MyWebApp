using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Product.ProductProcessorDetail.Queries.GetProductProcessorDetailList
{

    public class GetProductProcessorDetailListQuery : IRequest<List<ProductProcessorDetailView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetProductProcessorDetailListQueryHandler : IRequestHandler<GetProductProcessorDetailListQuery, List<ProductProcessorDetailView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorDetailListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductProcessorDetailView>> Handle(GetProductProcessorDetailListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductProcessorDetail
                         join _productProcessor in _context.ProductProcessor on e.ProductProcessorId equals _productProcessor.Id into __productProcessor
 from _productProcessor in __productProcessor.DefaultIfEmpty()
                        select new ProductProcessorDetailView
                           {
                             Id= e.Id,
BrandId= e.BrandId,
BrandIdDictionary= e.BrandIdDictionary,
BrandName= e.BrandName,
Cost= e.Cost,
LocationId= e.LocationId,
ProductCode= e.ProductCode,
ProductGroupId= e.ProductGroupId,
ProductGroupIdDictionary= e.ProductGroupIdDictionary,
ProductGroupName= e.ProductGroupName,
ProductId= e.ProductId,
ProductLabelId= e.ProductLabelId,
ProductLabelIdDictionary= e.ProductLabelIdDictionary,
ProductLabelName= e.ProductLabelName,
ProductProcessorId= e.ProductProcessorId,
Qty= e.Qty,
productProcessor = new ProductProcessorDetailView._ProductProcessor{
Id= _productProcessor.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<ProductProcessorDetailView>)await result.ToListAsync(cancellationToken);
        }

    }
}
