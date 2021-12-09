using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Inventory;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.Inventory.Queries.GetInventoryList
{

    public class GetInventoryListQuery : IRequest<List<InventoryView>>
    {
        //        public int? id { get; set; }
        //        public int? topRecords { get; set; }
        //        public string? name { get; set; }

        public Int32? Id { get; set; }
        public String InventoryCode { get; set; }
    }

    public class GetInventoryListQueryHandler : IRequestHandler<GetInventoryListQuery, List<InventoryView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<InventoryView>> Handle(GetInventoryListQuery request, CancellationToken cancellationToken)
        {

            var result = from e in _context.Inventory
                         join _product in _context.Product on e.ProductId equals _product.Id into __product
                         from _product in __product.DefaultIfEmpty()
                         join _productUnit in _context.ProductUnit on e.ProductUnitId equals _productUnit.Id into __productUnit
                         from _productUnit in __productUnit.DefaultIfEmpty()
                         select new InventoryView
                         {
                             Id = e.Id,
                             EntityForeignId = e.EntityForeignId,
                             EntityId = e.EntityId,
                             EntityProcCode = e.EntityProcCode,
                             ExpDate = e.ExpDate,
                             InventoryCode = e.InventoryCode,
                             IsSingle = e.IsSingle,
                             IsWholeQuantity = e.IsWholeQuantity,
                             ProcInInventory = e.ProcInInventory,
                             ProductId = e.ProductId,
                             ProductUnitId = e.ProductUnitId,
                             StartDate = e.StartDate,
                             product = new InventoryView._Product
                             {
                                 Id = _product.Id,
                                 ProductName = _product.ProductName
                             },
                             productUnit = new InventoryView._ProductUnit
                             {
                                 Id = _productUnit.Id,
                                 ProductUnitName = _productUnit.ProductUnitName
                             }
                         };


            if (request.Id != null)
                result = result.Where(r => r.Id == request.Id);

            if (request.InventoryCode != null)
                result = result.Where(r => r.InventoryCode.StartsWith(request.InventoryCode));

            return (List<InventoryView>)await result.ToListAsync(cancellationToken);
        }

    }
}
