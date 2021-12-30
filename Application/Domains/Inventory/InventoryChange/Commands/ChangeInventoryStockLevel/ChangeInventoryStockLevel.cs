using System;
using System.Collections.Generic;
using System.Text;

using MediatR;
using Application.Model.Inventory;
using Application.Model.Product;
using Application;
using Application.Common.Interfaces;
using Application.Common;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Application.Domains.Inventory.InventoryChangeType.Common;

using Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand;
using Application.Common.Exceptions;

namespace Application.Domains.Inventory.InventoryChange.Commands.ChangeInventoryStockLevel
{
    public class ChangeInventoryStockLevelCommand : IRequest<Application.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int SenderReferenceId { get; set; }
        public Application.Model.Inventory.Inventory Inventory { get; set; }
        public int LocationId { get; set; }
        public InventoryChangeTypeEnum InventoryChangeTypeId { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime TimeSequence { get; set; }
        public bool doChangeQty { get; set; }
        public bool doChangeCost { get; set; }
        public decimal QtyIncrease { get; set; }
        public decimal QtyDecrease { get; set; }
        public decimal CostIncrease { get; set; }
        public decimal CostDecrease { get; set; }
    }

    public class ChangeInventoryStockLevelCommandHandler : IRequestHandler<ChangeInventoryStockLevelCommand, Application.Model.Inventory.InventoryChange>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public ChangeInventoryStockLevelCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        /*
         * 
         */

        public async Task<Application.Model.Inventory.InventoryChange> Handle(ChangeInventoryStockLevelCommand request, CancellationToken cancellationToken)
        {

            if (
                (request.Inventory.IsWholeQuantity == true)
                &&
                (request.QtyIncrease != Math.Floor(request.QtyIncrease))
                &&
                (request.QtyDecrease != Math.Floor(request.QtyDecrease))
                )
                throw new InvalidActionException("Inventory is not splitable type and may be changed only by whole Number", ModuleEnum.mdInventory, request.Inventory.Id);

            if (
                (request.Inventory.IsSingle == true)
                &&
                ((request.QtyIncrease != request.QtyIncrease) || (request.QtyIncrease != 0))
                &&
                ((request.QtyDecrease != 1) || (request.QtyDecrease != 0))
                )
                throw new InvalidActionException("Inventory is single type and may be changed only by 1", ModuleEnum.mdInventory, request.Inventory.Id);


            Application.Model.Inventory.InventoryChange maxInventoryChange = null;
            Application.Model.Inventory.InventoryChange _inventoryChangeNew = null;
            Application.Model.Inventory.InventoryChange _inventoryChangeOld = null;

            _inventoryChangeOld = await (from e in _context.InventoryChange
                                         where (
                                          (e.EntityId == (int)request.SenderId)
                                          &&
                                          (e.EntityForeignId == request.SenderReferenceId)
                                        )
                                         select e).FirstOrDefaultAsync();

            //            bool inventoryChangeExists = _inventoryChangeOld != null;

            bool isInventoryChangeOldDelete = (
                                                (request.CostDecrease == 0)
                                                &&
                                                (request.CostIncrease == 0)
                                                &&
                                                (request.QtyDecrease == 0)
                                                &&
                                                (request.QtyIncrease == 0)
                                              )
                                              ||
                                              (
                                                  (_inventoryChangeOld != null)
                                                  &&
                                                  (
                                                      (_inventoryChangeOld.InventoryId != request.Inventory.Id)
                                                      ||
                                                      (_inventoryChangeOld.LocationId != request.LocationId)
                                                      ||
                                                      (_inventoryChangeOld.TransDate != request.TransDate)
                                                   )
                                              );

            if (
                (_inventoryChangeOld != null)
                &&
                (_inventoryChangeOld.InventoryId == request.Inventory.Id)
                &&
                (_inventoryChangeOld.LocationId == request.LocationId)
                &&
                (_inventoryChangeOld.TransDate == request.TransDate)
                )
            {
                _inventoryChangeNew = _inventoryChangeOld;

                _inventoryChangeNew.CostBalance = _inventoryChangeNew.CostBalance
                                                + _inventoryChangeNew.CostDecrease
                                                - _inventoryChangeNew.CostIncrease
                                                + request.CostIncrease
                                                - request.CostDecrease;

                _inventoryChangeNew.QtyBalance = _inventoryChangeNew.QtyBalance
                                                + _inventoryChangeNew.QtyDecrease
                                                - _inventoryChangeNew.QtyIncrease
                                                + request.QtyIncrease
                                                - request.QtyDecrease;

                _inventoryChangeNew.CostDecrease = request.CostDecrease;
                _inventoryChangeNew.CostIncrease = request.CostIncrease;
                _inventoryChangeNew.QtyDecrease = request.QtyDecrease;
                _inventoryChangeNew.QtyIncrease = request.QtyIncrease;

                _context.InventoryChange.Update(_inventoryChangeNew);

            }
            else
            {

                maxInventoryChange = await (from e in _context.InventoryChange
                                            where (
                                             (e.InventoryId == request.Inventory.Id)
                                             &&
                                             (e.TransDate == request.TransDate)
                                             &&
                                             (e.TimeSequence < request.TimeSequence)
                                             &&
                                             (e.LocationId == request.LocationId)
                                           )
                                            orderby e.TimeSequence descending
                                            select e).FirstOrDefaultAsync();

                if (maxInventoryChange == null)
                {
                    maxInventoryChange = await (from e in _context.InventoryChange
                                                where (
                                                 (e.InventoryId == request.Inventory.Id)
                                                 &&
                                                 (e.TransDate < request.TransDate)
                                                 &&
                                                 (e.LocationId == request.LocationId)
                                               )
                                                orderby e.TransDate descending
                                                select e).FirstOrDefaultAsync();
                }

                if (maxInventoryChange == null)
                {

                    _inventoryChangeNew = new Application.Model.Inventory.InventoryChange
                    {
                        TransDate = request.TransDate,
                        InventoryId = request.Inventory.Id,
                        LocationId = request.LocationId,
                        EntityId = (int)request.SenderId,
                        EntityForeignId = request.SenderReferenceId,
                        InventoryChangeTypeId = (int)request.InventoryChangeTypeId,
                        QtyIncrease = request.QtyIncrease,
                        QtyDecrease = request.QtyDecrease,
                        CostDecrease = request.CostDecrease,
                        CostIncrease = request.CostIncrease,
                        QtyBalance = request.QtyIncrease - request.QtyDecrease,
                        CostBalance = request.CostIncrease - request.CostDecrease,
                        TimeSequence = request.TimeSequence,
                        ParentInventoryChangeId = null
                    };

                    _context.InventoryChange.Add(_inventoryChangeNew);
                }
                else
                {

                    _inventoryChangeNew = new Application.Model.Inventory.InventoryChange
                    {
                        TransDate = request.TransDate,
                        InventoryId = request.Inventory.Id,
                        LocationId = request.LocationId,
                        EntityId = (int)request.SenderId,
                        EntityForeignId = request.SenderReferenceId,
                        InventoryChangeTypeId = (int)request.InventoryChangeTypeId,
                        QtyIncrease = request.QtyIncrease,
                        QtyDecrease = request.QtyDecrease,
                        CostDecrease = request.CostDecrease,
                        CostIncrease = request.CostIncrease,
                        QtyBalance = maxInventoryChange.QtyBalance + request.QtyIncrease - request.QtyDecrease,
                        CostBalance = maxInventoryChange.CostBalance + request.CostIncrease - request.CostDecrease,
                        TimeSequence = request.TimeSequence,
                        ParentInventoryChangeId = maxInventoryChange.Id
                    };

                    _context.InventoryChange.Add(_inventoryChangeNew);
                }

                if (_inventoryChangeNew.QtyBalance < 0)
                {
                    throw new InventoryNotEnoughQtyException(request.Inventory, _inventoryChangeNew.LocationId, _inventoryChangeNew.TransDate);
                }

            }

            Application.Model.Inventory.InventoryChange _invetoryChangeToRecalculateOld = null;

            if (_inventoryChangeOld != null)
            {
                _invetoryChangeToRecalculateOld = await _context.InventoryChange.Where(p => p.ParentInventoryChangeId == _inventoryChangeOld.Id).FirstOrDefaultAsync();

                if (_invetoryChangeToRecalculateOld != null)
                {
                    if (isInventoryChangeOldDelete)
                    {
                        _invetoryChangeToRecalculateOld.ParentInventoryChangeId = _inventoryChangeOld.ParentInventoryChangeId;
                        _context.InventoryChange.Remove(_inventoryChangeOld);
                    }

                    AffectedInventoryChangeListAdd(_invetoryChangeToRecalculateOld);
                }
            }

            Application.Model.Inventory.InventoryChange _invetoryChangeToRecalculateNew = null;

            if ((_inventoryChangeOld == null) || (_inventoryChangeNew.Id != _inventoryChangeOld.Id))
            {

                if (maxInventoryChange != null)
                {
                    _invetoryChangeToRecalculateNew = await _context.InventoryChange.Where(
                                                                                         p => p.ParentInventoryChangeId == maxInventoryChange.Id
                                                                                        ).FirstOrDefaultAsync();
                }
                else
                {

                    _invetoryChangeToRecalculateNew = await (from z in _context.InventoryChange
                                                             where
                                                                  z.InventoryId == request.Inventory.Id
                                                                  &&
                                                                  z.LocationId == request.LocationId
                                                                  &&
                                                                  z.ParentInventoryChangeId == null
                                                             orderby z.TransDate ascending, z.TimeSequence ascending
                                                             select z
                    ).FirstOrDefaultAsync();

                }

                if (_invetoryChangeToRecalculateNew != null)
                    if (_invetoryChangeToRecalculateNew.Id != _invetoryChangeToRecalculateOld.Id)
                        AffectedInventoryChangeListAdd(_invetoryChangeToRecalculateNew);

            }


            if (_inventoryChangeOld != null)
                AffectedInventoryChangeListRemove(_inventoryChangeOld);

            while (_context.AffectedInventoryChangeList.Count > 0)
            {
                var invetoryChangeToRecalculate = (
                                                    from e in _context.AffectedInventoryChangeList
                                                    orderby e.TransDate ascending, e.TimeSequence ascending
                                                    select e
                                                    ).FirstOrDefault();

                if (invetoryChangeToRecalculate != null)
                {

                    if (invetoryChangeToRecalculate.EntityId == (int)ModuleEnum.mdPurchaseDetail)
                    {
                        var _purchaseDetail = await _context.PurchaseDetail.FindAsync(invetoryChangeToRecalculate.EntityForeignId);

                        await _mediator.Send(
                            new UpdatePurchaseDetailStatusCommand
                            {
                                PurchaseDetail = _purchaseDetail,
                                TransDate = invetoryChangeToRecalculate.TransDate,
                                doCostPost = _purchaseDetail.CostPosted,
                                doQtyPost = _purchaseDetail.QtyPosted
                            }
                         ); ;
                    }

                }

            }


            return _inventoryChangeNew;
        }

        private void AffectedInventoryChangeListAdd(Application.Model.Inventory.InventoryChange inventoryChange)
        {

            var findInventoryChange = _context.AffectedInventoryChangeList.Find(x => x.Id == inventoryChange.Id);

            if (findInventoryChange == null)
                _context.AffectedInventoryChangeList.Add(inventoryChange);
        }

        private void AffectedInventoryChangeListRemove(Application.Model.Inventory.InventoryChange inventoryChange)
        {

            var findInventoryChange = _context.AffectedInventoryChangeList.Find(x => x.Id == inventoryChange.Id);

            if (findInventoryChange == null)
                _context.AffectedInventoryChangeList.Remove(findInventoryChange);
        }

    }

}
