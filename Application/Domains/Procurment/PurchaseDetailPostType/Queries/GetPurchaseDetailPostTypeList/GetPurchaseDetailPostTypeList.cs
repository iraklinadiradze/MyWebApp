using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Procurment;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseDetailPostType.Queries.GetPurchaseDetailPostTypeList
{

    public class GetPurchaseDetailPostTypeListQuery : IRequest<List<PurchaseDetailPostTypeView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetPurchaseDetailPostTypeListQueryHandler : IRequestHandler<GetPurchaseDetailPostTypeListQuery, List<PurchaseDetailPostTypeView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseDetailPostTypeListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PurchaseDetailPostTypeView>> Handle(GetPurchaseDetailPostTypeListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.PurchaseDetailPostType
                        
                        select new PurchaseDetailPostTypeView
                           {
                             Id= e.Id,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<PurchaseDetailPostTypeView>)await result.ToListAsync(cancellationToken);
        }

    }
}
