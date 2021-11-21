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

namespace Application.Domains.Inventory.Inventory.Commands.ProductToInventory
{
    public class ProductToInventoryCommand : IRequest<int>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int SenderReferenceId { get; set; }
        public DataAccessLayer.Model.Product.Product Product { get; set; }


    }

    public class ProductToInventoryCommandHandler : IRequestHandler<ProductToInventoryCommand, int>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public ProductToInventoryCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public Task<int> Handle(ProductToInventoryCommand request, CancellationToken cancellationToken)
        {



//            throw new NotImplementedException();
        }
    }

    }
