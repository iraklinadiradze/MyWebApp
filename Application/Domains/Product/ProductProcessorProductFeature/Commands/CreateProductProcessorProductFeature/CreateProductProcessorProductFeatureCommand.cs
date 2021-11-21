using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.ProductProcessorProductFeature.Commands.CreateProductProcessorProductFeature
{
    public class CreateProductProcessorProductFeatureCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorProductFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductProcessorProductFeature ProductProcessorProductFeature { get; set; }
    }

    public class CreateProductProcessorProductFeatureCommandHandler : IRequestHandler<CreateProductProcessorProductFeatureCommand, DataAccessLayer.Model.Product.ProductProcessorProductFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessorProductFeature> Handle(CreateProductProcessorProductFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductProcessorProductFeature;

            _context.ProductProcessorProductFeature.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
