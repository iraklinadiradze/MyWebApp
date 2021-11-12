using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Procurment;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Procurment.PurchaseAllocationSourceType.Queries.GetPurchaseAllocationSourceTypeList
{

    public class GetPurchaseAllocationSourceTypeListQuery : IRequest<List<PurchaseAllocationSourceTypeView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
    }

    public class GetPurchaseAllocationSourceTypeListQueryHandler : IRequestHandler<GetPurchaseAllocationSourceTypeListQuery, List<PurchaseAllocationSourceTypeView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseAllocationSourceTypeListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PurchaseAllocationSourceTypeView>> Handle(GetPurchaseAllocationSourceTypeListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.PurchaseAllocationSourceType
                        
                        select new PurchaseAllocationSourceTypeView
                           {
                             Id= e.Id,
Name= e.Name
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

            return (List<PurchaseAllocationSourceTypeView>)await result.ToListAsync(cancellationToken);
        }

    }
}
