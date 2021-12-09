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

namespace Application.Domains.Sale.SalePayment.Queries.GetSalePaymentList
{

    public class GetSalePaymentListQuery : IRequest<List<SalePaymentView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetSalePaymentListQueryHandler : IRequestHandler<GetSalePaymentListQuery, List<SalePaymentView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetSalePaymentListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<SalePaymentView>> Handle(GetSalePaymentListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.SalePayment
                         join _sale in _context.Sale on e.SaleId equals _sale.Id into __sale
 from _sale in __sale.DefaultIfEmpty()
 join _salePaymentType in _context.SalePaymentType on e.PaymentTypeId equals _salePaymentType.Id into __salePaymentType
 from _salePaymentType in __salePaymentType.DefaultIfEmpty()
                        select new SalePaymentView
                           {
                             Id= e.Id,
Amount= e.Amount,
AmountIn= e.AmountIn,
AmountOut= e.AmountOut,
Note= e.Note,
PaymentTypeId= e.PaymentTypeId,
Posted= e.Posted,
SaleId= e.SaleId,
sale = new SalePaymentView._Sale{
Id= _sale.Id
},
salePaymentType = new SalePaymentView._SalePaymentType{
Id= _salePaymentType.Id
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<SalePaymentView>)await result.ToListAsync(cancellationToken);
        }

    }
}
