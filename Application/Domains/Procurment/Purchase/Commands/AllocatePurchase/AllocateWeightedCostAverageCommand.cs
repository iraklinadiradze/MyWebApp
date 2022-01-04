using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Domains.Procurment.Purchase.Commands.AllocatePurchase
{
    public class AllocateWeightedCostAverageCommand : IRequest<long>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
        public long PurchaseAllocationSourceId { get; set; }
        public Application.Model.Procurment.Purchase Purchase { get; set; }
    }

    public class AllocateWeightedCostAverageCommandHandler : IRequestHandler<AllocateWeightedCostAverageCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public AllocateWeightedCostAverageCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<long> Handle(AllocateWeightedCostAverageCommand request, CancellationToken cancellationToken)
        {
            _logger.Information("Request AllocateWeightedCostAverageCommand: {@Request}", request);

            decimal costToAllocate = request.PurchaseDetail.FinalCost;

            _logger.Information("Cost To Allocate: {@costToAllocate}", costToAllocate);

            decimal costAllocated = 0;

            Application.Model.Procurment.PurchaseDetail maxPurchaseDetail = null;

            foreach (
            var purchaseDetail in _context.PurchaseDetail.Where(
                q => (q.PurchaseId == request.Purchase.Id)
                   )
               )
            {
                decimal addAmount = 0;

                addAmount = Decimal.Floor(purchaseDetail.CostCalculatedEqu / request.Purchase.TotalCostInvoicedEqu * costToAllocate * 100) / 100;
                purchaseDetail.AddCost = purchaseDetail.AddCost + addAmount;
                purchaseDetail.FinalCost = purchaseDetail.CostCalculatedEqu + purchaseDetail.AddCost;

                costAllocated = costAllocated + addAmount;

                var purchaseAllocationResult = new Application.Model.Procurment.PurchaseAllocationResult
                {
                    PurchaseAllocationSourceId = request.PurchaseAllocationSourceId,
                    PurchaseDetailId = purchaseDetail.Id,
                    Amount = addAmount
                };

                await _context.PurchaseAllocationResult.AddAsync(purchaseAllocationResult);

                _logger.Information("Purchase Allocation Result Added: {@purchaseAllocationResult}", purchaseAllocationResult);

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
                    var _residual = costToAllocate - costAllocated;

                    maxPurchaseDetail.AddCost = maxPurchaseDetail.AddCost + costToAllocate - costAllocated;
                    maxPurchaseDetail.FinalCost = maxPurchaseDetail.CostCalculatedEqu + maxPurchaseDetail.AddCost;
                    _context.PurchaseDetail.Update(maxPurchaseDetail);

                    _logger.Information("Added Rounding difference {@residual} value to {@maxPurchaseDetail}", _residual, maxPurchaseDetail);
                }

            return request.Purchase.Id;

        }

    }

}