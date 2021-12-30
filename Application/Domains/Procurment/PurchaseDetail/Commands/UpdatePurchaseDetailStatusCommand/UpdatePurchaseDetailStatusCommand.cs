using System;
using MediatR;
using Application.Common.Interfaces;
using Application.Common;
using System.Threading.Tasks;
using System.Threading;

using Application.Domains.Inventory.Inventory.Commands.ProductToInventory;
using Application.Domains.Inventory.InventoryChange.Commands.ChangeInventoryStockLevel;
using Application.Domains.Inventory.Inventory.Commands.ChangeInventoryRemove;
using Application.Domains.Inventory.InventoryChangeType.Common;
using Application.Common.Exceptions;

namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand
{
    public class UpdatePurchaseDetailStatusCommand : IRequest<Application.Model.Procurment.PurchaseDetail>
    {
        //        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
        public bool doQtyPost { get; set; }
//        public bool doQtyUnPost { get; set; }
        public bool doCostPost { get; set; }
 //       public bool doCostUnPost { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime TimeSequence { get; set; }
    }

    public class UpdatePurchaseDetailStatusCommandHandler : IRequestHandler<UpdatePurchaseDetailStatusCommand, Application.Model.Procurment.PurchaseDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public UpdatePurchaseDetailStatusCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<Application.Model.Procurment.PurchaseDetail> Handle(UpdatePurchaseDetailStatusCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request: {@Request}", request);

            if (request.doCostPost)
            {
                if ( (!request.PurchaseDetail.QtyPosted) && (!request.doQtyPost))
                    throw new InvalidActionException("Purchase Detail Qty Should Be Posted", ModuleEnum.mdPurchaseDetail, request.PurchaseDetail.Id);
            }

            if (!request.doQtyPost)
            {
                if ((request.PurchaseDetail.CostPosted) && (request.doCostPost))
                    throw new InvalidActionException("Purchase Detail Cost Should Be Unposted", ModuleEnum.mdPurchaseDetail, request.PurchaseDetail.Id);
            }


            Application.Model.Inventory.Inventory inventory;

            inventory = await _mediator.Send(
                            new ProductToInventoryCommand {
                                SenderId = ModuleEnum.mdPurchaseDetail,
                                SenderReferenceId = request.PurchaseDetail.Id,
                                InventoryCode = request.PurchaseDetail.InventoryCode,
                                StartDate =  request.TransDate,
                                Product = await _context.Product.FindAsync(request.PurchaseDetail.ProductId),
                                StockProductPerProcess = request.PurchaseDetail.StockProductPerProcess
                            }
                            );

            Application.Model.Inventory.InventoryChange _inventoryChange;

            if (request.doQtyPost || request.doCostPost)
            {
                    _inventoryChange = await _mediator.Send(
                        new ChangeInventoryStockLevelCommand
                        {
                            SenderId = ModuleEnum.mdPurchaseDetail,
                            SenderReferenceId = request.PurchaseDetail.Id,
                            Inventory = inventory,
                            LocationId = request.PurchaseDetail.LocationId,
                            TransDate = request.TransDate,
                            CostDecrease = 0,
                            CostIncrease = request.doCostPost?request.PurchaseDetail.FinalCost:0,
                            QtyDecrease = 0,
                            QtyIncrease = request.doQtyPost ? request.PurchaseDetail.FinalQty:0,
                            InventoryChangeTypeId = InventoryChangeTypeEnum.ictPurchase,
                            doChangeCost = request.doCostPost,
                            doChangeQty = request.doQtyPost,
                            TimeSequence = request.TimeSequence
                        }
                    );

                if (request.doQtyPost)
                    request.PurchaseDetail.QtyPosted = true;

                if (request.doCostPost)
                    request.PurchaseDetail.CostPosted = true;
            }


            request.PurchaseDetail.Posted = request.PurchaseDetail.QtyPosted && request.PurchaseDetail.CostPosted;

            _logger.Information("Request Result: {@Request}", request);

            _context.PurchaseDetail.Update(request.PurchaseDetail);

            await _context.SaveChangesAsync(cancellationToken);

            var result = await _context.PurchaseDetail.FindAsync(request.PurchaseDetail.Id);

            _logger.Information("Result: {@Result}", result);

            return result;
        }

    }

}
