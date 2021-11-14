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

namespace Application.Domains.Product.ProductLabel.Queries.GetProductLabelList
{

    public class GetProductLabelListQuery : IRequest<List<ProductLabelView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public Int32? BrandId {get;set;}
public String ProductLabelName {get;set;}
    }

    public class GetProductLabelListQueryHandler : IRequestHandler<GetProductLabelListQuery, List<ProductLabelView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductLabelListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductLabelView>> Handle(GetProductLabelListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductLabel
                         join _brand in _context.Brand on e.BrandId equals _brand.Id into __brand
 from _brand in __brand.DefaultIfEmpty()
                        select new ProductLabelView
                           {
                             Id= e.Id,
BrandId= e.BrandId,
ProductLabelName= e.ProductLabelName,
brand = new ProductLabelView._Brand{
Id= _brand.Id,
BrandName= _brand.BrandName
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.BrandId!= null) 
 result = result.Where(r => r.BrandId== request.BrandId);

                if (request.ProductLabelName!= null) 
 result = result.Where(r => r.ProductLabelName.StartsWith(request.ProductLabelName));

            return (List<ProductLabelView>)await result.ToListAsync(cancellationToken);
        }

    }
}
