using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Sale;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.SaleSchema.Queries.GetSaleSchemaList
{

    public class GetSaleSchemaListQuery : IRequest<List<SaleSchemaView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetSaleSchemaListQueryHandler : IRequestHandler<GetSaleSchemaListQuery, List<SaleSchemaView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleSchemaListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<SaleSchemaView>> Handle(GetSaleSchemaListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.SaleSchema
                        
                        select new SaleSchemaView
                           {
                             Id= e.Id,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<SaleSchemaView>)await result.ToListAsync(cancellationToken);
        }

    }
}
