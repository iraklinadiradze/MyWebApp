using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Product.ProductProcessorSalePrice.Commands.CreateProductProcessorSalePrice
{
    public class CreateProductProcessorSalePriceCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductProcessorSalePrice productProcessorSalePrice { get; set; }
    }

    public class CreateProductProcessorSalePriceCommandHandler : IRequestHandler<CreateProductProcessorSalePriceCommand, DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorSalePriceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessorSalePrice> Handle(CreateProductProcessorSalePriceCommand request, CancellationToken cancellationToken)
        {
            var entity = request.productProcessorSalePrice;

            _context.ProductProcessorSalePrice.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
