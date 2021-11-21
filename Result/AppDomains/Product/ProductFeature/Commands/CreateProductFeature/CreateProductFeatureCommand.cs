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

namespace Application.Domains.Product.ProductFeature.Commands.CreateProductFeature
{
    public class CreateProductFeatureCommand : IRequest<DataAccessLayer.Model.Product.ProductFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductFeature ProductFeature { get; set; }
    }

    public class CreateProductFeatureCommandHandler : IRequestHandler<CreateProductFeatureCommand, DataAccessLayer.Model.Product.ProductFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductFeature> Handle(CreateProductFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductFeature;

            _context.ProductFeature.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
