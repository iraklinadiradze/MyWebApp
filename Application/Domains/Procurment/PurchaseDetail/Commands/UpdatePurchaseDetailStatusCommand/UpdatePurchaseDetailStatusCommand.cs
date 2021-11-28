using System;
using System.Collections.Generic;
using System.Text;

using MediatR;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

using Application.Domains.Inventory.Inventory.Commands.ProductToInventory;
using Application.Domains.Inventory.Inventory.Commands.ChangeInventoryAdd;
using Application.Domains.Inventory.Inventory.Commands.ChangeInventoryRemove;
using Application.Domains.Inventory.InventoryChangeType.Common;


namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand
{
    public class UpdatePurchaseDetailStatusCommand : IRequest<int>
    {
        //        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;

        public DataAccessLayer.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
        public bool doQtyPost { get; set; }
        public bool doQtyUnPost { get; set; }
        public bool doCostPost { get; set; }
        public bool doCostUnPost { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime TimeSequence { get; set; }
    }

    public class UpdatePurchaseDetailStatusCommandHandler : IRequestHandler<UpdatePurchaseDetailStatusCommand, int>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseDetailStatusCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<int> Handle(UpdatePurchaseDetailStatusCommand request, CancellationToken cancellationToken)
        {

            DataAccessLayer.Model.Inventory.Inventory inventory;
            DataAccessLayer.Model.Inventory.InventoryChange _inventoryChange;

            inventory = await _mediator.Send(
                            new ProductToInventoryCommand {
                                SenderId = ModuleEnum.mdPurchaseDetail,
                                SenderReferenceId = request.PurchaseDetail.Id,
                                InventoryCode = request.PurchaseDetail.InventoryCode,
                                StartDate =  request.TransDate,
                                Product = request.PurchaseDetail.Product,
                                StockProductPerProcess = request.PurchaseDetail.StockProductPerProcess
                            }
                            );
  
            if (request.doQtyPost || request.doCostPost)
            {

                    _inventoryChange = await _mediator.Send(
                        new ChangeInventoryAddCommand
                        {
                            SenderId = ModuleEnum.mdPurchaseDetail,
                            SenderReferenceId = request.PurchaseDetail.Id,
                            Inventory = inventory,
                            LocationId = request.PurchaseDetail.LocationId,
                            TransDate = request.TransDate,
                            CostDecrease = 0,
                            CostIncrease = request.PurchaseDetail.FinalCost,
                            QtyDecrease = 0,
                            QtyIncrease = request.PurchaseDetail.FinalQty,
                            InventoryChangeTypeId = InventoryChangeTypeEnum.ictPurchase,
                            doChangeCost = request.doCostPost,
                            doChangeQty = request.doQtyPost,
                            TimeSequence = request.TimeSequence
                        }
                    );

                if (request.doQtyPost)
                    request.PurchaseDetail.QtyPosted = true;

                if (request.doCostPost)
                    request.PurchaseDetail.FinPosted = true;
            }

            if (request.doQtyUnPost || request.doCostUnPost)
            {

                    _inventoryChange = await _mediator.Send(
                        new ChangeInventoryRemoveCommand
                        {
                            SenderId = ModuleEnum.mdPurchaseDetail,
                            SenderReferenceId = request.PurchaseDetail.Id,
                            InventoryId = inventory.Id,
                            doChangeCost = request.doCostUnPost,
                            doChangeQty = request.doQtyUnPost
                        }
                    );


                if (request.doQtyUnPost)
                    request.PurchaseDetail.QtyPosted = false;

                if (request.doCostUnPost)
                    request.PurchaseDetail.FinPosted = false;

            }

            request.PurchaseDetail.Posted = request.PurchaseDetail.QtyPosted && request.PurchaseDetail.FinPosted;
  
            _context.PurchaseDetail.Update(request.PurchaseDetail);

            // Make cascasade update of related inventory changes
//            List<DataAccessLayer.Model.Inventory.Inventory> costAffectedInventoryList = new List<DataAccessLayer.Model.Inventory.Inventory>();
//            Dictionary<long, DataAccessLayer.Model.Inventory.Inventory> costAffectedInventoryList = new Dictionary<long, DataAccessLayer.Model.Inventory.Inventory>();


            await _context.SaveChangesAsync(cancellationToken);

            return 0;
        }

    }

}
