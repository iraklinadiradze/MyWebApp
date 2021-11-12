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

namespace Application.Domains.Product.ProductGroupTemplate.Queries.GetProductGroupTemplateList
{

    public class GetProductGroupTemplateListQuery : IRequest<List<ProductGroupTemplateView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public String productGroupTemplateName {get;set;}
public Int32? productUnitId {get;set;}
    }

    public class GetProductGroupTemplateListQueryHandler : IRequestHandler<GetProductGroupTemplateListQuery, List<ProductGroupTemplateView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupTemplateListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductGroupTemplateView>> Handle(GetProductGroupTemplateListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductGroupTemplate
                         join _productUnit in _context.ProductUnit on e.ProductUnitId equals _productUnit.Id into __productUnit
 from _productUnit in __productUnit.DefaultIfEmpty()
                        select new ProductGroupTemplateView
                           {
                             Id= e.Id,
IsSingle= e.IsSingle,
IsTangible= e.IsTangible,
IsWholeQuantity= e.IsWholeQuantity,
ProductGroupTemplateName= e.ProductGroupTemplateName,
ProductUnitId= e.ProductUnitId,
productUnit = new ProductGroupTemplateView._ProductUnit{
Id= _productUnit.Id,
ProductUnitName= _productUnit.ProductUnitName
}
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.productGroupTemplateName!= null) 
 result = result.Where(r => r.ProductGroupTemplateName.StartsWith(request.productGroupTemplateName));

                if (request.productUnitId!= null) 
 result = result.Where(r => r.ProductUnitId== request.productUnitId);

            return (List<ProductGroupTemplateView>)await result.ToListAsync(cancellationToken);
        }

    }
}
