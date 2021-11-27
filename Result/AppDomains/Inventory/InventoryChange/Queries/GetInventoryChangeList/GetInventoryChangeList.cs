using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.InventoryChange.Queries.GetInventoryChangeList
{

    public class GetInventoryChangeListQuery : IRequest<List<InventoryChangeView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
    }

    public class GetInventoryChangeListQueryHandler : IRequestHandler<GetInventoryChangeListQuery, List<InventoryChangeView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryChangeListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<InventoryChangeView>> Handle(GetInventoryChangeListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.InventoryChange
                         join _inventory in _context.Inventory on e.InventoryId equals _inventory.Id into __inventory
 from _inventory in __inventory.DefaultIfEmpty()
 join _inventoryChangeType in _context.InventoryChangeType on e.InventoryChangeTypeId equals _inventoryChangeType.Id into __inventoryChangeType
 from _inventoryChangeType in __inventoryChangeType.DefaultIfEmpty()
                        select new InventoryChangeView
                           {
                             Id= e.Id,
EntityForeignId= e.EntityForeignId,
EntityId= e.EntityId,
EntityProcCode= e.EntityProcCode,
FinBalance= e.FinBalance,
FinDecrease= e.FinDecrease,
FinIncrease= e.FinIncrease,
InventoryChangeTypeId= e.InventoryChangeTypeId,
InventoryId= e.InventoryId,
QtyBalance= e.QtyBalance,
QtyDecrease= e.QtyDecrease,
QtyIncrease= e.QtyIncrease,
TransDate= e.TransDate,
inventory = new InventoryChangeView._Inventory{
Id= _inventory.Id,
InventoryCode= _inventory.InventoryCode
},
inventoryChangeType = new InventoryChangeView._InventoryChangeType{
Id= _inventoryChangeType.Id,
ChangeCode= _inventoryChangeType.ChangeCode,
ChangeName= _inventoryChangeType.ChangeName
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

            return (List<InventoryChangeView>)await result.ToListAsync(cancellationToken);
        }

    }
}
