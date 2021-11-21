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
using Application.Common;

namespace Application.Domains.Product.ProductProcessorSalePrice.Commands.UpdateProductProcessorSalePrice
{
    public class UpdateProductProcessorSalePriceCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorSalePrice>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductProcessorSalePrice ProductProcessorSalePrice { get; set; }
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

            var entity = request.ProductProcessorSalePrice;

            var _entity = await _context.ProductProcessorSalePrice.FindAsync(request.ProductProcessorSalePrice.Id);

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
