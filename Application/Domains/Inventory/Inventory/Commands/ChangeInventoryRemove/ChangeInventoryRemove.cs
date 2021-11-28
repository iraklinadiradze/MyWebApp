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

namespace Application.Domains.Inventory.Inventory.Commands.ChangeInventoryRemove
{
    public class ChangeInventoryRemoveCommand : IRequest<DataAccessLayer.Model.Inventory.InventoryChange>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int SenderReferenceId { get; set; }
        public long InventoryId { get; set; }
        public bool doChangeQty { get; set; }
        public bool doChangeCost { get; set; }
    }

    public class ChangeInventoryRemoveCommandHandler : IRequestHandler<ChangeInventoryRemoveCommand, DataAccessLayer.Model.Inventory.InventoryChange>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public ChangeInventoryRemoveCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<DataAccessLayer.Model.Inventory.InventoryChange> Handle(ChangeInventoryRemoveCommand request, CancellationToken cancellationToken)
        {
            //            DataAccessLayer.Model.Inventory.InventoryChange maxInventoryChange;
            DataAccessLayer.Model.Inventory.InventoryChange _inventoryChange;

            _inventoryChange = await (from e in _context.InventoryChange
                                      where (
                                       (e.InventoryId == request.InventoryId)
                                       &&
                                       (e.EntityId == (int)request.SenderId)
                                       &&
                                       (e.EntityForeignId == request.SenderReferenceId)
                                     )
                                      select e).FirstOrDefaultAsync();

            var invetoryChangeListToRecalculate = (from z in _context.InventoryChange
                                                   where
                                                       z.InventoryId == _inventoryChange.InventoryId
                                                       &&
                                                       z.LocationId == _inventoryChange.LocationId
                                                       &&
                                                       z.TransDate == _inventoryChange.TransDate
                                                       &&
                                                       z.TimeSequence > _inventoryChange.TimeSequence
                                                   orderby z.TimeSequence ascending
                                                   select z
                                                   ).
                                                  Union(
                                                  from z in _context.InventoryChange
                                                  where
                                                      z.InventoryId == _inventoryChange.InventoryId
                                                      &&
                                                      z.LocationId == _inventoryChange.LocationId
                                                      &&
                                                      z.TransDate > _inventoryChange.TransDate
                                                  orderby z.TransDate ascending, z.TimeSequence ascending
                                                  select z
                                                  );

            foreach (var x in invetoryChangeListToRecalculate)
            {
                if (request.doChangeQty)
                    x.QtyBalance = x.QtyBalance - _inventoryChange.QtyIncrease - _inventoryChange.QtyDecrease;

                if (request.doChangeCost)
                    x.CostBalance = x.CostBalance - _inventoryChange.CostIncrease + _inventoryChange.CostDecrease;

                if (x.QtyBalance < 0)
                {
                    throw new Exception($"Inventory {request.InventoryId} Goes below Zero in {x.TransDate} for location {x.LocationId}");
                }

                _context.InventoryChange.Update(x);
            }


            if (!request.doChangeQty)
            {
                _inventoryChange.QtyDecrease = 0;
                _inventoryChange.QtyIncrease = 0;
                _inventoryChange.QtyBalance = 0;
            }

            if (!request.doChangeCost)
            {
                _inventoryChange.CostDecrease = 0;
                _inventoryChange.CostIncrease = 0;
                _inventoryChange.CostBalance = 0;
            }

            if (
                (_inventoryChange.CostIncrease > 0)
                ||
                (_inventoryChange.CostDecrease > 0)
                ||
                (_inventoryChange.QtyIncrease > 0)
                ||
                (_inventoryChange.QtyDecrease > 0)
                )
                _context.InventoryChange.Update(_inventoryChange);
            else
                _context.InventoryChange.Remove(_inventoryChange);

                return _inventoryChange;
        }

}

}
