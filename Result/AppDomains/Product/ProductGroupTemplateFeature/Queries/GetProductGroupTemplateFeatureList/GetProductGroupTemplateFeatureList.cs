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

namespace Application.Domains.Product.ProductGroupTemplateFeature.Queries.GetProductGroupTemplateFeatureList
{

    public class GetProductGroupTemplateFeatureListQuery : IRequest<List<ProductGroupTemplateFeatureView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public Int32? featureId {get;set;}
public Int32? productGroupTemplateId {get;set;}
    }

    public class GetProductGroupTemplateFeatureListQueryHandler : IRequestHandler<GetProductGroupTemplateFeatureListQuery, List<ProductGroupTemplateFeatureView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupTemplateFeatureListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductGroupTemplateFeatureView>> Handle(GetProductGroupTemplateFeatureListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductGroupTemplateFeature
                         join _feature in _context.Feature on e.FeatureId equals _feature.Id into __feature
 from _feature in __feature.DefaultIfEmpty()
 join _productGroupTemplate in _context.ProductGroupTemplate on e.ProductGroupTemplateId equals _productGroupTemplate.Id into __productGroupTemplate
 from _productGroupTemplate in __productGroupTemplate.DefaultIfEmpty()
                        select new ProductGroupTemplateFeatureView
                           {
                             Id= e.Id,
FeatureId= e.FeatureId,
IsMandatory= e.IsMandatory,
ProductGroupTemplateId= e.ProductGroupTemplateId,
feature = new ProductGroupTemplateFeatureView._Feature{
Id= _feature.Id,
FeatureName= _feature.FeatureName
},
productGroupTemplate = new ProductGroupTemplateFeatureView._ProductGroupTemplate{
Id= _productGroupTemplate.Id,
ProductGroupTemplateName= _productGroupTemplate.ProductGroupTemplateName
}
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.featureId!= null) 
 result = result.Where(r => r.FeatureId== request.featureId);

                if (request.productGroupTemplateId!= null) 
 result = result.Where(r => r.ProductGroupTemplateId== request.productGroupTemplateId);

            return (List<ProductGroupTemplateFeatureView>)await result.ToListAsync(cancellationToken);
        }

    }
}
