using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Sale;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Sale.SaleProduct.Commands.CreateSaleProduct
{
    public class CreateSaleProductCommand : IRequest<Application.Model.Sale.SaleProduct>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Sale.SaleProduct SaleProduct { get; set; }
    }

    public class CreateSaleProductCommandHandler : IRequestHandler<CreateSaleProductCommand, Application.Model.Sale.SaleProduct>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateSaleProductCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Sale.SaleProduct> Handle(CreateSaleProductCommand request, CancellationToken cancellationToken)
        {
            var entity = request.SaleProduct;

            _context.SaleProduct.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
