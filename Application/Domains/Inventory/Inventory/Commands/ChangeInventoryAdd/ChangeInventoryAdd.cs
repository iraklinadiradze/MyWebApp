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


namespace Application.Domains.Inventory.Inventory.Commands.ChangeInventoryAdd
{
    public class ChangeInventoryAddCommand : IRequest<Application.Model.Inventory.InventoryChange>
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

    public class ChangeInventoryAddCommandHandler : IRequestHandler<ChangeInventoryAddCommand, Application.Model.Inventory.InventoryChange>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public ChangeInventoryAddCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        /*
                public async Task<Application.Model.Inventory.InventoryChange> Handle(ChangeInventoryAddCommand request, CancellationToken cancellationToken)
                {
                    Application.Model.Inventory.InventoryChange maxInventoryChange = null;
                    Application.Model.Inventory.InventoryChange _inventoryChange = null;

                    if (!request.doChangeQty)
                    {
                        _inventoryChange = await (from e in _context.InventoryChange
                                                  where (
                                                   (e.InventoryId == request.Inventory.Id)
                                                   &&
                                                   (e.EntityId == (int)request.SenderId)
                                                   &&
                                                   (e.EntityForeignId == request.SenderReferenceId)
                                                 )
                                                  select e).FirstOrDefaultAsync();

                        _inventoryChange.CostDecrease = request.CostDecrease;
                        _inventoryChange.CostIncrease = request.CostIncrease;
                        _inventoryChange.CostBalance = _inventoryChange.CostBalance + request.CostIncrease - request.CostDecrease;

                        //                maxInventoryChange = _inventoryChange;
                    }
                    else
                    {
                        // request.doChangeQty == True

                        if (
                            (request.Inventory.IsWholeQuantity == true)
                            &&
                            (request.QtyIncrease != Math.Floor(request.QtyIncrease))
                            &&
                            (request.QtyDecrease != Math.Floor(request.QtyDecrease))
                            )
                            throw new Exception($"Inventory {request.Inventory.Id} is not splitable type and may be changed only by whole Number");

                        if (
                            (request.Inventory.IsSingle == true)
                            &&
                            ((request.QtyIncrease != request.QtyIncrease) || (request.QtyIncrease != 0))
                            &&
                            ((request.QtyDecrease != 1) || (request.QtyDecrease != 0))
                            )
                            throw new Exception($"Inventory {request.Inventory.Id} is single type and may be changed only by 1");


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

                            _inventoryChange = new Application.Model.Inventory.InventoryChange
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

                            _context.InventoryChange.Add(_inventoryChange);
                        }
                        else
                        {

                            _inventoryChange = new Application.Model.Inventory.InventoryChange
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

                            _context.InventoryChange.Add(_inventoryChange);
                        }

                        if (_inventoryChange.QtyBalance < 0)
                        {
                            throw new Exception($"Inventory {request.Inventory.Id} Goes below Zero in {request.TransDate} for location {request.LocationId}");
                        }

                    }

                    var parentInventoryChangeId = (maxInventoryChange == null) ? _inventoryChange.Id : maxInventoryChange.Id;

                    var invetoryChangeListToRecalculate = (maxInventoryChange != null) ?
                                                          (from z in _context.InventoryChange
                                                               where
                                                                z.InventoryId==request.Inventory.Id
                                                                &&
                                                                z.LocationId==request.LocationId
                                                                &&
                                                                z.ParentInventoryChangeId == parentInventoryChangeId
                                                               orderby z.TransDate ascending, z.TimeSequence ascending
                                                               select z
                                                          ):
                                                          (from z in _context.InventoryChange
                                                           where
                                                                z.InventoryId == request.Inventory.Id
                                                                &&
                                                                z.LocationId == request.LocationId
                                                                &&
                                                                z.ParentInventoryChangeId == null
                                                           orderby z.TransDate ascending, z.TimeSequence ascending
                                                           select z
                                                          );

                        foreach (var x in invetoryChangeListToRecalculate)
                        {
                            if (request.doChangeQty)
                                x.QtyBalance = x.QtyBalance + request.QtyIncrease - request.QtyDecrease;

                            if (x.QtyBalance < 0)
                            {
                                throw new Exception($"Inventory {request.Inventory.Id} Goes below Zero in {x.TransDate} for location {x.LocationId}");
                            }

                            if (request.CostIncrease != request.CostDecrease)
                                x.CostBalance = x.CostBalance + request.CostIncrease - request.CostDecrease;

                        if (request.CostIncrease != request.CostDecrease)
                            _context.CostAffectedInventoryChangeList.Append(x);

                        _context.InventoryChange.Update(x);

                        // call affected 



                    }

                    return _inventoryChange;
                }
        */

        public async Task<Application.Model.Inventory.InventoryChange> Handle(ChangeInventoryAddCommand request, CancellationToken cancellationToken)
        {

            if (
                (request.Inventory.IsWholeQuantity == true)
                &&
                (request.QtyIncrease != Math.Floor(request.QtyIncrease))
                &&
                (request.QtyDecrease != Math.Floor(request.QtyDecrease))
                )
                throw new Exception($"Inventory {request.Inventory.Id} is not splitable type and may be changed only by whole Number");

            if (
                (request.Inventory.IsSingle == true)
                &&
                ((request.QtyIncrease != request.QtyIncrease) || (request.QtyIncrease != 0))
                &&
                ((request.QtyDecrease != 1) || (request.QtyDecrease != 0))
                )
                throw new Exception($"Inventory {request.Inventory.Id} is single type and may be changed only by 1");


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

            bool inventoryChangeExists = _inventoryChangeOld != null;

            bool isInventoryChangeDelete = !(
                                            (request.CostDecrease > 0)
                                            ||
                                            (request.CostIncrease > 0)
                                            ||
                                            (request.QtyDecrease > 0)
                                            ||
                                            (request.QtyIncrease > 0)
                                           );

            /*
                        if (inventoryChangeExists
                            &&
                           (
                            (request.CostDecrease != _inventoryChangeOld.CostDecrease)
                            ||
                            (request.QtyDecrease != _inventoryChangeOld.QtyDecrease)
                            ||
                            (request.CostIncrease != _inventoryChangeOld.CostIncrease)
                            ||
                            (request.QtyIncrease != _inventoryChangeOld.QtyIncrease)
                           )
                           )
            */
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

                //                _context.AffectedInventoryChangeList.Remove(_context.AffectedInventoryChangeList.Find)

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
                    throw new Exception($"Inventory {request.Inventory.Id} Goes below Zero in {request.TransDate} for location {request.LocationId}");
                }

            }

            Application.Model.Inventory.InventoryChange _invetoryChangeToRecalculateOld = null;

            if (_inventoryChangeOld != null)
            {
                _invetoryChangeToRecalculateOld = await _context.InventoryChange.Where(p => p.ParentInventoryChangeId == _inventoryChangeOld.Id).FirstOrDefaultAsync();

                if (_invetoryChangeToRecalculateOld != null)
                    AffectedInventoryChangeListAdd(_invetoryChangeToRecalculateOld);
                //                _context.AffectedInventoryChangeList.Add(_invetoryChangeToRecalculateOld);

            }

            Application.Model.Inventory.InventoryChange _invetoryChangeToRecalculateNew = null;

            if (_inventoryChangeNew.Id != _inventoryChangeOld.Id)
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
                //                        _context.AffectedInventoryChangeList.Add(_invetoryChangeToRecalculateNew);

            }


            var orderedAffectedInventoryChangeList = (
                                                    from e in _context.AffectedInventoryChangeList
                                                    orderby e.TransDate ascending, e.TimeSequence ascending
                                                    select e
                                                    ).ToArray();


            for (var i = 0; i < orderedAffectedInventoryChangeList.Count(); i++)
            {
                var invetoryChangeToRecalculate = orderedAffectedInventoryChangeList[i];

                if (invetoryChangeToRecalculate.EntityId == (int)ModuleEnum.mdPurchaseDetail)
                {
                    var _purchaseDetail = await _context.PurchaseDetail.FindAsync(invetoryChangeToRecalculate.EntityForeignId);

                    await _mediator.Send(
                        new UpdatePurchaseDetailStatusCommand
                        {
                            PurchaseDetail = _purchaseDetail,
                            TransDate = invetoryChangeToRecalculate.TransDate,
                            doCostPost = _purchaseDetail.FinPosted,
                            doQtyPost = _purchaseDetail.QtyPosted
                        }
                     ); ;
                }

            }


            /*
                        if (invetoryChangeToRecalculate != null)
                        {
                            if (isInventoryChangeDelete && inventoryChangeExists)
                                invetoryChangeToRecalculate.ParentInventoryChangeId = _inventoryChange.ParentInventoryChangeId;

                            var isBalanceChange = false;

                            var _newQtyBalance = _inventoryChange.QtyBalance + invetoryChangeToRecalculate.QtyIncrease - invetoryChangeToRecalculate.QtyDecrease;
                            var _newCostBalance = _inventoryChange.CostBalance + invetoryChangeToRecalculate.CostIncrease - invetoryChangeToRecalculate.CostDecrease;

                            if (_newQtyBalance != invetoryChangeToRecalculate.QtyBalance)
                            {
                                invetoryChangeToRecalculate.QtyBalance = _newQtyBalance;
                                isBalanceChange = true;
                            }

                            if (_newCostBalance != invetoryChangeToRecalculate.CostBalance)
                            {
                                invetoryChangeToRecalculate.CostBalance = _newCostBalance;
                                isBalanceChange = true;
                            }

                            _context.InventoryChange.Update(invetoryChangeToRecalculate);

                            if (isBalanceChange)
                            {
                                //                    Send InventoryChangeRepostCommand To Correspoonding Business Operation;

                                if (invetoryChangeToRecalculate.EntityId == (int)ModuleEnum.mdPurchaseDetail)
                                {
                                    await _mediator.Send(
                                        new UpdatePurchaseDetailStatusCommand
                                        {
                                            PurchaseDetail = await _context.PurchaseDetail.FindAsync(invetoryChangeToRecalculate.EntityForeignId),
                                            TransDate = invetoryChangeToRecalculate.TransDate,
                                            doCostPost = true,
                                            doQtyPost = false
                                        }
                                        ); ;
                                }

                            }

                        }
            */
            /*
                        foreach (var x in invetoryChangeListToRecalculate)
                        {
                            if (request.doChangeQty)
                                x.QtyBalance = x.QtyBalance + request.QtyIncrease - request.QtyDecrease;

                            if (x.QtyBalance < 0)
                            {
                                throw new Exception($"Inventory {request.Inventory.Id} Goes below Zero in {x.TransDate} for location {x.LocationId}");
                            }

                            if (request.CostIncrease != request.CostDecrease)
                                x.CostBalance = x.CostBalance + request.CostIncrease - request.CostDecrease;

                            if (request.CostIncrease != request.CostDecrease)
                                _context.CostAffectedInventoryChangeList.Append(x);

                            _context.InventoryChange.Update(x);

                            // call affected 


                        }
            */

            return null;
        }

        private void AffectedInventoryChangeListAdd(Application.Model.Inventory.InventoryChange inventoryChange)
        {

            var findInventoryChange = _context.AffectedInventoryChangeList.Find(x => x.Id == inventoryChange.Id);

            if (findInventoryChange == null)
                _context.AffectedInventoryChangeList.Add(inventoryChange);
        }

    }

}
