using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Procurment;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseSummary
{
    public class UpdatePurchaseSummaryCommand : IRequest<Application.Model.Procurment.Purchase>
    {
        public bool isIncrease { get; set; }
        public Application.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
    }

    public class UpdatePurchaseSummaryCommandHandler : IRequestHandler<UpdatePurchaseSummaryCommand, Application.Model.Procurment.Purchase>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseSummaryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Application.Model.Procurment.Purchase> Handle(UpdatePurchaseSummaryCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchase.FindAsync(request.PurchaseDetail.Id);

            if (request.isIncrease)
            {
                purchase.TotalCostInvoiced = purchase.TotalCostInvoiced + request.PurchaseDetail.CostInvoiced;
                purchase.TotalCostInvoicedEqu = purchase.TotalCostInvoicedEqu + request.PurchaseDetail.CostInvoicedEqu;
                purchase.TotalFinalCostEqu = purchase.TotalFinalCostEqu + request.PurchaseDetail.FinalCost;
            }
            else
            {
                purchase.TotalCostInvoiced = purchase.TotalCostInvoiced - request.PurchaseDetail.CostInvoiced;
                purchase.TotalCostInvoicedEqu = purchase.TotalCostInvoicedEqu - request.PurchaseDetail.CostInvoicedEqu;
                purchase.TotalFinalCostEqu = purchase.TotalFinalCostEqu - request.PurchaseDetail.FinalCost;
            }

            _context.Purchase.Update(purchase);

            return purchase;
        }

    }

}
