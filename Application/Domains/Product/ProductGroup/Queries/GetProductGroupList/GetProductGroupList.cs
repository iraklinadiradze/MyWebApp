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

namespace Application.Domains.Product.ProductGroup.Queries.GetProductGroupList
{

    public class GetProductGroupListQuery : IRequest<List<ProductGroupView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public Int32? ProductCategoryId {get;set;}
public String ProductGroupName {get;set;}
public Int32? ProductGroupTemplateId {get;set;}
    }

    public class GetProductGroupListQueryHandler : IRequestHandler<GetProductGroupListQuery, List<ProductGroupView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductGroupListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductGroupView>> Handle(GetProductGroupListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductGroup
                         join _productCategory in _context.ProductCategory on e.ProductCategoryId equals _productCategory.Id into __productCategory
 from _productCategory in __productCategory.DefaultIfEmpty()
 join _productGroupTemplate in _context.ProductGroupTemplate on e.ProductGroupTemplateId equals _productGroupTemplate.Id into __productGroupTemplate
 from _productGroupTemplate in __productGroupTemplate.DefaultIfEmpty()
                        select new ProductGroupView
                           {
                             Id= e.Id,
ProductCategoryId= e.ProductCategoryId,
ProductGroupName= e.ProductGroupName,
ProductGroupTemplateId= e.ProductGroupTemplateId,
productCategory = new ProductGroupView._ProductCategory{
Id= _productCategory.Id
},
productGroupTemplate = new ProductGroupView._ProductGroupTemplate{
Id= _productGroupTemplate.Id,
ProductGroupTemplateName= _productGroupTemplate.ProductGroupTemplateName
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.ProductCategoryId!= null) 
 result = result.Where(r => r.ProductCategoryId== request.ProductCategoryId);

                if (request.ProductGroupName!= null) 
 result = result.Where(r => r.ProductGroupName== request.ProductGroupName);

                if (request.ProductGroupTemplateId!= null) 
 result = result.Where(r => r.ProductGroupTemplateId== request.ProductGroupTemplateId);

            return (List<ProductGroupView>)await result.ToListAsync(cancellationToken);
        }

    }
}
