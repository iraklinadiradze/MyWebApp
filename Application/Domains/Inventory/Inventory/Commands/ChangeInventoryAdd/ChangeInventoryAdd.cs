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

// using Application.Domains.Inventory.Inventory.Commands;
using Microsoft.EntityFrameworkCore;
using Application.Domains.Inventory.InventoryChangeType.Common;

namespace Application.Domains.Inventory.Inventory.Commands.ChangeInventoryAdd
{
    public class ChangeInventoryAddCommand : IRequest<DataAccessLayer.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int SenderReferenceId { get; set; }
        public long InventoryId { get; set; }
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
        }

        public async Task<DataAccessLayer.Model.Inventory.InventoryChange> Handle(ChangeInventoryAddCommand request, CancellationToken cancellationToken)
        {
            DataAccessLayer.Model.Inventory.InventoryChange maxInventoryChange;
            DataAccessLayer.Model.Inventory.InventoryChange _inventoryChange;

            if (!request.doChangeQty)
            {
                maxInventoryChange = await (from e in _context.InventoryChange
                                            where (
                                             (e.InventoryId == request.InventoryId)
                                             &&
                                             (e.EntityId == (int)request.SenderId)
                                             &&
                                             (e.EntityForeignId == request.SenderReferenceId)
                                           )
                                            select e).FirstOrDefaultAsync();

                _inventoryChange = maxInventoryChange;

                _inventoryChange.CostDecrease = request.CostDecrease;
                _inventoryChange.CostIncrease = request.CostIncrease;
                _inventoryChange.CostBalance = maxInventoryChange.CostBalance + request.CostIncrease - request.CostDecrease;
            }
            else
            {
                maxInventoryChange = await (from e in _context.InventoryChange
                                            where (
                                             (e.InventoryId == request.InventoryId)
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
                                                 (e.InventoryId == request.InventoryId)
                                                 &&
                                                 (e.TransDate < request.TransDate)
                                                 &&
                                                 (e.LocationId == request.LocationId)
                                               )
                                                orderby e.TransDate descending
                                                select e).FirstOrDefaultAsync();
                }

                /*
                            var maxInventoryChange = (from e in _context.InventoryChange
                                                        where (
                                                         (e.InventoryId == request.InventoryId)
                                                         &&
                                                         (e.TransDate <= request.TransDate)
                                                         &&
                                                         (
                                                          (e.TransDate < request.TransDate)
                                                          ||
                                                          (e.TimeSequence < request.TimeSequence)
                                                         )
                                                         &&
                                                         (e.LocationId == request.LocationId)
                                                       )
                                                        orderby e.TransDate descending, e.TimeSequence descending
                                                      select e).FirstOrDefault();
                */


                if (maxInventoryChange != null)
                {

                    _inventoryChange = new DataAccessLayer.Model.Inventory.InventoryChange
                    {
                        TransDate = request.TransDate,
                        InventoryId = request.InventoryId,
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
                        TimeSequence = request.TimeSequence
                    };

                }
                else
                {

                    _inventoryChange = new DataAccessLayer.Model.Inventory.InventoryChange
                    {
                        TransDate = request.TransDate,
                        InventoryId = request.InventoryId,
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
                        TimeSequence = request.TimeSequence
                    };

                }

                _context.InventoryChange.Add(_inventoryChange);
            }


            var invetoryChangeListToRecalculate = (from z in _context.InventoryChange
                                                   where
                                                       z.InventoryId == request.InventoryId
                                                       &&
                                                       z.LocationId == request.LocationId
                                                       &&
                                                       z.TransDate == request.TransDate
                                                       &&
                                                       z.TimeSequence > request.TimeSequence
                                                   orderby z.TimeSequence ascending
                                                   select z
                                                   ).
                                                  Union(
                                                  from z in _context.InventoryChange
                                                  where
                                                      z.InventoryId == request.InventoryId
                                                      &&
                                                      z.LocationId == request.LocationId
                                                      &&
                                                      z.TransDate > request.TransDate
                                                  orderby z.TransDate ascending, z.TimeSequence ascending
                                                  select z
                                                  );

            /*
            var invetoryChangeListToRecalculate = from z in _context.InventoryChange
                                                  where
                                                      z.InventoryId == request.InventoryId
                                                      &&
                                                      z.LocationId == request.LocationId
                                                      &&
                                                      z.TransDate >= request.TransDate
                                                      &&
                                                      (
                                                        (z.TransDate != request.TransDate)
                                                        ||
                                                        (z.TimeSequence > request.TimeSequence)
                                                       )
                                                  orderby z.TransDate ascending, z.TimeSequence ascending
                                                  select z;
            */

            foreach (var x in invetoryChangeListToRecalculate)
            {
                if (request.doChangeQty)
                    x.QtyBalance = x.QtyBalance + request.QtyIncrease - request.QtyDecrease;

                x.CostBalance = x.CostBalance + request.CostIncrease - request.CostDecrease;

                if (x.QtyBalance < 0)
                {
                    throw new Exception($"Inventory {request.InventoryId} Goes below Zero in {x.TransDate} for location {x.LocationId}");
                }

                _context.InventoryChange.Update(x);
            }

            /*
            if (request.doChangeQty)
            {

            }

            if (request.doChangeCost)
            {

            }
            */

            return _inventoryChange;
        }
    }

}
