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

namespace Application.Domains.Product.Brand.Queries.GetBrandList
{

    public class GetBrandListQuery : IRequest<List<BrandView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String brandName {get;set;}
    }

    public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, List<BrandView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetBrandListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<BrandView>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Brand
                        
                        select new BrandView
                           {
                             Id= e.Id,
BrandName= e.BrandName
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.brandName!= null) 
 result = result.Where(r => r.BrandName.StartsWith(request.brandName));

            return (List<BrandView>)await result.ToListAsync(cancellationToken);
        }

    }
}
