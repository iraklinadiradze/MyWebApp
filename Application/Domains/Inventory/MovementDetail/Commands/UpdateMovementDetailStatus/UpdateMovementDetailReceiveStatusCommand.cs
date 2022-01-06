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

namespace Application.Domains.Inventory.MovementDetail.Commands.UpdateMovementDetailStatusCommand
{
    public class UpdateMovementDetailReceiveStatusCommand : IRequest<Application.Model.Inventory.MovementDetail>
    {
        //        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Inventory.Movement Movement { get; set; }
        public Application.Model.Inventory.MovementDetail MovementDetail { get; set; }
        public bool doQtyPost { get; set; }
        //        public bool doQtyUnPost { get; set; }
        public bool doCostPost { get; set; }
        //       public bool doCostUnPost { get; set; }
        public DateTime TimeSequence { get; set; }
    }

    public class UpdateMovementDetailReceiveStatusCommandHandler : IRequestHandler<UpdateMovementDetailReceiveStatusCommand, Application.Model.Inventory.MovementDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public UpdateMovementDetailReceiveStatusCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<Application.Model.Inventory.MovementDetail> Handle(UpdateMovementDetailReceiveStatusCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request: {@Request}", request);

            if (request.doCostPost)
            {
                if ((!request.MovementDetail.ReceiveQtyPosted) && (!request.doQtyPost))
                    throw new InvalidActionException("Purchase Detail Qty Should Be Posted", ModuleEnum.mdMovementDetail, request.MovementDetail.Id);
            }

            if (!request.doQtyPost)
            {
                if ((request.MovementDetail.ReceiveCostPosted) && (request.doCostPost))
                    throw new InvalidActionException("Purchase Detail Cost Should Be Unposted", ModuleEnum.mdMovementDetail, request.MovementDetail.Id);
            }


            Application.Model.Inventory.Inventory inventory = request.MovementDetail.Inventory;

            Application.Model.Inventory.InventoryChange _inventoryChange;

                _inventoryChange = await _mediator.Send(
                    new ChangeInventoryStockLevelCommand
                    {
                        SenderId = ModuleEnum.mdMovementDetail,
                        SenderReferenceId = request.MovementDetail.Id,
                        Inventory = inventory,
                        LocationId = request.Movement.ReceiveLocationId,
                        TransDate = (DateTime)request.Movement.ReceiveDate,
                        CostDecrease = 0,
                        CostIncrease = request.MovementDetail.ReceiveValue,
                        QtyDecrease = 0,
                        QtyIncrease = request.MovementDetail.ReceiveQty,
                        InventoryChangeTypeId = InventoryChangeTypeEnum.ictMovement,
                        TimeSequence = request.TimeSequence
                    }
                );


            request.MovementDetail.ReceiveQtyPosted = request.doQtyPost;

            request.MovementDetail.ReceiveCostPosted = request.doCostPost;


            request.MovementDetail.ReceivePosted = request.MovementDetail.ReceiveQtyPosted && request.MovementDetail.ReceiveCostPosted;

            _logger.Information("Request Result: {@Request}", request);

            _context.MovementDetail.Update(request.MovementDetail);

            await _context.SaveChangesAsync(cancellationToken);

            var result = await _context.MovementDetail.FindAsync(request.MovementDetail.Id);

            _logger.Information("Result: {@Result}", result);

            return result;
        }

    }

}
