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

namespace Application.Domains.Sale.Sale.Queries.GetSaleList
{

    public class GetSaleListQuery : IRequest<List<SaleView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetSaleListQueryHandler : IRequestHandler<GetSaleListQuery, List<SaleView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSaleListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<SaleView>> Handle(GetSaleListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Sale
                        
                        select new SaleView
                           {
                             Id= e.Id,
ConsultantId= e.ConsultantId,
FinPostStarted= e.FinPostStarted,
FinPosted= e.FinPosted,
Note= e.Note,
OwnerId= e.OwnerId,
PaymentPosted= e.PaymentPosted,
Posted= e.Posted,
QtyPostStarted= e.QtyPostStarted,
QtyPosted= e.QtyPosted,
ShopId= e.ShopId,
TransDate= e.TransDate
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<SaleView>)await result.ToListAsync(cancellationToken);
        }

    }
}
