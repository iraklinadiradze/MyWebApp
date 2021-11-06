using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Product.ProductProcessorSalePrice.Commands.UpdateProductProcessorSalePrice
{
    public class UpdateProductProcessorSalePriceCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductProcessorSalePrice productProcessorSalePrice { get; set; }
    }

    public class UpdateProductProcessorSalePriceCommandHandler : IRequestHandler<UpdateProductProcessorSalePriceCommand, DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductProcessorSalePriceCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessorSalePrice> Handle(UpdateProductProcessorSalePriceCommand request, CancellationToken cancellationToken)
        {

            var entity = request.productProcessorSalePrice;

            var _entity = await _context.ProductProcessorSalePrice.FindAsync(request.productProcessorSalePrice.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorSalePrice), entity.Id);
            }

            _context.ProductProcessorSalePrice.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
