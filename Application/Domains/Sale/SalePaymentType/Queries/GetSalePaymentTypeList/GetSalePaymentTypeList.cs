using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Sale;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Sale.SalePaymentType.Queries.GetSalePaymentTypeList
{

    public class GetSalePaymentTypeListQuery : IRequest<List<SalePaymentTypeView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetSalePaymentTypeListQueryHandler : IRequestHandler<GetSalePaymentTypeListQuery, List<SalePaymentTypeView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSalePaymentTypeListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<SalePaymentTypeView>> Handle(GetSalePaymentTypeListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.SalePaymentType
                        
                        select new SalePaymentTypeView
                           {
                             Id= e.Id,
Name= e.Name
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<SalePaymentTypeView>)await result.ToListAsync(cancellationToken);
        }

    }
}
