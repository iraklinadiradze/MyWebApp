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
    public class UpdateMovementDetailSendStatusCommand : IRequest<Application.Model.Inventory.MovementDetail>
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

    public class UpdateMovementDetailStatusCommandHandler : IRequestHandler<UpdateMovementDetailSendStatusCommand, Application.Model.Inventory.MovementDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public UpdateMovementDetailStatusCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<Application.Model.Inventory.MovementDetail> Handle(UpdateMovementDetailSendStatusCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request: {@Request}", request);

            if (request.doCostPost)
            {
                if ((!request.MovementDetail.SendQtyPosted) && (!request.doQtyPost))
                    throw new InvalidActionException("Purchase Detail Qty Should Be Posted", ModuleEnum.mdMovementDetail, request.MovementDetail.Id);
            }

            if (!request.doQtyPost)
            {
                if ((request.MovementDetail.SendCostPosted) && (request.doCostPost))
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
                        LocationId = request.Movement.SendLocationId,
                        TransDate = (DateTime)request.Movement.SendDate,
                        CostDecrease = request.MovementDetail.SendCost,
                        CostIncrease = 0,
                        QtyDecrease = request.MovementDetail.SendQty,
                        QtyIncrease = 0,
                        InventoryChangeTypeId = InventoryChangeTypeEnum.ictMovement,
                        TimeSequence = request.TimeSequence
                    }
                );


            request.MovementDetail.SendQtyPosted = request.doQtyPost;

            request.MovementDetail.SendCostPosted = request.doCostPost;


            request.MovementDetail.SendPosted = request.MovementDetail.SendQtyPosted && request.MovementDetail.SendCostPosted;

            _logger.Information("Request Result: {@Request}", request);

            _context.MovementDetail.Update(request.MovementDetail);

            await _context.SaveChangesAsync(cancellationToken);

            var result = await _context.MovementDetail.FindAsync(request.MovementDetail.Id);

            _logger.Information("Result: {@Result}", result);

            return result;
        }

    }

}
