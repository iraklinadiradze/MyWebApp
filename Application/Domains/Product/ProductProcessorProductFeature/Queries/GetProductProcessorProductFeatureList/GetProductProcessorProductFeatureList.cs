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

namespace Application.Domains.Product.ProductProcessorProductFeature.Queries.GetProductProcessorProductFeatureList
{

    public class GetProductProcessorProductFeatureListQuery : IRequest<List<ProductProcessorProductFeatureView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetProductProcessorProductFeatureListQueryHandler : IRequestHandler<GetProductProcessorProductFeatureListQuery, List<ProductProcessorProductFeatureView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorProductFeatureListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductProcessorProductFeatureView>> Handle(GetProductProcessorProductFeatureListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductProcessorProductFeature
                         join _productProcessorDetail in _context.ProductProcessorDetail on e.ProductProcessorDetailId equals _productProcessorDetail.Id into __productProcessorDetail
 from _productProcessorDetail in __productProcessorDetail.DefaultIfEmpty()
                        select new ProductProcessorProductFeatureView
                           {
                             Id= e.Id,
FeatureId= e.FeatureId,
FeatureName= e.FeatureName,
FeatureValue= e.FeatureValue,
FeatureValueId= e.FeatureValueId,
FeatureValueIdDictionary= e.FeatureValueIdDictionary,
ProductProcessorDetailId= e.ProductProcessorDetailId,
productProcessorDetail = new ProductProcessorProductFeatureView._ProductProcessorDetail{
Id= _productProcessorDetail.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<ProductProcessorProductFeatureView>)await result.ToListAsync(cancellationToken);
        }

    }
}
