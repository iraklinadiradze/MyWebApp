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

namespace Application.Domains.Procurment.Purchase.Queries.GetPurchaseList
{

    public class GetPurchaseListQuery : IRequest<List<PurchaseView>>
    {
        //        public int? id { get; set; }
        //        public int? topRecords { get; set; }
        //        public string? name { get; set; }

        public Int32? Id { get; set; }
    }

    public class GetPurchaseListQueryHandler : IRequestHandler<GetPurchaseListQuery, List<PurchaseView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPurchaseListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PurchaseView>> Handle(GetPurchaseListQuery request, CancellationToken cancellationToken)
        {

            var result = from e in _context.Purchase
                         join _client in _context.Client on e.ClientId equals _client.Id into __client
                         from _client in __client.DefaultIfEmpty()
                         join _currency in _context.Currency on e.CurrencyId equals _currency.Id into __currency
                         from _currency in __currency.DefaultIfEmpty()
                         select new PurchaseView
                         {
                             Id = e.Id,
                             AllocStarted = e.AllocStarted,
                             Allocated = e.Allocated,
                             ClientId = e.ClientId,
                             CurrencyId = e.CurrencyId,
                             FinPostStarted = e.FinPostStarted,
                             CostPosted = e.CostPosted,
                             InvoiceNumber = e.InvoiceNumber,
                             Note = e.Note,
                             Posted = e.Posted,
                             ProcInInventory = e.ProcInInventory,
                             PurchaseName = e.PurchaseName,
                             PurchaseStatusId = e.PurchaseStatusId,
                             QtyPostStarted = e.QtyPostStarted,
                             QtyPosted = e.QtyPosted,
                             TotalAllocCost = e.TotalAllocCost,
                             TotalCostInvoiced = e.TotalCostInvoiced,
                             TotalCostInvoicedEqu = e.TotalCostInvoicedEqu,
                             TotalFinalCostEqu = e.TotalFinalCostEqu,
                             TransDate = e.TransDate,
                             xrate = e.xrate,
                             client = new PurchaseView._Client
                             {
                                 Id = _client.Id,
                                 Name = _client.Name
                             },
                             currency = new PurchaseView._Currency
                             {
                                 Id = _currency.Id,
                                 CurrencyCode = _currency.CurrencyCode
                             }
                         };


            if (request.Id != null)
                result = result.Where(r => r.Id == request.Id);

            return (List<PurchaseView>)await result.ToListAsync(cancellationToken);
        }

    }
}
