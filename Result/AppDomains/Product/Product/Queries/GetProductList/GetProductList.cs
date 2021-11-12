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

namespace Application.Domains.Product.Product.Queries.GetProductList
{

    public class GetProductListQuery : IRequest<List<ProductView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String productCode {get;set;}
public Int32? productGroupId {get;set;}
public Int32? productLabelId {get;set;}
public String productName {get;set;}
public Int32? productUnitId {get;set;}
    }

    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductView>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Product
                         join _productGroup in _context.ProductGroup on e.ProductGroupId equals _productGroup.Id into __productGroup
 from _productGroup in __productGroup.DefaultIfEmpty()
 join _productLabel in _context.ProductLabel on e.ProductLabelId equals _productLabel.Id into __productLabel
 from _productLabel in __productLabel.DefaultIfEmpty()
 join _productUnit in _context.ProductUnit on e.ProductUnitId equals _productUnit.Id into __productUnit
 from _productUnit in __productUnit.DefaultIfEmpty()
                        select new ProductView
                           {
                             Id= e.Id,
IsSingle= e.IsSingle,
IsTangible= e.IsTangible,
IsWholeQuantity= e.IsWholeQuantity,
ProductCode= e.ProductCode,
ProductGroupId= e.ProductGroupId,
ProductLabelId= e.ProductLabelId,
ProductName= e.ProductName,
ProductUnitId= e.ProductUnitId,
productGroup = new ProductView._ProductGroup{
Id= _productGroup.Id
},
productLabel = new ProductView._ProductLabel{
Id= _productLabel.Id,
ProductLabelName= _productLabel.ProductLabelName
},
productUnit = new ProductView._ProductUnit{
Id= _productUnit.Id,
ProductUnitName= _productUnit.ProductUnitName
}
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.productCode!= null) 
 result = result.Where(r => r.ProductCode== request.productCode);

                if (request.productGroupId!= null) 
 result = result.Where(r => r.ProductGroupId== request.productGroupId);

                if (request.productLabelId!= null) 
 result = result.Where(r => r.ProductLabelId== request.productLabelId);

                if (request.productName!= null) 
 result = result.Where(r => r.ProductName.StartsWith(request.productName));

                if (request.productUnitId!= null) 
 result = result.Where(r => r.ProductUnitId== request.productUnitId);

            return (List<ProductView>)await result.ToListAsync(cancellationToken);
        }

    }
}
