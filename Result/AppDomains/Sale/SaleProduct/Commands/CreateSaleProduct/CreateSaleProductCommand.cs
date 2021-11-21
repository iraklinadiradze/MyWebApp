using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Sale;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Sale.SaleProduct.Commands.CreateSaleProduct
{
    public class CreateSaleProductCommand : IRequest<DataAccessLayer.Model.Sale.SaleProduct>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Sale.SaleProduct SaleProduct { get; set; }
    }

    public class CreateSaleProductCommandHandler : IRequestHandler<CreateSaleProductCommand, DataAccessLayer.Model.Sale.SaleProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Sale.SaleProduct> Handle(CreateSaleProductCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SaleProduct;

            _context.SaleProduct.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
