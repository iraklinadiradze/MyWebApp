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

          public Int32? Id {get;set;}
public String ProductGroupTemplateName {get;set;}
public Int32? ProductUnitId {get;set;}
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


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.ProductGroupTemplateName!= null) 
 result = result.Where(r => r.ProductGroupTemplateName.StartsWith(request.ProductGroupTemplateName));

                if (request.ProductUnitId!= null) 
 result = result.Where(r => r.ProductUnitId== request.ProductUnitId);

            return (List<ProductGroupTemplateView>)await result.ToListAsync(cancellationToken);
        }

    }
}
