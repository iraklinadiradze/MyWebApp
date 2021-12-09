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

using Application.Domains.Inventory.Inventory.Commands.CreateInventory;
using Microsoft.EntityFrameworkCore;

namespace Application.Domains.Inventory.Inventory.Commands.ProductToInventory
{
    public class ProductToInventoryCommand : IRequest<Application.Model.Inventory.Inventory>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int SenderReferenceId { get; set; }
        public Application.Model.Product.Product Product { get; set; }
        public bool StockProductPerProcess { get; set; }
        public DateTime StartDate { get; set; }
        public string InventoryCode { get; set; }
    }

    public class ProductToInventoryCommandHandler : IRequestHandler<ProductToInventoryCommand, Application.Model.Inventory.Inventory>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public ProductToInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Application.Model.Inventory.Inventory> Handle(ProductToInventoryCommand request, CancellationToken cancellationToken)
        {

            Application.Model.Inventory.Inventory _inventory;

            if (request.Product.IsSingle == true)
            {

                _inventory = (from x in _context.Inventory
                              where x.InventoryCode == request.InventoryCode
                              select x).First();

                if (
                    (_inventory != null)
                    &&
                    (
                    (_inventory.EntityId != ((int)request.SenderId))
                    ||
                    (_inventory.EntityForeignId != request.SenderReferenceId)
                    )
                   )
                {
                    throw new Exception($"Inventory with Code {request.Product.ProductCode} already exists");
                }

                // inventory.IsWholeQuantity = true;
            }
            else
            {

                _inventory = (from x in _context.Inventory
                              where
                              (x.ProductId == request.Product.Id)
                              &&
                              (
                               ( (!request.StockProductPerProcess) && (x.ProcInInventory == false) )
                                ||
                               (
                                 (x.EntityId == (int)request.SenderId)
                                  &&
                                  (x.EntityForeignId == (int)request.SenderReferenceId)
                                  &&
                                  (request.StockProductPerProcess)
                                )
                              )
                              select x
                              ).First();
            }

            var inventory = new Application.Model.Inventory.Inventory();

            if (_inventory != null)
            {

                inventory.IsSingle = request.Product.IsSingle;
                inventory.IsWholeQuantity = request.Product.IsWholeQuantity;
                inventory.ProductUnitId = request.Product.ProductUnitId;
                inventory.InventoryCode = request.InventoryCode;
                inventory.EntityId = (int)request.SenderId;
                inventory.EntityForeignId = request.SenderReferenceId;
                inventory.ProductId = request.Product.Id;
                inventory.StartDate = request.StartDate;

                inventory = await _mediator.Send(
                    new CreateInventoryCommand { SenderId = ModuleEnum.mdUndefined, Inventory = inventory }
                    );

            }
            else
            {
                inventory = _inventory;
            }

//            if (
//                _context.ChangeTracker.Entries()
//                      .Any(e => e.State == EntityState.Added
//                             || e.State == EntityState.Deleted
//                             || e.State == EntityState.Modified)
//          ) ;

//            _context.SaveChangesAsync(cancellationToken);

            return inventory;
        }
    }

}
