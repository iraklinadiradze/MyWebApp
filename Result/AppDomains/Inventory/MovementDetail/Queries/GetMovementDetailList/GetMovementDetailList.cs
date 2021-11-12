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

namespace Application.Domains.Inventory.MovementDetail.Queries.GetMovementDetailList
{

    public class GetMovementDetailListQuery : IRequest<List<MovementDetailView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
public Int32? inventoryId {get;set;}
public Int32? movementId {get;set;}
    }

    public class GetMovementDetailListQueryHandler : IRequestHandler<GetMovementDetailListQuery, List<MovementDetailView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetMovementDetailListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<MovementDetailView>> Handle(GetMovementDetailListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.MovementDetail
                         join _inventory in _context.Inventory on e.InventoryId equals _inventory.Id into __inventory
 from _inventory in __inventory.DefaultIfEmpty()
 join _movement in _context.Movement on e.MovementId equals _movement.Id into __movement
 from _movement in __movement.DefaultIfEmpty()
                        select new MovementDetailView
                           {
                             Id= e.Id,
InventoryId= e.InventoryId,
MovementId= e.MovementId,
ReceiveFinPosted= e.ReceiveFinPosted,
ReceivePosted= e.ReceivePosted,
ReceiveQty= e.ReceiveQty,
ReceiveQtyPosted= e.ReceiveQtyPosted,
ReceiveValue= e.ReceiveValue,
SendFinPosted= e.SendFinPosted,
SendPosted= e.SendPosted,
SendQty= e.SendQty,
SendQtyPosted= e.SendQtyPosted,
SendValue= e.SendValue,
inventory = new MovementDetailView._Inventory{
Id= _inventory.Id,
InventoryCode= _inventory.InventoryCode
},
movement = new MovementDetailView._Movement{
Id= _movement.Id
}
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.inventoryId!= null) 
 result = result.Where(r => r.InventoryId== request.inventoryId);

                if (request.movementId!= null) 
 result = result.Where(r => r.MovementId== request.movementId);

            return (List<MovementDetailView>)await result.ToListAsync(cancellationToken);
        }

    }
}
