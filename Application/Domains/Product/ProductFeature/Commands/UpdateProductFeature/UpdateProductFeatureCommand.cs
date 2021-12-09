using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Application.Model.Product;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Product.ProductFeature.Commands.UpdateProductFeature
{
    public class UpdateProductFeatureCommand : IRequest<Application.Model.Product.ProductFeature>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Product.ProductFeature ProductFeature { get; set; }
    }

    public class UpdateProductFeatureCommandHandler : IRequestHandler<UpdateProductFeatureCommand, Application.Model.Product.ProductFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Product.ProductFeature> Handle(UpdateProductFeatureCommand request, CancellationToken cancellationToken)
        {

            var entity = request.ProductFeature;

            var _entity = await _context.ProductFeature.FindAsync(request.ProductFeature.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductFeature), entity.Id);
            }

            _context.ProductFeature.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
