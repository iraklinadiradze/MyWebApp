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

namespace Application.Domains.Product.ProductGroupTemplateFeature.Queries.GetProductGroupTemplateFeatureList
{

    public class GetProductGroupTemplateFeatureListQuery : IRequest<List<ProductGroupTemplateFeatureView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public Int32? FeatureId {get;set;}
public Int32? ProductGroupTemplateId {get;set;}
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


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.FeatureId!= null) 
 result = result.Where(r => r.FeatureId== request.FeatureId);

                if (request.ProductGroupTemplateId!= null) 
 result = result.Where(r => r.ProductGroupTemplateId== request.ProductGroupTemplateId);

            return (List<ProductGroupTemplateFeatureView>)await result.ToListAsync(cancellationToken);
        }

    }
}
