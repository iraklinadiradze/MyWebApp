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

namespace Application.Domains.Product.ProductProcessorProductFeature.Commands.UpdateProductProcessorProductFeature
{
    public class UpdateProductProcessorProductFeatureCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorProductFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductProcessorProductFeature ProductProcessorProductFeature { get; set; }
    }

    public class UpdateProductProcessorProductFeatureCommandHandler : IRequestHandler<UpdateProductProcessorProductFeatureCommand, DataAccessLayer.Model.Product.ProductProcessorProductFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductProcessorProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessorProductFeature> Handle(UpdateProductProcessorProductFeatureCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductProcessorProductFeature;

            var _entity = await _context.ProductProcessorProductFeature.FindAsync(request.ProductProcessorProductFeature.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductProcessorProductFeature), entity.Id);
            }

            _context.ProductProcessorProductFeature.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
