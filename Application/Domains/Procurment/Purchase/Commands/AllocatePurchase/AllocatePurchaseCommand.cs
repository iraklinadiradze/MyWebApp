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
using Application.Common.Exceptions;

namespace Application.Domains.Procurment.Purchase.Commands.AllocatePurchase
{
    public class AllocatePurchaseCommand : IRequest<long>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public bool AllocateAction { get; set; }
        public long Id { get; set; }
    }

    public class AllocatePurchaseCommandHandler : IRequestHandler<AllocatePurchaseCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public AllocatePurchaseCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<long> Handle(AllocatePurchaseCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request AllocatePurchaseCommandHandler: {@Request}", request);

            var purchase = await _context.Purchase.FindAsync(request.Id);

            _logger.Information("Purchase Retrieved: {@Purchase}", purchase);

            if (request.AllocateAction)
            {

                if (purchase.Allocated)
                    throw new InvalidActionException("Purchase Is Already Allocated", ModuleEnum.mdPurchase, purchase.Id);

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

                purchase.Allocated = true;
            }

            else
            {
                if (!purchase.Allocated)
                    throw new InvalidActionException("Purchase Is Already Unallocated", ModuleEnum.mdPurchase, purchase.Id);

                if (purchase.CostPosted)
                    throw new InvalidActionException("Purchase Cost Is Posted", ModuleEnum.mdPurchase, purchase.Id);

                if (purchase.CostPostStarted)
                    throw new InvalidActionException("Purchase Cost Is Posted", ModuleEnum.mdPurchase, purchase.Id);

                purchase.Allocated = false;

            }

            _context.Purchase.Update(purchase);

            await _context.SaveChangesAsync(cancellationToken);


            return request.Id;
        }

    }

}
