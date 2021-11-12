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

namespace Application.Domains.Product.Feature.Queries.GetFeatureList
{

    public class GetFeatureListQuery : IRequest<List<FeatureView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String featureName {get;set;}
    }

    public class GetFeatureListQueryHandler : IRequestHandler<GetFeatureListQuery, List<FeatureView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetFeatureListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<FeatureView>> Handle(GetFeatureListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Feature
                        
                        select new FeatureView
                           {
                             Id= e.Id,
FeatureName= e.FeatureName,
ts= e.ts
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.featureName!= null) 
 result = result.Where(r => r.FeatureName.StartsWith(request.featureName));

            return (List<FeatureView>)await result.ToListAsync(cancellationToken);
        }

    }
}
