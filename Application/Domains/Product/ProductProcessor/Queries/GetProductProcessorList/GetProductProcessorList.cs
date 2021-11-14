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

namespace Application.Domains.Product.ProductProcessor.Queries.GetProductProcessorList
{

    public class GetProductProcessorListQuery : IRequest<List<ProductProcessorView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetProductProcessorListQueryHandler : IRequestHandler<GetProductProcessorListQuery, List<ProductProcessorView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetProductProcessorListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<ProductProcessorView>> Handle(GetProductProcessorListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.ProductProcessor
                        
                        select new ProductProcessorView
                           {
                             Id= e.Id,
IdentifyProducts= e.IdentifyProducts,
IdentifyProductsAfterRegistration= e.IdentifyProductsAfterRegistration,
PurchaseId= e.PurchaseId,
RegisterBrandProps= e.RegisterBrandProps,
RegisterProducts= e.RegisterProducts,
RegisterPurchaseDetails= e.RegisterPurchaseDetails,
RegisterSalesPrices= e.RegisterSalesPrices
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<ProductProcessorView>)await result.ToListAsync(cancellationToken);
        }

    }
}
