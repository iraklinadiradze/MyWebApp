using System;
using System.Collections.Generic;
using System.Text;

using MediatR;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
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
    public class ChangeInventoryAddCommand : IRequest<DataAccessLayer.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int SenderReferenceId { get; set; }
        public DataAccessLayer.Model.Inventory.Inventory Inventory { get; set; }
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

    public class ChangeInventoryAddCommandHandler : IRequestHandler<ChangeInventoryAddCommand, DataAccessLayer.Model.Inventory.InventoryChange>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public ChangeInventoryAddCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;

            CoreDBContext xxx;

        }

        /*
                public async Task<DataAccessLayer.Model.Inventory.InventoryChange> Handle(ChangeInventoryAddCommand request, CancellationToken cancellationToken)
                {
                    DataAccessLayer.Model.Inventory.InventoryChange maxInventoryChange = null;
                    DataAccessLayer.Model.Inventory.InventoryChange _inventoryChange = null;

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

                            _inventoryChange = new DataAccessLayer.Model.Inventory.InventoryChange
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

                            _inventoryChange = new DataAccessLayer.Model.Inventory.InventoryChange
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

        public async Task<DataAccessLayer.Model.Inventory.InventoryChange> Handle(ChangeInventoryAddCommand request, CancellationToken cancellationToken)
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


            DataAccessLayer.Model.Inventory.InventoryChange maxInventoryChange = null;
            DataAccessLayer.Model.Inventory.InventoryChange _inventoryChange = null;

            _inventoryChange = await (from e in _context.InventoryChange
                                      where (
                                       (e.InventoryId == request.Inventory.Id)
                                       &&
                                       (e.EntityId == (int)request.SenderId)
                                       &&
                                       (e.EntityForeignId == request.SenderReferenceId)
                                     )
                                      select e).FirstOrDefaultAsync();

            bool inventoryChangeExists = _inventoryChange != null;

            bool isInventoryChangeDelete = (request.CostDecrease > 0)
                                            ||
                                            (request.CostIncrease > 0)
                                            ||
                                            (request.QtyDecrease > 0)
                                            ||
                                            (request.QtyIncrease > 0);

            if (inventoryChangeExists
                &&
               (
                (request.CostDecrease != _inventoryChange.CostDecrease)
                ||
                (request.QtyDecrease != _inventoryChange.QtyDecrease)
                ||
                (request.CostIncrease != _inventoryChange.CostIncrease)
                ||
                (request.QtyIncrease != _inventoryChange.QtyIncrease)
               )
               )
            {

                /*
                if (_inventoryChange.ParentInventoryChangeId != null)
                    maxInventoryChange = (from z in _context.InventoryChange
                                          where z.Id == _inventoryChange.ParentInventoryChangeId).FirstOrDefaultAsync();

                if (maxInventoryChange!=null)
                {

                }
                */

                _inventoryChange.CostBalance = _inventoryChange.CostBalance
                                                + _inventoryChange.CostDecrease
                                                - _inventoryChange.CostIncrease
                                                + request.CostIncrease
                                                - request.CostDecrease;

                _inventoryChange.QtyBalance = _inventoryChange.QtyBalance
                                                + _inventoryChange.QtyDecrease
                                                - _inventoryChange.QtyIncrease
                                                + request.QtyIncrease
                                                - request.QtyDecrease;

                _inventoryChange.CostDecrease = request.CostDecrease;
                _inventoryChange.CostIncrease = request.CostIncrease;
                _inventoryChange.QtyDecrease = request.QtyDecrease;
                _inventoryChange.QtyIncrease = request.QtyIncrease;

                _context.InventoryChange.Update(_inventoryChange);
            }
            //            else

            if (!inventoryChangeExists)
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

                    _inventoryChange = new DataAccessLayer.Model.Inventory.InventoryChange
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

                    _inventoryChange = new DataAccessLayer.Model.Inventory.InventoryChange
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

            var invetoryChangeToRecalculate = (maxInventoryChange != null) ?
                                                 await (from z in _context.InventoryChange
                                                        where
                                                         z.InventoryId == request.Inventory.Id
                                                         &&
                                                         z.LocationId == request.LocationId
                                                         &&
                                                         z.ParentInventoryChangeId == parentInventoryChangeId
                                                        orderby z.TransDate ascending, z.TimeSequence ascending
                                                        select z
                                                  ).FirstOrDefaultAsync() :
                                                  await (from z in _context.InventoryChange
                                                         where
                                                              z.InventoryId == request.Inventory.Id
                                                              &&
                                                              z.LocationId == request.LocationId
                                                              &&
                                                              z.ParentInventoryChangeId == null
                                                         orderby z.TransDate ascending, z.TimeSequence ascending
                                                         select z
                                                  ).FirstOrDefaultAsync();

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

                    if (invetoryChangeToRecalculate.EntityId==(int)ModuleEnum.mdPurchaseDetail)
                    {
                        await _mediator.Send(
                            new UpdatePurchaseDetailStatusCommand
                            {
                                TransDate = invetoryChangeToRecalculate.TransDate,
                                doCostPost = true
                            }
                            );
                    }

                }

            }

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



    }

}
