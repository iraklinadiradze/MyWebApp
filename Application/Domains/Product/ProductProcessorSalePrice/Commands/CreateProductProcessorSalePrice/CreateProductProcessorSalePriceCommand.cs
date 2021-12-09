using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Product;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.ProductProcessorSalePrice.Commands.CreateProductProcessorSalePrice
{
    public class CreateProductProcessorSalePriceCommand : IRequest<Application.Model.Product.ProductProcessorSalePrice>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductProcessorSalePrice ProductProcessorSalePrice { get; set; }
    }

    public class CreateProductProcessorSalePriceCommandHandler : IRequestHandler<CreateProductProcessorSalePriceCommand, Application.Model.Product.ProductProcessorSalePrice>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorSalePriceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductProcessorSalePrice> Handle(CreateProductProcessorSalePriceCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductProcessorSalePrice;

            _context.ProductProcessorSalePrice.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
