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
using System.Linq;

namespace Application.Domains.Procurment.Purchase.Commands.AllocatePurchase
{
    public class AllocatePurchaseCommand : IRequest<long>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public long Id { get; set; }
    }

    public class AllocatePurchaseCommandHandler : IRequestHandler<AllocatePurchaseCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public AllocatePurchaseCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<long> Handle(AllocatePurchaseCommand request, CancellationToken cancellationToken)
        {

            var purchase = await _context.Purchase.FindAsync(request.Id);


            decimal costToAllocateFromOtherPurchase = 0;
            decimal costToAllocateFromFinAcc = 0;
            decimal costToAllocate = 0;

            decimal costAllocated = 0;

            costToAllocateFromOtherPurchase = (from e in _context.PurchaseAllocationSource
                                               join f in _context.PurchaseDetail
                                               on e.AllocPurchaseDetailId equals f.Id
                                               where
                                                   (e.PurchaseId == request.Id)
                                                   &&
                                                   (e.PurchaseAllocationSourceTypeId == (int)PurchaseDetailSourceTypeEnum.pdstAllocPurchCost)
                                               select f.FinalCost
                    ).Sum();

            costToAllocate = costToAllocateFromOtherPurchase + costToAllocateFromFinAcc;

            Application.Model.Procurment.PurchaseDetail maxPurchaseDetail = null;

            foreach (
                var purchaseDetail in _context.PurchaseDetail.Where(
                    q => (q.PurchaseId == purchase.Id)
                )
            )
            {
                decimal addAmount = 0;

                addAmount = Decimal.Floor(purchaseDetail.CostCalculatedEqu / purchase.TotalCostInvoicedEqu * costToAllocate * 100) / 100;
                purchaseDetail.AddCost = addAmount;
                purchaseDetail.FinalCost = purchaseDetail.CostCalculatedEqu + addAmount;

                costAllocated = costAllocated + addAmount;

                if (maxPurchaseDetail == null)
                { maxPurchaseDetail = purchaseDetail; }
                else
                {
                    if (purchaseDetail.CostCalculatedEqu > maxPurchaseDetail.CostCalculatedEqu)
                        maxPurchaseDetail = purchaseDetail;
                }

                _context.PurchaseDetail.Update(purchaseDetail);
            }

            if (costAllocated != costToAllocate)
                if (maxPurchaseDetail != null)
                {
                    maxPurchaseDetail.AddCost = maxPurchaseDetail.AddCost + costToAllocate - costAllocated;
                    maxPurchaseDetail.FinalCost = maxPurchaseDetail.CostCalculatedEqu + maxPurchaseDetail.AddCost;
                    _context.PurchaseDetail.Update(maxPurchaseDetail);
                }


            await _context.SaveChangesAsync(cancellationToken);


            return request.Id;
        }

    }

}
