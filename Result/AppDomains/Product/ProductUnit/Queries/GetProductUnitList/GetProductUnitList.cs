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

namespace Application.Domains.Product.ProductUnit.Queries.GetProductUnitList
{

    public class GetProductUnitListQuery : IRequest<List<ProductUnitView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String productUnitName {get;set;}
    }

    public class GetProductUnitListQueryHandler : IRequestHandler<GetProductUnitListQuery, List<ProductUnitView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductUnitListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductUnitView>> Handle(GetProductUnitListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductUnit
                        
                        select new ProductUnitView
                           {
                             Id= e.Id,
ProductUnitName= e.ProductUnitName
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.productUnitName!= null) 
 result = result.Where(r => r.ProductUnitName.StartsWith(request.productUnitName));

            return (List<ProductUnitView>)await result.ToListAsync(cancellationToken);
        }

    }
}
