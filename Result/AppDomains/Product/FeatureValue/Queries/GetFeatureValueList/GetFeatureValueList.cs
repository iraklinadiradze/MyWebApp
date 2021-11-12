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

namespace Application.Domains.Product.FeatureValue.Queries.GetFeatureValueList
{

    public class GetFeatureValueListQuery : IRequest<List<FeatureValueView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public Int32? featureId {get;set;}
public Int32? featureValueName {get;set;}
    }

    public class GetFeatureValueListQueryHandler : IRequestHandler<GetFeatureValueListQuery, List<FeatureValueView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetFeatureValueListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<FeatureValueView>> Handle(GetFeatureValueListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.FeatureValue
                         join _feature in _context.Feature on e.FeatureId equals _feature.Id into __feature
 from _feature in __feature.DefaultIfEmpty()
                        select new FeatureValueView
                           {
                             Id= e.Id,
FeatureId= e.FeatureId,
FeatureValueName= e.FeatureValueName,
feature = new FeatureValueView._Feature{
Id= _feature.Id,
FeatureName= _feature.FeatureName
}
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.featureId!= null) 
 result = result.Where(r => r.FeatureId== request.featureId);

                if (request.featureValueName!= null) 
 result = result.Where(r => r.FeatureValueName.StartsWith(request.featureValueName));

            return (List<FeatureValueView>)await result.ToListAsync(cancellationToken);
        }

    }
}
