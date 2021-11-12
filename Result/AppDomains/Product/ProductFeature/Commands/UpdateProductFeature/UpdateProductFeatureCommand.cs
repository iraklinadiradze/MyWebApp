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

namespace Application.Domains.Product.ProductFeature.Commands.UpdateProductFeature
{
    public class UpdateProductFeatureCommand : IRequest<DataAccessLayer.Model.Product.ProductFeature>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductFeature productFeature { get; set; }
    }

    public class UpdateProductFeatureCommandHandler : IRequestHandler<UpdateProductFeatureCommand, DataAccessLayer.Model.Product.ProductFeature>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductFeatureCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductFeature> Handle(UpdateProductFeatureCommand request, CancellationToken cancellationToken)
        {

            var entity = request.productFeature;

            var _entity = await _context.ProductFeature.FindAsync(request.productFeature.Id);

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
