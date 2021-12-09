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

namespace Application.Domains.Product.ProductProcessorProductFeature.Commands.CreateProductProcessorProductFeature
{
    public class CreateProductProcessorProductFeatureCommand : IRequest<Application.Model.Product.ProductProcessorProductFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductProcessorProductFeature ProductProcessorProductFeature { get; set; }
    }

    public class CreateProductProcessorProductFeatureCommandHandler : IRequestHandler<CreateProductProcessorProductFeatureCommand, Application.Model.Product.ProductProcessorProductFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductProcessorProductFeature> Handle(CreateProductProcessorProductFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductProcessorProductFeature;

            _context.ProductProcessorProductFeature.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
