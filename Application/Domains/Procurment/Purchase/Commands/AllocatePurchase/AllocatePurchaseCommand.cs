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


                var relatedPurchases = from e in _context.PurchaseAllocationSource
                                       join f in _context.PurchaseDetail
                                       on e.AllocPurchaseDetailId equals f.Id
                                       where
                                           (e.PurchaseId == request.Id)
                                       select new
                                       {
                                           PurchaseAllocationSourceId = e.Id,
                                           PurchaseDetailToAllocate = f,
                                           PurchaseAllocationSourceTypeId = e.PurchaseAllocationSourceTypeId
                                       };


                foreach (var relatedPurchase in relatedPurchases)
                {

                    _logger.Information("Purchase Detail to be Allocated Retrieved: {@PurchaseDetails}", relatedPurchase);

                    if (relatedPurchase.PurchaseAllocationSourceTypeId == (int)PurchaseDetailSourceTypeEnum.pdstAllocPurchCost)
                        _ = await _mediator.Send(new AllocateWeightedCostAverageCommand
                        {
                            SenderId = ModuleEnum.mdPurchase,
                            Purchase = purchase,
                            PurchaseAllocationSourceId = relatedPurchase.PurchaseAllocationSourceId,
                            PurchaseDetail = relatedPurchase.PurchaseDetailToAllocate
                        });

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


                var purchaseAllocationResult = from e in _context.PurchaseAllocationSource
                                               join f in _context.PurchaseAllocationResult
                                               on e.AllocPurchaseDetailId equals f.Id
                                               where
                                               (e.PurchaseId == request.Id)
                                               &&
                                               (e.Id == f.PurchaseAllocationSourceId)
                                               select f;

                foreach (var _purchaseAllocationResult in purchaseAllocationResult)
                {
                    _context.PurchaseAllocationResult.Remove(_purchaseAllocationResult);

                    _logger.Information("Purchase Allocation Result Removed: {@PurchaseAllocationResult}", _purchaseAllocationResult);
                }


                purchase.Allocated = false;
            }

            _context.Purchase.Update(purchase);
            _logger.Information("Purchase Updated: {@Purchase}", purchase);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Purchase Allocation Finished {Id}", purchase.Id);

            return request.Id;
        }
    }

}
