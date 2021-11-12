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

namespace Application.Domains.Product.ProductCategory.Queries.GetProductCategoryList
{

    public class GetProductCategoryListQuery : IRequest<List<ProductCategoryView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String productCategoryName {get;set;}
    }

    public class GetProductCategoryListQueryHandler : IRequestHandler<GetProductCategoryListQuery, List<ProductCategoryView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductCategoryListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductCategoryView>> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductCategory
                        
                        select new ProductCategoryView
                           {
                             Id= e.Id,
ProductCategoryName= e.ProductCategoryName
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.productCategoryName!= null) 
 result = result.Where(r => r.ProductCategoryName== request.productCategoryName);

            return (List<ProductCategoryView>)await result.ToListAsync(cancellationToken);
        }

    }
}
