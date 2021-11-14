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

namespace Application.Domains.Product.ProductFeature.Queries.GetProductFeatureList
{

    public class GetProductFeatureListQuery : IRequest<List<ProductFeatureView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? FeatureValueId {get;set;}
public Int32? ProductId {get;set;}
    }

    public class GetProductFeatureListQueryHandler : IRequestHandler<GetProductFeatureListQuery, List<ProductFeatureView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductFeatureListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductFeatureView>> Handle(GetProductFeatureListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductFeature
                         join _featureValue in _context.FeatureValue on e.FeatureValueId equals _featureValue.Id into __featureValue
 from _featureValue in __featureValue.DefaultIfEmpty()
 join _product in _context.Product on e.ProductId equals _product.Id into __product
 from _product in __product.DefaultIfEmpty()
                        select new ProductFeatureView
                           {
                             Id= e.Id,
FeatureValueId= e.FeatureValueId,
ProductId= e.ProductId,
featureValue = new ProductFeatureView._FeatureValue{
Id= _featureValue.Id,
FeatureValueName= _featureValue.FeatureValueName
},
product = new ProductFeatureView._Product{
Id= _product.Id,
ProductName= _product.ProductName
}
                           };


                            if (request.FeatureValueId!= null) 
 result = result.Where(r => r.FeatureValueId== request.FeatureValueId);

                if (request.ProductId!= null) 
 result = result.Where(r => r.ProductId== request.ProductId);

            return (List<ProductFeatureView>)await result.ToListAsync(cancellationToken);
        }

    }
}
